using NAudio.Wave;
using P2P_Caller.Utils.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2P_Caller.Windows
{
    public partial class CallWindow : Form
    {
        private int ticks;
        static string calltime;

        static Thread recieve_thread;
        static Byte[] incoming;
        static MemoryStream sound;
        static WaveIn waveIn;
        static WaveOut waveOut;
        static WaveFileWriter waveWriter;

        static UdpClient sendr = new UdpClient();
        static UdpClient receiver;

        TcpClient tcpcli;
        Thread recvCli;

        public CallWindow(string remoteAddress, int remotePort, string localAddress, int localPort, TcpClient client)
        {
            InitializeComponent();

            IPContactLabel.Text = Global.GetContactName(remoteAddress);
            tcpcli = client;

            recvCli = new Thread(() => tcp_recv(tcpcli, this));
            recvCli.IsBackground = true;
            recvCli.Start();

            #region NAudio-staff
            waveIn = new WaveIn();
            waveIn.BufferMilliseconds = 100;
            waveIn.NumberOfBuffers = 10;
            waveOut = new WaveOut();
            waveOut.DeviceNumber = Global.OutAudioDeviceNumber;

            waveIn.DeviceNumber = Global.InAudioDeviceNumber;
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.WaveFormat = new WaveFormat(44200, 2);
            waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(waveIn_RecordingStopped);

            sound = new MemoryStream();
            waveWriter = new WaveFileWriter(sound, waveIn.WaveFormat);
            #endregion


            Global.remoteAddress = remoteAddress;
            Global.remotePort = remotePort;

            Global.localAddress = localAddress;
            Global.localPort = localPort;

            recieve_thread = new Thread(recv);
            recieve_thread.IsBackground = true;
            recieve_thread.Start();

            waveIn.StartRecording();
        }

        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            sendr.Send(e.Buffer, e.Buffer.Length, Global.remoteAddress, Global.remotePort);
        }
        void waveIn_RecordingStopped(object sender, EventArgs e)
        {
            waveIn.Dispose();
            waveIn = null;
        }
        static void recv()
        {
            receiver = new UdpClient(Global.localPort);
            IPEndPoint remoteIp = null;

            BufferedWaveProvider PlayBuffer = new BufferedWaveProvider(waveIn.WaveFormat);
            waveOut.Init(PlayBuffer);
            waveOut.Play();

            while (true)
            {
      
                incoming = receiver.Receive(ref remoteIp);
                PlayBuffer.AddSamples(incoming, 0, incoming.Length);
            }
        }
        static void tcp_recv(TcpClient cli, CallWindow cw)
        {
            try
            {
                byte[] buffer = new byte[1024];
                PSSP pssp;
                while (true)
                {
                    cli.GetStream().Read(buffer, 0, 34);
                    pssp = new PSSP(buffer);
                    if (pssp.getOP() == "END-")
                    {
                        waveIn.StopRecording();
                        waveOut.Stop();
                        recieve_thread.Abort();
                        Global.Busy = false;
                        MainWindow.instance.Invoke((MethodInvoker)delegate { MainWindow.instance.UnlockUI(); });
                        cw.Invoke((MethodInvoker)delegate { cw.Close(); });
                        Global.AddtoHistory(new HistoryRecord(new Contact("Me", Global.GetLocalIPAddress()).ToString(), Global.dir, new Contact(Global.GetContactName(Global.remoteAddress), Global.remoteAddress).ToString(), DateTime.Now, calltime , "Answered"));
                        break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            ticks++;
            TimeSpan t = TimeSpan.FromSeconds(ticks);
            string time = t.ToString(@"hh\:mm\:ss");
            calltime = time;
            TimerLabel.Text = time;
        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            End();
            MainWindow.instance.Invoke((MethodInvoker)delegate { MainWindow.instance.UnlockUI(); });
        }
        public void End()
        {
            PSSP pssp = new PSSP(PSSP.Type.END);
            tcpcli.GetStream().Write(pssp.ToBytes(), 0, pssp.ToBytes().Length);
            tcpcli.GetStream().Write(pssp.ToBytes(), 0, pssp.ToBytes().Length);
            // wysylam 2 razy zeby zabic wątek w IncomingCallMessageBox
            Global.AddtoHistory(new HistoryRecord(new Contact("Me", Global.GetLocalIPAddress()).ToString(), Global.dir, new Contact(Global.GetContactName(Global.remoteAddress), Global.remoteAddress).ToString(), DateTime.Now, calltime, "Answered"));
            tcpcli.Close();
            recvCli.Abort();
            waveIn.StopRecording();
            waveOut.Stop();
            recieve_thread.Abort();
            Global.Busy = false;
            this.Close();
        }
    }
}
