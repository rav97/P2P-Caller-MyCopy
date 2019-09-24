namespace P2P_Caller
{
    partial class ContactsWindow
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonDeleteContact = new System.Windows.Forms.Button();
            this.buttonEditContact = new System.Windows.Forms.Button();
            this.buttonAddContact = new System.Windows.Forms.Button();
            this.listViewContacts = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCancel.Location = new System.Drawing.Point(272, 393);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(91, 37);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Close";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // buttonDeleteContact
            // 
            this.buttonDeleteContact.BackgroundImage = global::P2P_Caller.Properties.Resources.cancel;
            this.buttonDeleteContact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDeleteContact.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDeleteContact.Location = new System.Drawing.Point(149, 393);
            this.buttonDeleteContact.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteContact.Name = "buttonDeleteContact";
            this.buttonDeleteContact.Size = new System.Drawing.Size(40, 37);
            this.buttonDeleteContact.TabIndex = 3;
            this.buttonDeleteContact.UseVisualStyleBackColor = true;
            this.buttonDeleteContact.Click += new System.EventHandler(this.ButtonDeleteContact_Click);
            // 
            // buttonEditContact
            // 
            this.buttonEditContact.BackgroundImage = global::P2P_Caller.Properties.Resources._new;
            this.buttonEditContact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEditContact.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonEditContact.Location = new System.Drawing.Point(83, 393);
            this.buttonEditContact.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEditContact.Name = "buttonEditContact";
            this.buttonEditContact.Size = new System.Drawing.Size(40, 37);
            this.buttonEditContact.TabIndex = 2;
            this.buttonEditContact.UseVisualStyleBackColor = true;
            this.buttonEditContact.Click += new System.EventHandler(this.ButtonEditContact_Click);
            // 
            // buttonAddContact
            // 
            this.buttonAddContact.BackgroundImage = global::P2P_Caller.Properties.Resources.add;
            this.buttonAddContact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddContact.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAddContact.Location = new System.Drawing.Point(16, 393);
            this.buttonAddContact.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddContact.Name = "buttonAddContact";
            this.buttonAddContact.Size = new System.Drawing.Size(40, 37);
            this.buttonAddContact.TabIndex = 1;
            this.buttonAddContact.UseVisualStyleBackColor = true;
            this.buttonAddContact.Click += new System.EventHandler(this.ButtonAddContact_Click);
            // 
            // listViewContacts
            // 
            this.listViewContacts.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listViewContacts.FullRowSelect = true;
            this.listViewContacts.Location = new System.Drawing.Point(18, 23);
            this.listViewContacts.Name = "listViewContacts";
            this.listViewContacts.Size = new System.Drawing.Size(345, 346);
            this.listViewContacts.TabIndex = 5;
            this.listViewContacts.UseCompatibleStateImageBehavior = false;
            this.listViewContacts.View = System.Windows.Forms.View.List;
            this.listViewContacts.SelectedIndexChanged += new System.EventHandler(this.ListViewContacts_SelectedIndexChanged);
            // 
            // ContactsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(379, 444);
            this.Controls.Add(this.listViewContacts);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDeleteContact);
            this.Controls.Add(this.buttonEditContact);
            this.Controls.Add(this.buttonAddContact);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContactsWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contacts";
            this.Activated += new System.EventHandler(this.ContactsWindow_Enter);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonAddContact;
        private System.Windows.Forms.Button buttonEditContact;
        private System.Windows.Forms.Button buttonDeleteContact;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listViewContacts;
    }
}