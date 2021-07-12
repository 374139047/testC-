using System;
public class myApp
{
	static void Main()
	{
		int a,b,c,d;
		for(a = 1;a < 40;a++)
			for(b = 1;b < 40;b++)
				for(c = 1;c < 40;c++)
					for(d = 1;d < 40;d++)
					{
						if(a + b + c + d == 40)
						{
							if(Check(a,b,c,d))
							{
								Console.WriteLine("{0}\t{1}\t{2}\t{3}",a,b,c,d);
							}
						}
					}

		Console.WriteLine("DONE");
		Console.ReadLine();
	}


	static bool Check(int a,int b,int c,int d)
	{
		int i,j,k,l;
		i = j = k = l = 0;
		for(int r = 1;r <= 40;r++)
		{
			for(i = -1;i <= 1;i++)
				for(j = -1;j <= 1;j++)
					for(k = -1;k <= 1;k++)
						for(l = -1;l <= 1;l++)
						{
							if(a*i + b*j + c*k + d*l == r)
								goto NextLoop;
						}
			return false;
		NextLoop:
			continue;
		}
		return true;
	}
}