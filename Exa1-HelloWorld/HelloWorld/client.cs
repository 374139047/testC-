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
			Console.WriteLine("����.....");
			
			tcpclnt.Connect("127.0.0.1",8001);
			Console.WriteLine("������");
			Console.Write("������Ҫ������ַ��� : ");
			
			String str=Console.ReadLine();
			Stream stm = tcpclnt.GetStream();
			
			ASCIIEncoding asen= new ASCIIEncoding();
			byte[] ba=asen.GetBytes(str);
			Console.WriteLine("������.....");			
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