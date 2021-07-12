using System;


public class myApp
{
	public static void Main()
	{ 
		int randomum1 ,randomum2,flag=0;
		int[] a;
		int i,tmp,randtmp;
		 a = new int[52];
         
        
		for(i=1;i<=52;i++)
		{
		    a[i-1] = i;
		}

		Random r1 = new Random();
		
		for(i=0;i<52;i++) 
		{ 
			randtmp = (int)(52*r1.NextDouble());
			
			tmp=a[i]; 
			a[i]=a[randtmp]; 
			a[randtmp]=tmp; 
		} 
		
		for(i=0;i<52;i++) 
			Console.Write("   {0}",a[i]);
		Console.ReadLine();
		

	}
}