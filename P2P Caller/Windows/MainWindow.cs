using Newtonsoft.Json;
using P2P_Caller.Utils.Network;
using P2P_Caller.Windows;
using System;
using System.IO;
using System.Windows.Forms;

namespace P2P_Caller
{
    public partial class MainWindow : Form
    {
        public static MainWindow instance;
        public static bool locked;
        public int ticks;
        #region variables

            #region protocol
            private MyTcpListener myTcpListener;
            private MyTcpClient myTcpClient;
            private string myIpAddress = Global.GetLocalIPAddress();
            #endregion

            #region windows
            private ContactsWindow contactsWindow;
            private ContactWindow contactWindow;
            private SettingsWindow settingsWindow;
            private HistoryWindow historyWindow;
            #endregion

        #endregion

        public MainWindow()
        {
            instance = this;
            locked = false;
            #region initialize UI

            InitializeComponent();
            radioButtonTextAdress.Checked = true;
            LoadContacts();
            comboBoxAddress.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Text = "P2P Caller - " + myIpAddress;

            #endregion

            #region TcpListener

            myTcpListener = new MyTcpListener();
            
            #endregion
        }

        #region UI

        #region Buttons

        private void ButtonCall_Click(object sender, EventArgs e)
        {
            if (Global.ValidateIPv4(GetAddress()))
            {
                if (Global.GetLocalIPAddress() != GetAddress())
                {
                    if (!locked)
                    {
                        DialogResult dialogResult = MessageBox.Show(String.Format("Are you sure you want to call {0}?", Global.GetContactName(GetAddress())), "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            myTcpClient = new MyTcpClient(GetAddress());
                            LockUI('c');
                            ticks = 0;
                            timer1.Enabled = true;
                        }
                    }
                    else
                    {
                        try
                        {
                            PSSP pssp = new PSSP(PSSP.Type.END);
                            MyTcpClient.client.GetStream().Write(pssp.ToBytes(), 0, pssp.ToBytes().Length);
                            myTcpClient.sp.Stop();
                            Global.AddtoHistory(new HistoryRecord(new Contact("Me", Global.GetLocalIPAddress()).ToString(), "->", new Contact(Global.GetContactName(GetAddress()), GetAddress()).ToString(), DateTime.Now, "00:00:00", "Missed"));
                            UnlockUI();
                            DisableTimer();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            myTcpClient.Stop();
                            UnlockUI();
                            DisableTimer();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You can't call to yourself!");
                }
            }
            else
            {
                MessageBox.Show("Invalid address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
        }

        private void ButtonAddContact_Click(object sender, EventArgs e)
        {
            contactWindow = new ContactWindow(new Contact("",textBoxAddress.Text));
            contactWindow.ShowDialog();
        }

        private void ButtonContacts_Click(object sender, EventArgs e)
        {
            contactsWindow = new ContactsWindow();
            contactsWindow.ShowDialog();
        }

        private void ButtonHistory_Click(object sender, EventArgs e)
        {
            historyWindow = new HistoryWindow();
            historyWindow.ShowDialog();
        }

        #endregion

        private string GetAddress()
        {
            if (radioButtonTextAdress.Checked)
                return Global.TCP_IP(textBoxAddress.Text);
            else
                return Global.TCP_IP(Global.GetIPofContact(comboBoxAddress.Text));
        }

        private void LoadContacts()
        {
            comboBoxAddress.Items.Clear();
            foreach (Contact c in Global.Contacts)
            {
                comboBoxAddress.Items.Add(c.contactName);
            }
            if(comboBoxAddress.Items.Count > 0)
            {
                comboBoxAddress.SelectedIndex = 0;
            }
        }

        private void RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if(radioButton.Name == "radioButtonTextAdress")
            {
                textBoxAddress.Enabled = true;
                comboBoxAddress.Enabled = false;
            }
            else
            {
                textBoxAddress.Enabled = false;
                comboBoxAddress.Enabled = true;
            }
        }

        private void TextBoxAddress_Enter(object sender, EventArgs e)
        {
            textBoxAddress.Text = "";
        }

        private void ComboBoxAddress_Click(object sender, EventArgs e)
        {
            LoadContacts();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            myTcpClient.Stop();
            myTcpListener.Stop();
        }
        public void LockUI(char t)
        {
            if (t == 'c')
            {
                radioButtonContactAdress.Enabled = false;
                radioButtonTextAdress.Enabled = false;
                textBoxAddress.Enabled = false;
                comboBoxAddress.Enabled = false;
                buttonAddContact.Enabled = false;
                buttonCall.Text = "End";
                buttonContacts.Enabled = false;
                buttonHistory.Enabled = false;
                buttonSettings.Enabled = false;
                locked = true;
            }
            if (t == 'l')
            {
                this.Enabled = false;
                radioButtonContactAdress.Enabled = false;
                radioButtonTextAdress.Enabled = false;
                textBoxAddress.Enabled = false;
                comboBoxAddress.Enabled = false;
                buttonAddContact.Enabled = false;
                buttonCall.Enabled = false;
                buttonContacts.Enabled = false;
                buttonHistory.Enabled = false;
                buttonSettings.Enabled = false;
                locked = true;
            }
        }
        public void UnlockUI()
        {
            this.Enabled = true;
            radioButtonContactAdress.Enabled = true;
            radioButtonTextAdress.Enabled = true;
            textBoxAddress.Enabled = true;
            comboBoxAddress.Enabled = false;
            buttonAddContact.Enabled = true;
            buttonCall.Enabled = true;
            buttonCall.Text = "Call";
            buttonContacts.Enabled = true;
            buttonHistory.Enabled = true;
            buttonSettings.Enabled = true;
            locked = false;
        }
        #endregion

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ticks++;
            if(ticks >= 30)
            {
                if (buttonCall.Text == "End")
                {
                    ButtonCall_Click(null, EventArgs.Empty);
                    DisableTimer();
                    MessageBox.Show(String.Format("{0} doesn't answer.\nTry to call later.", Global.GetContactName(GetAddress())));
                }
                else
                    DisableTimer();
            }
        }
        public void DisableTimer()
        {
            ticks = 0;
            timer1.Enabled = false;
        }
        public void RefreshIP()
        {
            this.myIpAddress = Global.GetLocalIPAddress();
            Global.localAddress = myIpAddress;
            this.Text = "P2P Caller - " + myIpAddress;
        }
    }
}
