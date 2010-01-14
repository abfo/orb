/* ------------------------------------------------------------------------
 * (c)copyright 2010 Catfood Software - http://www.catfood.net
 * Provided under the ms-PL license, see LICENSE.txt
 * ------------------------------------------------------------------------ */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Drawing;

namespace Catfood.AmbientOrb
{
    /// <summary>
    /// Orb Brightness
    /// </summary>
    public enum OrbBrightness : byte
    {
        /// <summary>
        /// Lowest brightness
        /// </summary>
        Dim = 0,

        /// <summary>
        /// Medium brightness
        /// </summary>
        Medium = 1,

        /// <summary>
        /// Highest brightness
        /// </summary>
        Bright = 2
    }

    /// <summary>
    /// Serial port controller for an Ambient Orb device. Note, this class has not
    /// been designed for muti-threaded use.
    /// </summary>
    /// <remarks>
    /// See http://www.ambientdevices.com/developer/Orb%20AML%202_0%20v2.pdf for Ambient's 
    /// documentation on controlling an Orb via a serial connection. Note that you'll need
    /// to purchase or make a serial developer board  
    /// (see http://www.ambientdevices.com/developer/DIYSerialDeveloperBoard.html)
    /// </remarks>
    public class OrbSerialController : OrbController 
    {
        private bool _disposed;
        private SerialPort _serialPort;
        private float _rgbScaleFactor;
        private bool _brightnessButtonDown;
        private bool _resetButtonDown;

        /// <summary>
        /// Event fired if the state of the Orb's brightness or reset button changes
        /// </summary>
        public event EventHandler<OrbButtonsEventArgs> OrbButtonChanged;

        /// <summary>
        /// Serial port controller for an Ambient Orb device
        /// </summary>
        /// <param name="comPort">The name of the serial port that the Orb is connected to (i.e. COM1)</param>
        /// <exception cref="ArgumentNullException">Thrown if comPort is null</exception>
        public OrbSerialController(string comPort)
        {
            if (comPort == null)
            {
                throw new ArgumentNullException("comPort");
            }

            // used to scale an RGB color to an orb color
            _rgbScaleFactor = 176.0F / 255.0F;

            // note these parameters are required by the Orb interface
            _serialPort = new SerialPort(comPort, 19200, Parity.None, 8, StopBits.One);
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            _serialPort.Open();
        }

        /// <summary>
        /// Update the orb with a color from 0 to 36 and an animation from 0 to 9
        /// </summary>
        /// <param name="color">Color value from 0 to 36</param>
        /// <param name="animation">Animation from 0 (none) to 9 (heartbeat - fastest)</param>
        /// <exception cref="ObjectDisposedException">Thrown if the OrbSerialController has been disposed</exception>
        /// <exception cref="ArgumentException">Thrown if the color or animation values are out of range</exception>
        public override void Update(int color, int animation)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("OrbSerialController");
            }

            if ((color < 0) || (color > 36))
            {
                throw new ArgumentException("color must be between 0 and 36");
            }

            if ((animation < 0) || (animation > 9))
            {
                throw new ArgumentException("animation must be between 0 and 9");
            }

            // always make sure that pager control is disabled
            _serialPort.Write("~GT");

            // construct and send the color/animation message
            byte[] message = new byte[] { (byte)'~', 
                (byte)'A', 
                (byte)((color + (37 * animation)) / 94 + 32), 
                (byte)((color + (37 * animation)) % 94 + 32) };
            _serialPort.Write(message, 0, message.Length);
        }

        /// <summary>
        /// Update the orb with any color. Note that the Orb uses RGB values from 0-176 so
        /// the color is scaled appropriately. The alpha value of the color is ignored. 
        /// Also note that the orb is not calibrated and so the displayed color may not
        /// be a good match for the specified color.
        /// </summary>
        /// <param name="color">Color to set</param>
        /// <exception cref="ObjectDisposedException">Thrown if the OrbSerialController has been disposed</exception>
        public void Update(Color color)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("OrbSerialController");
            }

            // always make sure that pager control is disabled
            _serialPort.Write("~GT");

            // construct and send the direct color message
            byte[] message = new byte[] { (byte)'~', 
                (byte)'D', 
                (byte)(color.R * _rgbScaleFactor), 
                (byte)(color.G * _rgbScaleFactor),
                (byte)(color.B * _rgbScaleFactor) };
            _serialPort.Write(message, 0, message.Length);
        }

        /// <summary>
        /// Sets the brightness of the orb
        /// </summary>
        /// <remarks>
        /// My orb doesn't seem to respond to this commmand. Let me know if you have any luck
        /// with it (rob@catfood.net)
        /// </remarks>
        /// <param name="brightness">OrbBrightness value</param>
        /// <exception cref="ObjectDisposedException">Thrown if the OrbSerialController has been disposed</exception>
        public void SetBrightness(OrbBrightness brightness)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("OrbSerialController");
            }

            // always make sure that pager control is disabled
            _serialPort.Write("~GT");

            // construct and send the brightness color message
            byte[] message = new byte[] { (byte)'~', 
                (byte)'R', 
                (byte)brightness };
            _serialPort.Write(message, 0, message.Length);
        }

        /// <summary>
        /// Set the button state - true to enable brightness and reset buttons, false
        /// to disable brigness and reset buttons
        /// </summary>
        /// <param name="buttonsEnabled">true to enable, false to disable</param>
        /// <exception cref="ObjectDisposedException">Thrown if the OrbSerialController has been disposed</exception>
        public void SetButtonsEnabled(bool buttonsEnabled)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("OrbSerialController");
            }

            // always make sure that pager control is disabled
            _serialPort.Write("~GT");

            if (buttonsEnabled)
            {
                _serialPort.Write("~LI");
            }
            else
            {
                _serialPort.Write("~LE");
            }
        }

        /// <summary>
        /// Gets the current state of the brightness button (true if depressed)
        /// </summary>
        /// <exception cref="ObjectDisposedException">Thrown if the OrbSerialController has been disposed</exception>
        public bool BrightnessButtonDown
        {
            get 
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("OrbSerialController");
                }

                return _brightnessButtonDown; 
            }
        }

        /// <summary>
        /// Gets the current state of the reset button (true if depressed)
        /// </summary>
        /// <exception cref="ObjectDisposedException">Thrown if the OrbSerialController has been disposed</exception>
        public bool ResetButtonDown
        {
            get 
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("OrbSerialController");
                }

                return _resetButtonDown; 
            }
        }

        /// <summary>
        /// Disposes the OrbController
        /// </summary>
        public override void Dispose()
        {
            if (!_disposed)
            {
                if (_serialPort != null)
                {
                    _serialPort.DataReceived -= _serialPort_DataReceived;
                    _serialPort.Close();
                    _serialPort.Dispose();
                    _serialPort = null;
                }

                GC.SuppressFinalize(this);
                _disposed = true;
            }
        }        

        private void OnOrbButtonChanged()
        {
            if (OrbButtonChanged != null)
            {
                OrbButtonChanged(this,
                    new OrbButtonsEventArgs(_brightnessButtonDown, _resetButtonDown));
            }
        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int nextByte = 0;
            bool fireEvent = true;

            while (_serialPort.BytesToRead > 0)
            {
                nextByte = _serialPort.ReadByte();
                fireEvent = true;
                
                switch (nextByte)
                {
                    case 200:
                        _resetButtonDown = true;
                        break;

                    case 201:
                        _resetButtonDown = false;
                        break;

                    case 202:
                        _brightnessButtonDown = true;
                        break;

                    case 203:
                        _brightnessButtonDown = false;
                        break;

                    default:
                        // only fire the event if a button changes
                        fireEvent = false;
                        break;
                }

                if (fireEvent)
                {
                    OnOrbButtonChanged();
                }
            }
        }
    }
}
