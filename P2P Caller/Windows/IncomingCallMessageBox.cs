using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2P_Caller.Windows
{
    public partial class IncomingCallMessageBox : Form
    {
        private string ip;
        SoundPlayer sp = new SoundPlayer();

        Thread recvCli;

        public IncomingCallMessageBox(string ip, TcpClient client)
        {
            InitializeComponent();
            Global.CallAnswered = Global.AnswerType.NOINFO;
            label1.Text = Global.GetContactName(ip);
            sp.SoundLocation = "phone.wav";
            sp.Play();
            this.ip = ip;

            recvCli = new Thread(() => tcp_recv(client, this));
            recvCli.IsBackground = true;
            recvCli.Start();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            Global.CallAnswered = Global.AnswerType.YES;
            sp.Stop();
            this.Close();
        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            Global.CallAnswered = Global.AnswerType.NO;
            sp.Stop();
            MainWindow.instance.Invoke((MethodInvoker)delegate { MainWindow.instance.UnlockUI(); });
            Global.AddtoHistory(new HistoryRecord(new Contact("Me", Global.GetLocalIPAddress()).ToString(), Global.dir, new Contact(Global.GetContactName(Global.remoteAddress), Global.remoteAddress).ToString(), DateTime.Now, "00:00:00", "Missed"));
            this.Close();
        }
        static void tcp_recv(TcpClient cli, IncomingCallMessageBox icmb)
        {
            try
            {
                byte[] buffer = new byte[1024];
                PSSP pssp;
                while (true)
                {
                    cli.GetStream().Read(buffer, 0, 34);
                    pssp = new PSSP(buffer);
                    if (Global.CallAnswered == Global.AnswerType.NO || Global.CallAnswered == Global.AnswerType.YES)
                        break;
                    if (pssp.getOP() == "END-")
                    {
                        icmb.sp.Stop();
                        Global.AddtoHistory(new HistoryRecord(new Contact("Me", Global.GetLocalIPAddress()).ToString(), Global.dir, new Contact(Global.GetContactName(Global.remoteAddress), Global.remoteAddress).ToString(), DateTime.Now, "00:00:00", "Missed"));
                        MainWindow.instance.Invoke((MethodInvoker)delegate { MainWindow.instance.UnlockUI(); });
                        icmb.Invoke((MethodInvoker)delegate { icmb.Close(); });
                        Global.Busy = false;
                        MessageBox.Show(string.Format("Missed call from {0}", Global.GetContactName(Global.remoteAddress)));
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
