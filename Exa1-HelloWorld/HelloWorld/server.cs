using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class server
{
    public static void Main() 
    {
        try 
        {
            IPAddress ipAd = IPAddress.Parse("127.0.0.1");
            
            TcpListener myList=new TcpListener(ipAd,8001);
            
            myList.Start();

            Console.WriteLine("�����˿ڷ���...");	
            Console.WriteLine("���ؽڵ�Ϊ:" + myList.LocalEndpoint );
            Console.WriteLine("�ȴ�����.....");
            
            Socket s=myList.AcceptSocket();
            Console.WriteLine("�������� "+s.RemoteEndPoint);
            
            byte[] b=new byte[100];
            int k=s.Receive(b);
            Console.WriteLine("�ѽ���...");
            for (int i=0;i<k;i++)
            {
                Console.Write(Convert.ToChar(b[i]));
            }
            
            ASCIIEncoding asen=new ASCIIEncoding();
            s.Send(asen.GetBytes("The string was recieved by the server."));
            Console.WriteLine("\n�ѷ��ͻ�Ӧ��Ϣ");
            
            s.Close();
            myList.Stop();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error..... " + e.StackTrace);
        }	
        Console.ReadLine();

    }
}
