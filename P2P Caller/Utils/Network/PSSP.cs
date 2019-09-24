using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PSSP
{
    public enum Type : ushort { CALL = 1, ACK, NACK, BUSY, END };
    private string OP;
    private string DATA;

    public PSSP()
    {
        this.OP = "";
        this.DATA = "";
    }
    public PSSP(string data)
    {
        this.OP = data.Substring(0, 4);
        this.DATA = data.Substring(5, data.Length - 5);
    }
    public PSSP(byte[] buffer)
    {
        string data = ASCIIEncoding.ASCII.GetString(buffer);

        this.OP = data.Substring(0, 4);
        this.DATA = data.Substring(5, data.Length - 5);
    }

    // For calling, answering call
    public PSSP(Type t, string ip, int port)
    {
        if (t == Type.CALL)
        {
            this.OP = "CALL";
            this.DATA = "IP=" + Global.PSSP_IP(ip) + "?PORT=" + port.ToString();    // 3 + 15 + 6 + 5 = 29
        }
        if (t == Type.ACK)
        {
            this.OP = "ACK-";
            this.DATA = "IP=" + Global.PSSP_IP(ip) + "?PORT=" + port.ToString();
        }
    }

    // For refusing calls
    public PSSP(Type t)
    {
        if (t == Type.NACK)
        {
            this.OP = "NACK";
            this.DATA = "I DO NOT WANT TO TALK TO YOU.";    // 29
        }
        if (t == Type.BUSY)
        {
            this.OP = "BUSY";
            this.DATA = "I AM BUSY. CALL ME LATER THX.";    // 29
        }
        if (t == Type.END)
        {
            this.OP = "END-";
            this.DATA = "THANKS FOR NICE CONVERSATION!";    // 29
        }
    }

    public string getOP()
    {
        return this.OP;
    }
    public string getDATA()
    {
        return this.DATA;
    }
    public string getIP()
    {
        string IP = string.Empty;
        if (this.OP == "ACK-" || this.OP == "CALL")
        {
            for (int i = 3; i < this.DATA.Length; i++)
            {
                if (this.DATA[i] != '?')
                    IP += this.DATA[i];
                else
                    break;
            }
        }
        return Global.TCP_IP(IP);
    }
    public int getPORT()
    {
        string PORT = string.Empty;
        int port = 0;
        bool tn = false;
        if (this.OP == "ACK-" || this.OP == "CALL")
        {
            for (int i = 0; i < this.DATA.Length; i++)
            {
                if (tn)
                {
                    PORT += this.DATA[i];
                }
                if (this.DATA[i] == '?')
                {
                    tn = true;
                    i += 5;
                }
            }
            port = Convert.ToInt32(PORT);
        }
        return port;
    }
    public override string ToString()
    {
        return this.OP + "|" + this.DATA;
    }
    public byte[] ToBytes()
    {
        return Encoding.ASCII.GetBytes(this.ToString());
    }
}
