using System; 

class MathClass

{

	public static int max(int a,int b)

	{
		return(a>b?a:b);
	}

	public static int min(int a,int b)

	{
		return(a<b?a:b);
	}

	public static int sub(int a,int b)

	{
		return (a+b);
	}

	public static int minus(int a,int b)

	{
		return (a-b);
	}

}

class Handler

{
	private delegate int Calculation(int a, int b);
	private static Calculation[] myCalculation=new Calculation[2];
	public static void EventHandler(int i,int a,int b)

	{

		switch (i)

		{
			case 1:
				myCalculation[0]=new Calculation(MathClass.max);
				myCalculation[1]=new Calculation(MathClass.min);
				Console.WriteLine(myCalculation[0](a,b));
				Console.WriteLine(myCalculation[1](a,b));
				break;

			case 2: 
				myCalculation[0]=new Calculation(MathClass.sub);
				myCalculation[1]=new Calculation(MathClass.minus);
				Console.WriteLine(myCalculation[0](a,b));
				Console.WriteLine(myCalculation[1](a,b));
				break;

			default:
				return;

		}

	}

}

class Test

{

	static void Main()

	{
		Handler.EventHandler(1,10,3);

		Handler.EventHandler(2,10,3);
		Console.ReadLine();

	}

}
