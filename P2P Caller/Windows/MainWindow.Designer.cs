namespace P2P_Caller
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAddContact = new System.Windows.Forms.Button();
            this.radioButtonContactAdress = new System.Windows.Forms.RadioButton();
            this.radioButtonTextAdress = new System.Windows.Forms.RadioButton();
            this.comboBoxAddress = new System.Windows.Forms.ComboBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.buttonCall = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonContacts = new System.Windows.Forms.Button();
            this.buttonHistory = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAddContact);
            this.groupBox1.Controls.Add(this.radioButtonContactAdress);
            this.groupBox1.Controls.Add(this.radioButtonTextAdress);
            this.groupBox1.Controls.Add(this.comboBoxAddress);
            this.groupBox1.Controls.Add(this.textBoxAddress);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // buttonAddContact
            // 
            this.buttonAddContact.BackgroundImage = global::P2P_Caller.Properties.Resources.add;
            this.buttonAddContact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddContact.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAddContact.Location = new System.Drawing.Point(224, 19);
            this.buttonAddContact.Name = "buttonAddContact";
            this.buttonAddContact.Size = new System.Drawing.Size(30, 30);
            this.buttonAddContact.TabIndex = 2;
            this.buttonAddContact.UseVisualStyleBackColor = true;
            this.buttonAddContact.Click += new System.EventHandler(this.ButtonAddContact_Click);
            // 
            // radioButtonContactAdress
            // 
            this.radioButtonContactAdress.AutoSize = true;
            this.radioButtonContactAdress.Location = new System.Drawing.Point(24, 64);
            this.radioButtonContactAdress.Name = "radioButtonContactAdress";
            this.radioButtonContactAdress.Size = new System.Drawing.Size(14, 13);
            this.radioButtonContactAdress.TabIndex = 3;
            this.radioButtonContactAdress.TabStop = true;
            this.radioButtonContactAdress.UseVisualStyleBackColor = true;
            this.radioButtonContactAdress.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // radioButtonTextAdress
            // 
            this.radioButtonTextAdress.AutoSize = true;
            this.radioButtonTextAdress.Location = new System.Drawing.Point(24, 28);
            this.radioButtonTextAdress.Name = "radioButtonTextAdress";
            this.radioButtonTextAdress.Size = new System.Drawing.Size(14, 13);
            this.radioButtonTextAdress.TabIndex = 0;
            this.radioButtonTextAdress.TabStop = true;
            this.radioButtonTextAdress.UseVisualStyleBackColor = true;
            this.radioButtonTextAdress.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // comboBoxAddress
            // 
            this.comboBoxAddress.Enabled = false;
            this.comboBoxAddress.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxAddress.FormattingEnabled = true;
            this.comboBoxAddress.Location = new System.Drawing.Point(54, 55);
            this.comboBoxAddress.Name = "comboBoxAddress";
            this.comboBoxAddress.Size = new System.Drawing.Size(200, 30);
            this.comboBoxAddress.TabIndex = 4;
            this.comboBoxAddress.Click += new System.EventHandler(this.ComboBoxAddress_Click);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxAddress.Location = new System.Drawing.Point(54, 19);
            this.textBoxAddress.MaxLength = 15;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(167, 30);
            this.textBoxAddress.TabIndex = 1;
            this.textBoxAddress.Text = "192.168.100.100";
            this.textBoxAddress.Enter += new System.EventHandler(this.TextBoxAddress_Enter);
            // 
            // buttonCall
            // 
            this.buttonCall.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCall.Location = new System.Drawing.Point(12, 120);
            this.buttonCall.Name = "buttonCall";
            this.buttonCall.Size = new System.Drawing.Size(100, 30);
            this.buttonCall.TabIndex = 5;
            this.buttonCall.Text = "Call";
            this.buttonCall.UseVisualStyleBackColor = true;
            this.buttonCall.Click += new System.EventHandler(this.ButtonCall_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackgroundImage = global::P2P_Caller.Properties.Resources.settings;
            this.buttonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSettings.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSettings.Location = new System.Drawing.Point(242, 120);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(30, 30);
            this.buttonSettings.TabIndex = 6;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // buttonContacts
            // 
            this.buttonContacts.BackgroundImage = global::P2P_Caller.Properties.Resources.contact_book;
            this.buttonContacts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonContacts.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonContacts.Location = new System.Drawing.Point(134, 120);
            this.buttonContacts.Name = "buttonContacts";
            this.buttonContacts.Size = new System.Drawing.Size(30, 30);
            this.buttonContacts.TabIndex = 7;
            this.buttonContacts.UseVisualStyleBackColor = true;
            this.buttonContacts.Click += new System.EventHandler(this.ButtonContacts_Click);
            // 
            // buttonHistory
            // 
            this.buttonHistory.BackgroundImage = global::P2P_Caller.Properties.Resources.history;
            this.buttonHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonHistory.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonHistory.Location = new System.Drawing.Point(188, 120);
            this.buttonHistory.Name = "buttonHistory";
            this.buttonHistory.Size = new System.Drawing.Size(30, 30);
            this.buttonHistory.TabIndex = 8;
            this.buttonHistory.UseVisualStyleBackColor = true;
            this.buttonHistory.Click += new System.EventHandler(this.ButtonHistory_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonCall);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonContacts);
            this.Controls.Add(this.buttonHistory);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P2P Caller";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonContactAdress;
        private System.Windows.Forms.RadioButton radioButtonTextAdress;
        private System.Windows.Forms.ComboBox comboBoxAddress;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Button buttonCall;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonAddContact;
        private System.Windows.Forms.Button buttonContacts;
        private System.Windows.Forms.Button buttonHistory;
        private System.Windows.Forms.Button buttonReject;
        private System.Windows.Forms.RichTextBox richTextBoxCallerId;
        private System.Windows.Forms.Button buttonAnswer;
        private System.Windows.Forms.Timer timer1;
    }
}

