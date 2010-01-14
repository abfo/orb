namespace AmbientOrbTester
{
    partial class OrbTester
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownAnimation = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownColor = new System.Windows.Forms.NumericUpDown();
            this.groupBoxSerialOnly = new System.Windows.Forms.GroupBox();
            this.panelColor = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxBrightness = new System.Windows.Forms.ComboBox();
            this.checkBoxButtonsEnabled = new System.Windows.Forms.CheckBox();
            this.checkBoxBrightness = new System.Windows.Forms.CheckBox();
            this.checkBoxReset = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnimation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColor)).BeginInit();
            this.groupBoxSerialOnly.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSend);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDownAnimation);
            this.groupBox1.Controls.Add(this.numericUpDownColor);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 97);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Color and Animation ";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(352, 54);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 4;
            this.buttonSend.Text = "&Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Animation:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Color:";
            // 
            // numericUpDownAnimation
            // 
            this.numericUpDownAnimation.Location = new System.Drawing.Point(96, 57);
            this.numericUpDownAnimation.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownAnimation.Name = "numericUpDownAnimation";
            this.numericUpDownAnimation.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownAnimation.TabIndex = 3;
            // 
            // numericUpDownColor
            // 
            this.numericUpDownColor.Location = new System.Drawing.Point(96, 29);
            this.numericUpDownColor.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.numericUpDownColor.Name = "numericUpDownColor";
            this.numericUpDownColor.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownColor.TabIndex = 1;
            // 
            // groupBoxSerialOnly
            // 
            this.groupBoxSerialOnly.Controls.Add(this.label5);
            this.groupBoxSerialOnly.Controls.Add(this.checkBoxReset);
            this.groupBoxSerialOnly.Controls.Add(this.checkBoxBrightness);
            this.groupBoxSerialOnly.Controls.Add(this.checkBoxButtonsEnabled);
            this.groupBoxSerialOnly.Controls.Add(this.comboBoxBrightness);
            this.groupBoxSerialOnly.Controls.Add(this.label4);
            this.groupBoxSerialOnly.Controls.Add(this.label3);
            this.groupBoxSerialOnly.Controls.Add(this.panelColor);
            this.groupBoxSerialOnly.Location = new System.Drawing.Point(12, 124);
            this.groupBoxSerialOnly.Name = "groupBoxSerialOnly";
            this.groupBoxSerialOnly.Size = new System.Drawing.Size(446, 133);
            this.groupBoxSerialOnly.TabIndex = 1;
            this.groupBoxSerialOnly.TabStop = false;
            this.groupBoxSerialOnly.Text = " Serial Connection Only ";
            // 
            // panelColor
            // 
            this.panelColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelColor.Location = new System.Drawing.Point(96, 34);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(128, 33);
            this.panelColor.TabIndex = 1;
            this.panelColor.Click += new System.EventHandler(this.panelColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Set Color:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Brightness:";
            // 
            // comboBoxBrightness
            // 
            this.comboBoxBrightness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBrightness.FormattingEnabled = true;
            this.comboBoxBrightness.Location = new System.Drawing.Point(96, 96);
            this.comboBoxBrightness.Name = "comboBoxBrightness";
            this.comboBoxBrightness.Size = new System.Drawing.Size(128, 21);
            this.comboBoxBrightness.TabIndex = 4;
            this.comboBoxBrightness.SelectedIndexChanged += new System.EventHandler(this.comboBoxBrightness_SelectedIndexChanged);
            // 
            // checkBoxButtonsEnabled
            // 
            this.checkBoxButtonsEnabled.AutoSize = true;
            this.checkBoxButtonsEnabled.Location = new System.Drawing.Point(96, 73);
            this.checkBoxButtonsEnabled.Name = "checkBoxButtonsEnabled";
            this.checkBoxButtonsEnabled.Size = new System.Drawing.Size(135, 17);
            this.checkBoxButtonsEnabled.TabIndex = 2;
            this.checkBoxButtonsEnabled.Text = "&Orb Buttons Enabled";
            this.checkBoxButtonsEnabled.UseVisualStyleBackColor = true;
            this.checkBoxButtonsEnabled.CheckedChanged += new System.EventHandler(this.checkBoxButtonsEnabled_CheckedChanged);
            // 
            // checkBoxBrightness
            // 
            this.checkBoxBrightness.AutoSize = true;
            this.checkBoxBrightness.Enabled = false;
            this.checkBoxBrightness.Location = new System.Drawing.Point(308, 58);
            this.checkBoxBrightness.Name = "checkBoxBrightness";
            this.checkBoxBrightness.Size = new System.Drawing.Size(81, 17);
            this.checkBoxBrightness.TabIndex = 6;
            this.checkBoxBrightness.Text = "Brightness";
            this.checkBoxBrightness.UseVisualStyleBackColor = true;
            // 
            // checkBoxReset
            // 
            this.checkBoxReset.AutoSize = true;
            this.checkBoxReset.Enabled = false;
            this.checkBoxReset.Location = new System.Drawing.Point(308, 81);
            this.checkBoxReset.Name = "checkBoxReset";
            this.checkBoxReset.Size = new System.Drawing.Size(54, 17);
            this.checkBoxReset.TabIndex = 7;
            this.checkBoxReset.Text = "Reset";
            this.checkBoxReset.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(305, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Orb Buttons:";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(383, 272);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // OrbTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 307);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBoxSerialOnly);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "OrbTester";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ambient Orb Tester";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnimation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColor)).EndInit();
            this.groupBoxSerialOnly.ResumeLayout(false);
            this.groupBoxSerialOnly.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownAnimation;
        private System.Windows.Forms.NumericUpDown numericUpDownColor;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.GroupBox groupBoxSerialOnly;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxBrightness;
        private System.Windows.Forms.CheckBox checkBoxButtonsEnabled;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxReset;
        private System.Windows.Forms.CheckBox checkBoxBrightness;
        private System.Windows.Forms.Button buttonClose;
    }
}

