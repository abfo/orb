namespace AmbientOrbTester
{
    partial class OrbPicker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButtonSerial = new System.Windows.Forms.RadioButton();
            this.radioButtonPager = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxComPort = new System.Windows.Forms.TextBox();
            this.textBoxDeviceId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // radioButtonSerial
            // 
            this.radioButtonSerial.AutoSize = true;
            this.radioButtonSerial.Location = new System.Drawing.Point(76, 55);
            this.radioButtonSerial.Name = "radioButtonSerial";
            this.radioButtonSerial.Size = new System.Drawing.Size(181, 17);
            this.radioButtonSerial.TabIndex = 1;
            this.radioButtonSerial.TabStop = true;
            this.radioButtonSerial.Text = "Serial (enter port, i.e. \"COM1\"):";
            this.radioButtonSerial.UseVisualStyleBackColor = true;
            this.radioButtonSerial.CheckedChanged += new System.EventHandler(this.radioButtonSerial_CheckedChanged);
            // 
            // radioButtonPager
            // 
            this.radioButtonPager.AutoSize = true;
            this.radioButtonPager.Location = new System.Drawing.Point(76, 83);
            this.radioButtonPager.Name = "radioButtonPager";
            this.radioButtonPager.Size = new System.Drawing.Size(189, 17);
            this.radioButtonPager.TabIndex = 3;
            this.radioButtonPager.TabStop = true;
            this.radioButtonPager.Text = "Pager Network (enter device ID):";
            this.radioButtonPager.UseVisualStyleBackColor = true;
            this.radioButtonPager.CheckedChanged += new System.EventHandler(this.radioButtonPager_CheckedChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(289, 138);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(370, 138);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxComPort
            // 
            this.textBoxComPort.Location = new System.Drawing.Point(281, 54);
            this.textBoxComPort.Name = "textBoxComPort";
            this.textBoxComPort.Size = new System.Drawing.Size(100, 22);
            this.textBoxComPort.TabIndex = 2;
            this.textBoxComPort.TextChanged += new System.EventHandler(this.textBoxComPort_TextChanged);
            // 
            // textBoxDeviceId
            // 
            this.textBoxDeviceId.Location = new System.Drawing.Point(281, 82);
            this.textBoxDeviceId.Name = "textBoxDeviceId";
            this.textBoxDeviceId.Size = new System.Drawing.Size(100, 22);
            this.textBoxDeviceId.TabIndex = 4;
            this.textBoxDeviceId.TextChanged += new System.EventHandler(this.textBoxDeviceId_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Note, power device off and on again when switching from serial to pager control.";
            // 
            // OrbPicker
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(457, 173);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDeviceId);
            this.Controls.Add(this.textBoxComPort);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.radioButtonPager);
            this.Controls.Add(this.radioButtonSerial);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrbPicker";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose Orb Connection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonSerial;
        private System.Windows.Forms.RadioButton radioButtonPager;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxComPort;
        private System.Windows.Forms.TextBox textBoxDeviceId;
        private System.Windows.Forms.Label label1;
    }
}