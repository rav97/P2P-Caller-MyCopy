using P2P_Caller.Windows;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace P2P_Caller.Utils.Network
{
    class MyTcpListener
    {
        private static Random rand = new Random();
        Thread thread;
        static int myPortNumber;

        public MyTcpListener()
        {
            thread = new Thread(Start);
            thread.IsBackground = true;
            thread.Start();
        }

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 16000);
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Klient polaczony");
                ThreadPool.QueueUserWorkItem(ClientHandler, new object[] { client, Global.Busy });
            }
        }

        static void ClientHandler(object obj)
        {
            //var param = client as object;
            object[] args = obj as object[];

            TcpClient client = (TcpClient)args[0];
            bool busy = (bool)args[1];

            byte[] buffer = new byte[34];

            PSSP pssp = new PSSP();

            bool dialogshown = false;

            try
            {
                while (true)
                {
                    int l = client.GetStream().Read(buffer, 0, buffer.Length);
                    Console.WriteLine("Serwer otrzymal: " + new ASCIIEncoding().GetString(buffer).Substring(0, l));

                    PSSP receive_pssp = new PSSP(buffer);

                    if (!busy)
                    {
                        Global.Busy = true;

                        if (receive_pssp.getOP() == "CALL" && !dialogshown)
                        {
                            Global.dir = "<-";
                            Global.Busy = true;
                            MainWindow.instance.Invoke((MethodInvoker)delegate { MainWindow.instance.LockUI('l'); });
                            string ip = receive_pssp.getIP();
                            Global.remoteAddress = ip;
                            IncomingCallMessageBox incomingCallMessageBox = new IncomingCallMessageBox(ip, client);
                            incomingCallMessageBox.ShowDialog();
                            dialogshown = true;

                            //komunikat o połączeniu
                            // jeśli Yes to wyślij ACK-
                            // połącz udp
                            
                            if (Global.CallAnswered == Global.AnswerType.YES)
                            {
                                int port = receive_pssp.getPORT();
                                myPortNumber = RandomPort(receive_pssp.getPORT());
                                pssp = new PSSP(PSSP.Type.ACK, Global.GetLocalIPAddress(), myPortNumber);
                                client.GetStream().Write(pssp.ToBytes(), 0, pssp.ToBytes().Length);
                                Console.WriteLine("Serwer wyslal: " + pssp.ToString());
                                CallWindow callWindow = new CallWindow(receive_pssp.getIP(), port, pssp.getIP(), pssp.getPORT(), client);
                                callWindow.ShowDialog();
                                // w oknie rozmowy czeka na END
                                break;
                            }
                            // jeśli No to wyślij NACK
                            if (Global.CallAnswered == Global.AnswerType.NO)
                            {
                                pssp = new PSSP(PSSP.Type.NACK);
                                client.GetStream().Write(pssp.ToBytes(), 0, 34);
                                Global.Busy = false;
                                MainWindow.instance.UnlockUI();
                                client.Close();
                                break;
                            }
                            if(Global.CallAnswered == Global.AnswerType.NOINFO)
                            {
                                Global.Busy = false;
                                client.Close();
                                break;
                            }
                        }
                        if (receive_pssp.getOP() == "END-")
                        {
                            // zakończ UDP
                            // wykonuje się w oknie rozmowy
                            Global.Busy = false;
                            client.Close();
                            break;
                        }
                        Array.Clear(buffer, 0, buffer.Length);
                    }
                    else
                    {
                        pssp = new PSSP(PSSP.Type.BUSY);
                        client.GetStream().Write(pssp.ToBytes(), 0, 33);
                        Console.WriteLine("Wysłano BUSY do {0}", client.Client.RemoteEndPoint.ToString());
                        Global.AddtoHistory(new HistoryRecord(new Contact("Me", Global.GetLocalIPAddress()).ToString(), "<-", new Contact(Global.GetContactName(receive_pssp.getIP()), receive_pssp.getIP()).ToString(), DateTime.Now, "00:00:00", "Missed"));
                        client.Close();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                client.Close();
                Global.Busy = false;
                Console.WriteLine("Zamknieto klienta");
            }
        }
        public void Stop()
        {
            thread.Abort();
        }
        // Used if caller has same port like us
        private static int RandomPort(int port)
        {
            int newPort = rand.Next(49152, 65536);
            if (newPort == port)
            {
                return RandomPort(port);
            }
            return newPort;
        }
    }
}