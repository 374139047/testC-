using System;
using System.Collections;

public class MyClass
{
	public static void Main()
	{
		
		string s = " asdf    fasdf fasdf ";
		Console.WriteLine("before:");
		Console.WriteLine(s);

		Space( ref s );
		Console.WriteLine("after:");
		Console.Write(s);
		Console.ReadLine();
		
	}

	private static void Space( ref string str )
	{
		int index = str.IndexOf(' ');
		if( index >= 0 && index <= str.Length-1 )
		{
			try
			{
				string start = str.Substring( 0, index ).Trim();
				string end   = str.Substring( index+1, (str.Length-index-1 )).Trim();
				Space( ref start );
				Space( ref end );
				str = start + end;
			}
			catch( Exception e )
			{
				Console.Write(e.Message);
			}
		}
	}

	
}
