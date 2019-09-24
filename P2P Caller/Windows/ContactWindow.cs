using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2P_Caller
{
    public partial class ContactWindow : Form
    {
        private Contact contact;
        private string name = "" , address = "";

        public ContactWindow()
        {
            InitializeComponent();
        }

        public ContactWindow(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;
            textBoxName.Text = contact.contactName;
            textBoxAdress.Text = contact.IPAddress;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (name == "" || address == "")
            {
                MessageBox.Show("Type name and address of the contact!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else {
                if (!Global.ValidateIPv4(address))
                {
                    MessageBox.Show("Invalid address!", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else {
                    if (contact == null)
                    {
                        Global.Contacts.Add(new Contact(name, address));
                    }
                    else
                    {
                        Global.RemoveContact(contact);
                        Global.Contacts.Add(new Contact(name, address));
                    }
                    Global.SaveContacts();
                }
            }
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            name = textBoxName.Text;
        }

        private void TextBoxAdress_TextChanged(object sender, EventArgs e)
        {
            address = textBoxAdress.Text;
        }
    }
}
