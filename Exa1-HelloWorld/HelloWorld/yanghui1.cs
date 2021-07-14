using System;
using System.IO;
public class printandwritetofileofyh
{
	public static void Main()
	{
		StreamWriter sw;
		StreamReader inStr = null;
		string textLine = null;
		int[,] a = new int[10,10];
		a[0,0] = 1; 
		for(int i=1;i<10;i++)
		{
			a[i,0] = 1;
			a[i,i] = 1;
			for(int j=1;j<i;j++)
			{
				a[i,j]=a[i-1,j-1]+a[i-1,j];
			}
		}
		try 
		{
			sw=File.CreateText("yanghui.txt");
		}
		catch 
		{
			Console.WriteLine("File cannot be created!");
			return;
		}
		for(int i=0;i<10;i++)
		{
			for(int j=0;j<=i;j++)
			{
				sw.Write("{0} ",a[i,j]);
			}
			sw.WriteLine();  
		}
		sw.Close();
		FileInfo textFile = new FileInfo(@"yanghui.txt");
		inStr = textFile.OpenText();
		Console.WriteLine("\n Reading from text file: \n");
		textLine = inStr.ReadLine();
		while(textLine != null)
		{
		    Console.WriteLine(textLine);
            textLine = inStr.ReadLine();

		}
		inStr.Close();
		Console.ReadLine(); 
	}
}
