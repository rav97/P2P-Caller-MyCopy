namespace P2P_Caller
{
    partial class SettingsWindow
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
            this.panelDevices = new System.Windows.Forms.Panel();
            this.richTextBoxIn = new System.Windows.Forms.RichTextBox();
            this.comboBoxIn = new System.Windows.Forms.ComboBox();
            this.richTextBoxOut = new System.Windows.Forms.RichTextBox();
            this.comboBoxOut = new System.Windows.Forms.ComboBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.comboBoxNet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelDevices.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDevices
            // 
            this.panelDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDevices.Controls.Add(this.richTextBoxIn);
            this.panelDevices.Controls.Add(this.comboBoxIn);
            this.panelDevices.Controls.Add(this.richTextBoxOut);
            this.panelDevices.Controls.Add(this.comboBoxOut);
            this.panelDevices.Location = new System.Drawing.Point(12, 23);
            this.panelDevices.Name = "panelDevices";
            this.panelDevices.Size = new System.Drawing.Size(260, 150);
            this.panelDevices.TabIndex = 0;
            // 
            // richTextBoxIn
            // 
            this.richTextBoxIn.BackColor = System.Drawing.Color.White;
            this.richTextBoxIn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxIn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBoxIn.Location = new System.Drawing.Point(8, 80);
            this.richTextBoxIn.Name = "richTextBoxIn";
            this.richTextBoxIn.Size = new System.Drawing.Size(80, 20);
            this.richTextBoxIn.TabIndex = 4;
            this.richTextBoxIn.TabStop = false;
            this.richTextBoxIn.Text = "Input";
            // 
            // comboBoxIn
            // 
            this.comboBoxIn.Font = new System.Drawing.Font("Consolas", 10F);
            this.comboBoxIn.FormattingEnabled = true;
            this.comboBoxIn.Location = new System.Drawing.Point(30, 102);
            this.comboBoxIn.Name = "comboBoxIn";
            this.comboBoxIn.Size = new System.Drawing.Size(200, 23);
            this.comboBoxIn.TabIndex = 1;
            this.comboBoxIn.SelectedIndexChanged += new System.EventHandler(this.ComboBoxIn_SelectedIndexChanged);
            // 
            // richTextBoxOut
            // 
            this.richTextBoxOut.BackColor = System.Drawing.Color.White;
            this.richTextBoxOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxOut.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBoxOut.Location = new System.Drawing.Point(8, 18);
            this.richTextBoxOut.Name = "richTextBoxOut";
            this.richTextBoxOut.Size = new System.Drawing.Size(80, 20);
            this.richTextBoxOut.TabIndex = 2;
            this.richTextBoxOut.TabStop = false;
            this.richTextBoxOut.Text = "Output";
            // 
            // comboBoxOut
            // 
            this.comboBoxOut.Font = new System.Drawing.Font("Consolas", 10F);
            this.comboBoxOut.FormattingEnabled = true;
            this.comboBoxOut.Location = new System.Drawing.Point(30, 40);
            this.comboBoxOut.Name = "comboBoxOut";
            this.comboBoxOut.Size = new System.Drawing.Size(200, 23);
            this.comboBoxOut.TabIndex = 0;
            this.comboBoxOut.SelectedIndexChanged += new System.EventHandler(this.ComboBoxOut_SelectedIndexChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOk.Location = new System.Drawing.Point(12, 322);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(42, 30);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCancel.Location = new System.Drawing.Point(204, 322);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(68, 30);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.richTextBox2);
            this.panel1.Controls.Add(this.comboBoxNet);
            this.panel1.Location = new System.Drawing.Point(12, 206);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 81);
            this.panel1.TabIndex = 5;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.White;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox2.Location = new System.Drawing.Point(8, 14);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(80, 20);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.TabStop = false;
            this.richTextBox2.Text = "Output";
            // 
            // comboBoxNet
            // 
            this.comboBoxNet.Font = new System.Drawing.Font("Consolas", 10F);
            this.comboBoxNet.FormattingEnabled = true;
            this.comboBoxNet.Location = new System.Drawing.Point(30, 35);
            this.comboBoxNet.Name = "comboBoxNet";
            this.comboBoxNet.Size = new System.Drawing.Size(200, 23);
            this.comboBoxNet.TabIndex = 0;
            this.comboBoxNet.SelectedIndexChanged += new System.EventHandler(this.ComboBoxNet_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Audio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Internet";
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.panelDevices);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.panelDevices.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDevices;
        private System.Windows.Forms.RichTextBox richTextBoxIn;
        private System.Windows.Forms.ComboBox comboBoxIn;
        private System.Windows.Forms.RichTextBox richTextBoxOut;
        private System.Windows.Forms.ComboBox comboBoxOut;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ComboBox comboBoxNet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}