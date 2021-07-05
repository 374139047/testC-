using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Chat1.bll
{
    class Server
    {
        public TcpListener ListenObj;
        public Dictionary<string,TcpClient> clientMem = new Dictionary<string, TcpClient>(); 
        private Thread listenThread;
        public delegate void ConnectDelegate(); 
        public event ConnectDelegate ConnectEvent;
        public delegate void ReceiveDelegate(string message);
        public event ReceiveDelegate ReceiveEvent;

        public delegate void receiveDelegates(string receiveDatas); 
        public event receiveDelegates receiveEvent;

        public void Listen(int port) 
        {
            IPAddress[] localIp = Dns.GetHostAddresses(Dns.GetHostName()); 
            ListenObj = new TcpListener(localIp[1],port);
            listenThread = new Thread(ListenClient);   
            listenThread.Start();
        }

        private void ListenClient()
        {
            while (true)      
            {
                ListenObj.Start();
                TcpClient acceptClientObj = ListenObj.AcceptTcpClient(); 
                this.ConnectEvent();

                Thread receiveThread = new Thread(Receiver); 
                string connectTime = DateTime.Now.ToString();
                receiveThread.Name = connectTime;
                clientMem.Add(connectTime,acceptClientObj);  

                receiveThread.Start();
            }
        }

        private void ListenStop()
        {
            Thread receiveThread = new Thread(Receiver);
                receiveThread.Abort();
            ListenObj.Stop();
        }

        private void Receiver()
        {   
            while (true)
            {
                NetworkStream ns = clientMem[Thread.CurrentThread.Name].GetStream();

                StreamReader sr = new StreamReader(ns);

                string message = sr.ReadLine();

                ReceiveEvent(message);


            }
        }

        public void Send(string message)
        {
            foreach (KeyValuePair<string, TcpClient> keyValuePair in clientMem)   
            {
                if (keyValuePair.Value == null || keyValuePair.Value.Connected ==false)
                {
                    clientMem.Remove(keyValuePair.Key);   
                    
                }
                if (keyValuePair.Value != null)
                {
                    NetworkStream ns = keyValuePair.Value.GetStream(); 
                    StreamWriter sw = new StreamWriter(ns);
                    sw.WriteLine(message);

                    sw.Flush(); 
                    ns.Flush();
                }
            }
        }


       
    }
}
