using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

public class client 
{
    public static void Main() 
    {
        try 
        {
			TcpClient tcpclnt = new TcpClient();
			Console.WriteLine("连接.....");
			
			tcpclnt.Connect("127.0.0.1",8001);
			Console.WriteLine("已连接");
			Console.Write("请输入要传输的字符串 : ");
			
			String str=Console.ReadLine();
			Stream stm = tcpclnt.GetStream();
			
			ASCIIEncoding asen= new ASCIIEncoding();
			byte[] ba=asen.GetBytes(str);
			Console.WriteLine("传输中.....");			
			stm.Write(ba,0,ba.Length);
			
			byte[] bb=new byte[100];
			int k=stm.Read(bb,0,100);
			
            for (int i=0;i<k;i++)
            {
                Console.Write(Convert.ToChar(bb[i]));
            }
			
			tcpclnt.Close();
		}		
		catch (Exception e) 
        {
			Console.WriteLine("Error..... " + e.StackTrace);
		}

		   Console.ReadLine();
	}
}