using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P_Caller.Utils.Network
{
    class NetworkManager
    {
        private string myAddress;

        private MyTcpListener myTcpListener;
        private MyTcpClient myTcpClient;


        public NetworkManager()
        {
            this.myAddress = Global.GetLocalIPAddress();

            //this.myTcpListener = new MyTcpListener();
            
        }

    }
}
