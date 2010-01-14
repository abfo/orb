/* ------------------------------------------------------------------------
 * (c)copyright 2010 Catfood Software - http://www.catfood.net
 * Provided under the ms-PL license, see LICENSE.txt
 * ------------------------------------------------------------------------ */

using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Reflection;
using System.Xml;

namespace Catfood.AmbientOrb
{
    /// <summary>
    /// Pager network controller for an Ambient Orb device. Note, this class has not
    /// been designed for muti-threaded use.
    /// </summary>
    /// <remarks>
    /// See http://www.ambientdevices.com/developer/OrbWDK.pdf for Ambient's 
    /// documentation on controlling an orb via the pager network
    /// </remarks>
    public class OrbPagerController : OrbController
    {
        private const string OrbControlUrlTemplate = "http://www.myambient.com:8080/java/my_devices/submitdata.jsp?devID={0}&color={1}&anim={2}";

        private bool _disposed;
        private string _deviceId;

        /// <summary>
        /// Pager network controller for an Ambient Orb device
        /// </summary>
        /// <param name="deviceId">The Device ID of the orb to control</param>
        /// <exception cref="ArgumentNullException">Thrown if deviceId is null</exception>
        public OrbPagerController(string deviceId)
        {
            if (deviceId == null)
            {
                throw new ArgumentNullException("deviceId");
            }

            _deviceId = deviceId;
        }

        /// <summary>
        /// Update the orb with a color from 0 to 36 and an animation from 0 to 9
        /// </summary>
        /// <param name="color">Color value from 0 to 36</param>
        /// <param name="animation">Animation from 0 (none) to 9 (heartbeat - fastest)</param>
        /// <exception cref="ObjectDisposedException">Thrown if the OrbPagerController has been disposed</exception>
        /// <exception cref="ArgumentException">Thrown if the color or animation values are out of range</exception>
        /// <exception cref="InvalidOperationException">Thrown if the update call fails</exception>
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

            string orbUpdateUrl = string.Format(CultureInfo.InvariantCulture,
                OrbControlUrlTemplate,
                _deviceId,
                color,
                animation);

            int response = -1;
            string responseText = string.Empty;

            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.CheckCharacters = true;
            readerSettings.CloseInput = true;
            readerSettings.ConformanceLevel = ConformanceLevel.Document;
            readerSettings.IgnoreComments = true;
            readerSettings.IgnoreWhitespace = true;

            using (XmlReader reader = XmlReader.Create(orbUpdateUrl, readerSettings))
            {
                while (reader.Read())
                {
                    if ((reader.Name == "response") && reader.IsStartElement())
                    {
                        response = Convert.ToInt32(reader.GetAttribute("value"), CultureInfo.InvariantCulture);
                        responseText = reader.ReadString();
                    }
                }
            }

            // response will be 0 if the update was sent successfully
            if (response != 0)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                    "Orb Update Failed ({0}): {1}",
                    response,
                    responseText));
            }
        }

        /// <summary>
        /// Disposes the OrbController
        /// </summary>
        public override void Dispose()
        {
            if (!_disposed)
            {
                GC.SuppressFinalize(this);
                _disposed = true;
            }
        }
    }
}
