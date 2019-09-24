using P2P_Caller.Windows;
using System;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows;

namespace P2P_Caller.Utils.Network
{
    class MyTcpClient
    {
        public SoundPlayer sp = new SoundPlayer();
        string callIPAddress;
        static Random rand = new Random();
        static int myPort;
        Thread thread;
        static PSSP recvPSSP;
        static PSSP sentPSSP;
        public static TcpClient client;

        public MyTcpClient(string callIP)
        {
            sp.SoundLocation = "ring.wav";
            callIPAddress = callIP;
            thread = new Thread(Start);
            thread.IsBackground = true;
            thread.Start();
        }

        public void Start()
        {
            try
            {
                Global.Busy = true;
                Global.dir = "->";
                // Create a TcpClient.
                IPAddress ip = IPAddress.Parse(callIPAddress);
                IPEndPoint address = new IPEndPoint(ip, 16000);
                client = new TcpClient(callIPAddress, 16000);
                sp.Play();
                myPort = RandomPort();

                // Get a client stream for reading and writing.
                NetworkStream stream = client.GetStream();

                //  Send the message to the connected TcpServer. 
                sentPSSP = new PSSP(PSSP.Type.CALL, Global.GetLocalIPAddress(), myPort);
                Byte[] data = sentPSSP.ToBytes();
                stream.Write(data, 0, data.Length);

                // Buffer to store the response bytes
                data = new Byte[1024];
                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                int bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                recvPSSP = new PSSP(data);
                sp.Stop();
                //  Checking if other user has answered or rejected our call
                if (recvPSSP.getOP() == "ACK-")
                {
                    MainWindow.instance.Invoke((System.Windows.Forms.MethodInvoker)delegate { MainWindow.instance.DisableTimer(); MainWindow.instance.LockUI('l'); });
                    CallWindow callWindow = new CallWindow(recvPSSP.getIP(), recvPSSP.getPORT(), sentPSSP.getIP(), myPort, client);
                    callWindow.ShowDialog();

                }
                else
                {
                    MainWindow.instance.Invoke((System.Windows.Forms.MethodInvoker)delegate { MainWindow.instance.UnlockUI(); });
                    Global.Busy = false;
                    Global.AddtoHistory(new HistoryRecord(new Contact("Me", Global.GetLocalIPAddress()).ToString(), "->", new Contact(Global.GetContactName(callIPAddress), callIPAddress).ToString(), DateTime.Now, "00:00:00", "Missed"));
                    if (recvPSSP.getOP() == "BUSY")
                        MessageBox.Show(string.Format("{0} is busy!", Global.GetContactName(callIPAddress)));
                    if (recvPSSP.getOP() == "NACK")
                        MessageBox.Show(string.Format("{0} rejected the call!", Global.GetContactName(callIPAddress)));
                }
                stream.Close();
                client.Close();
            }
            catch (SocketException se)
            {
                Global.Busy = false;
                if(MainWindow.locked)
                    MessageBox.Show(string.Format("{0} is unavailable!", Global.GetContactName(callIPAddress)));
                MainWindow.instance.Invoke((System.Windows.Forms.MethodInvoker)delegate { MainWindow.instance.DisableTimer(); MainWindow.instance.UnlockUI(); });
            }
            catch (Exception e)
            {
                Global.Busy = false;
                Console.WriteLine(e);
            }
        }
        public void Stop()
        {
            thread.Abort();
        }
        private int RandomPort()
        {
            return rand.Next(49152, 65536);
        }
    }
}
