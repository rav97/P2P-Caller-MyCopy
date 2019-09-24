using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2P_Caller
{
    public partial class ContactsWindow : Form
    {
        private Contact selectedContact;
        private ListViewItem item;

        private ContactWindow contactWindow;

        public ContactsWindow()
        {
            InitializeComponent();

            listViewContacts.View = View.Details;
            listViewContacts.Columns.Add("Name", -2, HorizontalAlignment.Left);
            listViewContacts.Columns.Add("Adress", -2, HorizontalAlignment.Center);

            LoadListView();
        }

        private void ButtonAddContact_Click(object sender, EventArgs e)
        {
            contactWindow = new ContactWindow();
            contactWindow.ShowDialog();
        }

        private void ButtonEditContact_Click(object sender, EventArgs e)
        {
            if (selectedContact == null)
            {
                MessageBox.Show("No contact selected!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            contactWindow = new ContactWindow(selectedContact);
            contactWindow.ShowDialog();
            LoadListView();
        }

        private void ButtonDeleteContact_Click(object sender, EventArgs e)
        {
            if (selectedContact == null)
            {
                MessageBox.Show("No contact selected!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure to delete " + selectedContact.contactName + "?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                /*Global.Contacts.RemoveAll(c => c.IPAddress == selectedContact.IPAddress);
                LoadListView();
                Global.SaveContacts();*/
                Global.RemoveContact(selectedContact);
                LoadListView();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadListView()
        {
            listViewContacts.Items.Clear();
            foreach (Contact c in Global.Contacts)
            {
                item = new ListViewItem(c.contactName);
                item.SubItems.Add(c.IPAddress);
                listViewContacts.Items.Add(item);
            }
        }

        private void ListViewContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = listViewContacts.FocusedItem.Text;
            selectedContact = Global.Contacts.Where(c => c.contactName == name).FirstOrDefault();
        }

        private void ContactsWindow_Enter(object sender, EventArgs e)
        {
            LoadListView();
        }
    }
}
