
using System ; 

public class M
{

	public static int sum;
	public M()
	{
		int sum =0;
		
	}
	
	public static void Output(int[] store2)
	{
		
		for(int i = 9; i>=0; --i)
		{
			Console.Write("   {0}",store2[i]);
			
		}
		Console.WriteLine();
		sum++;
				
	}
	
	public static int sum2()
	{
		return sum;
	}

	public  static void Cumput(int score, int num, int[] store2 )
	{
		
		if(score < 0 || score > (num+1)*10 ) 
		{ 
			return;
		}
		
		if(num == 0)  
		{
			store2[num] = score;
			Output( store2);
			return;
			
		}
		
		for(int i = 0; i <= 10; ++i)
		{
			store2[num] = i;
			Cumput(score - i, num - 1,store2);
		}
	}
}




public class myApp
{
	public static void Main( ) 
	{
		int[] store;
		store = new int[10]; 
		int sum = 0;
		//int a=90;
		//int b=9;
		//Output();
		M.Cumput(90,9,store);
		sum = M.sum2();
		
		//M.Cumput2(a,b,store);
		//Console.Write("   {0}",store[3]);
		//cout<<"总数:"<<sum<<endl;
		Console.Write(" 总数:   {0}",sum);
		Console.ReadLine();
		
	}
}