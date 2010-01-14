using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AmbientOrbTester
{
    public partial class OrbPicker : Form
    {
        private bool _serialMode;
        private string _comPort;
        private string _deviceId;

        public OrbPicker()
        {
            InitializeComponent();
        }

        /// <summary>
        /// True if a serial connection is desired, false if the pager network should be used
        /// </summary>
        public bool SerialMode
        {
            get { return _serialMode; }
        }

        /// <summary>
        /// Gets the COM port to use in serial mode
        /// </summary>
        public string ComPort
        {
            get { return _comPort; }
        }

        /// <summary>
        /// Gets the Device ID to use in pager mode
        /// </summary>
        public string DeviceId
        {
            get { return _deviceId; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            radioButtonSerial.Checked = true;
        }

        private void UpdateFormState()
        {
            textBoxComPort.Enabled = radioButtonSerial.Checked;
            textBoxDeviceId.Enabled = radioButtonPager.Checked;

            if (radioButtonSerial.Checked)
            {
                buttonOK.Enabled = (textBoxComPort.Text.Length > 0);
            }
            else
            {
                buttonOK.Enabled = (textBoxDeviceId.Text.Length > 0);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _serialMode = radioButtonSerial.Checked;
            _comPort = textBoxComPort.Text;
            _deviceId = textBoxDeviceId.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void radioButtonSerial_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFormState();
        }

        private void radioButtonPager_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFormState();
        }

        private void textBoxComPort_TextChanged(object sender, EventArgs e)
        {
            UpdateFormState();
        }

        private void textBoxDeviceId_TextChanged(object sender, EventArgs e)
        {
            UpdateFormState();
        }
    }
}