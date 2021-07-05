using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Chat.bll
{
    class Client
    {
        public TcpClient tcpClientObj; 
        private Thread receivetThread; 
        public delegate void receiveDelegate(string receiveData); 
        public event receiveDelegate receiveEvent;

        public void SendConnection(string ip, int port)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            tcpClientObj = new TcpClient(); 
            tcpClientObj.Connect(ipAddress,port); 

            receivetThread = new Thread(Reveiver);  
            receivetThread.Start();
        }

        public void StopConnection()
        {
           
            receivetThread.Abort();
        }

        private void Reveiver()
        {
            while (true)
            {
                NetworkStream ns = this.tcpClientObj.GetStream();

                StreamReader sr = new StreamReader(ns);
                string receivedata = sr.ReadLine();
                receiveEvent(receivedata); 
            }
        }

        public void Send(string message) 
        {
            if (tcpClientObj == null)
            {
                return;
            }
            NetworkStream ns = this.tcpClientObj.GetStream();   

            StreamWriter sw = new StreamWriter(ns);
            sw.WriteLine(message);
            sw.Flush();   
            ns.Flush();
        }

       
    }
}
