using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2P_Caller
{
    public partial class SettingsWindow : Form
    {
        private int idAudioIn, idAudioOut;
        string interfaceName = string.Empty;
        bool changed;

        public SettingsWindow()
        {
            InitializeComponent();
            InitComboBoxes();

            idAudioIn = 0;
            idAudioOut = 0;
            changed = false;
        }

        #region comboboxes
        private void InitComboBoxes()
        {
            var enumerator = new MMDeviceEnumerator();
            foreach (var endpoint in
                     enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            {
                comboBoxOut.Items.Add(endpoint.FriendlyName);
                //Console.WriteLine(endpoint.FriendlyName);
            }
            foreach (var endpoint in
                     enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
            {
                comboBoxIn.Items.Add(endpoint.FriendlyName);
                //Console.WriteLine(endpoint.FriendlyName);
            }
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    comboBoxNet.Items.Add(nic.Name);
                }
            }

            if (comboBoxIn.Items.Count > 0)
            {
                comboBoxIn.SelectedIndex = 0;
            }
            if (comboBoxOut.Items.Count > 0)
            {
                comboBoxOut.SelectedIndex = 0;
            }
            if (comboBoxNet.Items.Count > 0)
            {
                comboBoxNet.SelectedIndex = 0;
            }

            comboBoxIn.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOut.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxNet.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ComboBoxOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            changed = true;
            string name = (string)comboBoxOut.SelectedItem;
            idAudioOut = comboBoxOut.FindStringExact(name);
            
        }

        private void ComboBoxIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            changed = true;
            string name = (string)comboBoxIn.SelectedItem;
            idAudioIn = comboBoxIn.FindStringExact(name);
        }

        private void ComboBoxNet_SelectedIndexChanged(object sender, EventArgs e)
        {
            changed = true;
            interfaceName = (string)comboBoxNet.SelectedItem;
        }

        #endregion

        #region buttons
        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (changed)
            {
                Global.OutAudioDeviceNumber = idAudioOut;
                Global.InAudioDeviceNumber = idAudioIn;
                Global.InterfaceName = interfaceName;
                MainWindow.instance.Invoke((MethodInvoker)delegate { MainWindow.instance.RefreshIP(); });
            }
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
