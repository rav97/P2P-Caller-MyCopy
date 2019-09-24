using Newtonsoft.Json;
using P2P_Caller.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

class Global
{
    public enum AnswerType : ushort { NO = 0, YES = 1, NOINFO = 2 };
    public static List<Contact> Contacts;
    public static List<HistoryRecord> History;
    public static Boolean Busy;
    public static AnswerType CallAnswered;
    public static string remoteAddress;
    public static int remotePort;
    public static string localAddress;
    public static int localPort;
    public static string dir;
    public static AES aes = new AES();
    public static int InAudioDeviceNumber = 0;
    public static int OutAudioDeviceNumber = 0;
    public static string InterfaceName = String.Empty;

    public static bool ValidateIPv4(string ipString)
    {
        if (String.IsNullOrWhiteSpace(ipString))
        {
            return false;
        }

        string[] splitValues = ipString.Split('.');
        if (splitValues.Length != 4)
        {
            return false;
        }

        byte tempForParsing;

        return splitValues.All(r => byte.TryParse(r, out tempForParsing));
    }

    public static string GetLocalIPAddress()
    {
        if (!String.IsNullOrEmpty(InterfaceName))
        {
            foreach(NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if(nic.Name == InterfaceName)
                {
                    foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            return ip.Address.ToString();
                        }
                    }
                }
            }
        }
        string ipAddress = String.Empty;
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new Exception("No network adapters with an IPv4 address in the system!");
    }
    public static string PSSP_IP(string ip)
    {
        string ipAddress = string.Empty;
        string[] splitValues = ip.ToString().Split('.');
        for (int j = 0; j < splitValues.Length; j++)
        {
            int len = 3 - splitValues[j].Length;
            if (len != 0)
            {
                for (int i = len; i > 0; i--)
                {
                    splitValues[j] = "0" + splitValues[j];
                }
            }
            ipAddress += splitValues[j];
            if (j < splitValues.Length - 1)
            {
                ipAddress += ".";
            }
        }
        return ipAddress;
    }

    public static string TCP_IP(string PSSP_IP)
    {
        string ipAddress = string.Empty;
        string[] splitValues = PSSP_IP.ToString().Split('.');
        for (int i = 0; i < splitValues.Length; i++)
        {
            int zeros = 0;
            bool tn = true;
            for (int j = 0; j < splitValues[i].Length; j++)
            {
                if (splitValues[i][j] == '0')
                {
                    if (tn)
                        zeros++;
                }
                else
                {
                    tn = false;
                }
                if (j == splitValues[i].Length - 1)
                {
                    if (zeros < 3)
                        ipAddress += splitValues[i].Substring(zeros, splitValues[i].Length - zeros);
                    if (tn)
                        ipAddress += "0";
                }
            }
            if (i < splitValues.Length - 1)
            {
                ipAddress += ".";
            }
        }
        return ipAddress;
    }
    public static string GetContactName(string ip)
    {
        foreach (Contact c in Contacts)
        {
            if (c.IPAddress == ip)
                return c.contactName;
        }
        return ip;
    }
    public static string GetIPofContact(string name)
    {
        string IP = string.Empty;
        foreach (Contact c in Contacts)
        {
            if (c.contactName == name)
                return c.IPAddress;
        }
        return IP;
    }
    public static void AddtoHistory(HistoryRecord h)
    {
        History.Add(h);
    }
    public static void ClearHistory()
    {
        History.Clear();
    }
    public static void SaveContacts()
    {
        byte[] encrypted;

        string json = JsonConvert.SerializeObject(Global.Contacts);
        encrypted = aes.Encrypt(json);
        using (FileStream fs = new FileStream("contacts.con", FileMode.Create))
        {
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(encrypted);
                bw.Close();
            }
        }
    }
    public static void SaveHistory()
    {
        byte[] encrypted;

        string json = JsonConvert.SerializeObject(Global.History);
        encrypted = aes.Encrypt(json);
        using (FileStream fs = new FileStream("history.his", FileMode.Create))
        {
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(encrypted);
                bw.Close();
            }
        }
    }
    public static void RemoveContact(Contact c)
    {
        Contacts.Remove(c);
        SaveContacts();
    }
}
