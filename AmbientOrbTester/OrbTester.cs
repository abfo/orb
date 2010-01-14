using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Catfood.AmbientOrb;

namespace AmbientOrbTester
{
    public partial class OrbTester : Form
    {
        private OrbController _orb;
        private OrbSerialController _orbSerial;
        private Color _lastColor;

        public OrbTester()
        {
            InitializeComponent();

            _lastColor = Color.Red;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            comboBoxBrightness.Items.Add(OrbBrightness.Bright.ToString());
            comboBoxBrightness.Items.Add(OrbBrightness.Medium.ToString());
            comboBoxBrightness.Items.Add(OrbBrightness.Dim.ToString());

            checkBoxButtonsEnabled.Checked = true;

            using (OrbPicker orbPicker = new OrbPicker())
            {
                if (orbPicker.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        groupBoxSerialOnly.Enabled = orbPicker.SerialMode;

                        if (orbPicker.SerialMode)
                        {
                            _orbSerial = new OrbSerialController(orbPicker.ComPort);
                            _orb = _orbSerial;

                            // register for button state changes
                            _orbSerial.OrbButtonChanged += new EventHandler<OrbButtonsEventArgs>(_orbSerial_OrbButtonChanged);
                        }
                        else
                        {
                            _orb = new OrbPagerController(orbPicker.DeviceId);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(),
                            "Ambient Orb Tester - Failed to create OrbController",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Hand);

                        // quit if no orb
                        Close();
                    }
                }
                else
                {
                    // just quit if no connection selected
                    Close();
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            // if we have a serial orb controller unhook the button changed event
            if (_orbSerial != null)
            {
                _orbSerial.OrbButtonChanged -= _orbSerial_OrbButtonChanged;
                _orbSerial = null;
            }

            // always dispose the orb controller
            if (_orb != null)
            {
                _orb.Dispose();
                _orb = null;
            }
        }

        private void _orbSerial_OrbButtonChanged(object sender, OrbButtonsEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                checkBoxBrightness.Checked = e.BrightnessButtonDown;
                checkBoxReset.Checked = e.ResetButtonDown;
            }));
        }

        private void UpdateColorAndAnimation()
        {
            try
            {
                // might take a while if we're using an OrbPagerController
                Cursor = Cursors.WaitCursor;

                // can use the base (OrbController) class to update the color
                // and animation - it doesn't matter what the connection is
                _orb.Update((int)numericUpDownColor.Value,
                    (int)numericUpDownAnimation.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                    "Ambient Orb Tester - Failed to update color/animation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            UpdateColorAndAnimation();
        }

        private void panelColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.AllowFullOpen = true;
                cd.AnyColor = true;
                cd.Color = _lastColor;
                cd.FullOpen = true;
                cd.SolidColorOnly = true;

                if (cd.ShowDialog() == DialogResult.OK)
                {
                    _lastColor = cd.Color;
                    panelColor.BackColor = cd.Color;
                    panelColor.Invalidate();

                    try
                    {
                        _orbSerial.Update(_lastColor);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(),
                            "Ambient Orb Tester - Failed to update color",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Hand);
                    }
                }
            }
        }

        private void comboBoxBrightness_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBrightness.SelectedItem is string)
            {
                try
                {
                    OrbBrightness brightness = (OrbBrightness)Enum.Parse(typeof(OrbBrightness), comboBoxBrightness.SelectedItem as string);
                    _orbSerial.SetBrightness(brightness);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(),
                        "Ambient Orb Tester - Failed to set brightness",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                }
            }
        }

        private void checkBoxButtonsEnabled_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (_orbSerial != null)
                {
                    _orbSerial.SetButtonsEnabled(checkBoxButtonsEnabled.Checked);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                    "Ambient Orb Tester - Failed to control orb buttons state",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}