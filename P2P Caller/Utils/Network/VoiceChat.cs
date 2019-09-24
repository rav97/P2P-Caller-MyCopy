using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P2P_Caller.Utils.Network
{
    static class VoiceChat
    {
        static string remoteAddress;
        static int remotePort;

        static string localAddress;
        static int localPort;

        static Thread recieve_thread;
        static Byte[] incoming;
        static MemoryStream sound;
        static WaveIn waveIn;
        static WaveOut waveOut;
        static WaveFileWriter waveWriter;

        static UdpClient sendr = new UdpClient();
        static UdpClient receiver;

        public static void Start(string remoteAddress, int remotePort, string localAddress, int localPort)
        {
            #region NAudio-staff
            waveIn = new WaveIn();
            waveIn.BufferMilliseconds = 100;
            waveIn.NumberOfBuffers = 10;
            waveOut = new WaveOut();

            waveIn.DeviceNumber = 0;
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.WaveFormat = new WaveFormat(44200, 2);
            waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(waveIn_RecordingStopped);

            sound = new MemoryStream();
            waveWriter = new WaveFileWriter(sound, waveIn.WaveFormat);
            #endregion


            VoiceChat.remoteAddress = remoteAddress;
            VoiceChat.remotePort = remotePort;

            VoiceChat.localAddress = localAddress;
            VoiceChat.localPort = localPort;

            recieve_thread = new Thread(recv);
            recieve_thread.Start();

            waveIn.StartRecording();
        }

        static void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            sendr.Send(e.Buffer, e.Buffer.Length, remoteAddress, remotePort);
        }
        static void waveIn_RecordingStopped(object sender, EventArgs e)
        {
            waveIn.Dispose();
            waveIn = null;
        }
        static void recv()
        {
            receiver = new UdpClient(localPort);
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
    }

}
