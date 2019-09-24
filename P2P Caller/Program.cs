using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace P2P_Caller
{
    static class Program
    {
        private static Mutex mutex = null;

        [STAThread]
        static void Main()
        {
            const string appName = "P2P Caller";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if(!createdNew)
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            LoadContacts();
            LoadHistory();
            Global.Busy = false;
            Application.Run(new MainWindow());
        }

        private static void OnApplicationExit(object sender, EventArgs args)
        {
            Global.SaveContacts();
            Global.SaveHistory();
        }

        static void LoadHistory()
        {
            string jsonread = string.Empty;
            string filename = "history.his";
            Console.WriteLine("Odczyt z pliku...");
            try
            {
                if (File.Exists(filename))
                {
                    byte[] fileEncrypted = File.ReadAllBytes(filename);
                    jsonread = Global.aes.Decrypt(fileEncrypted);
                }
            }
            catch(Exception e)
            {
                Global.History = JsonHelp.DeserializeHistory("");
            }

            Global.History = JsonHelp.DeserializeHistory(jsonread);
        }

        static void LoadContacts()
        {
            string jsonread = string.Empty; 
            string filename = "contacts.con";
            Console.WriteLine("Odczyt z pliku...");

            try
            {
                if (File.Exists(filename))
                {
                    byte[] fileEncrypted = File.ReadAllBytes(filename);
                    jsonread = Global.aes.Decrypt(fileEncrypted);
                }
            }
            catch(Exception e)
            {
                Global.Contacts = JsonHelp.DeserializeContacts("");
            }
            Global.Contacts = JsonHelp.DeserializeContacts(jsonread);
        }
    }
}
