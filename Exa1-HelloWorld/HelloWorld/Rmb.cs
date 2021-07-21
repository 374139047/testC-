using System; 
 
class RenminbiUper 
{ 
	static string[] UperMoney={"","Ҽ","��","��","��","��","½","��","��","��"}; 
	static string[] Digit={"","","ʰ","��","ǧ"}; 
	static string[] Ling={"","��"}; 
	static string[] Wan={"","��"}; 
	static string[] Yi={"","��"}; 
       
	public static void toUper(System.Decimal num) 
	{ 
		char[] moneyNumber;
		if(num<1)
		{moneyNumber=("0"+num.ToString(".00")).ToCharArray(); }
		else
		moneyNumber=(num.ToString(".00")).ToCharArray(); 
		Console.WriteLine(moneyNumber);
		
		int length=moneyNumber.Length; 
		int curDigit;
		int curValue; 
		int perValue=1; 
		int indexOfDigit; 
		int perValueIsZero;  
 
		int isWan=0; 

		int isYi=0; 

		string Yuan=""; 
		bool flag=false; 


		if(moneyNumber[0]!='0')
		{
			for(int i=0;i<length-3;i++) 
			{ 
				perValueIsZero=0; 
				curDigit=length-3-i; 
				if(curDigit<9) 
					isYi=0; 
				if(curDigit<5||(curDigit<13&&curDigit>8)) 
				{ 
					flag=false; 
					isWan=0; 
				} 
				if(i>0&&perValue==0) 
					perValueIsZero=1; 
				if(curDigit<5) 
					indexOfDigit=curDigit%5; 
				else if(curDigit<9) 
				{ 
					indexOfDigit=(curDigit-4)%5; 
				} 
				else if(curDigit<=13) 
					indexOfDigit=(curDigit-8)%5; 
				else  
					indexOfDigit=(curDigit-12)%5; 
				curValue=Convert.ToInt32(moneyNumber[i].ToString()); 
				if((curDigit>=5&&curDigit<9||curDigit>12)&&flag==false) 
				{ 
					flag=curValue==0&&length>11?false:true; 
				} 
				if(curDigit==5||curDigit==13||curDigit==9) 
				{ 
					if(flag) 
						isWan=1; 
					if(curValue==0) 
						perValueIsZero=0; 
				} 
				if(curDigit==9) 
					isYi=1; 
				perValue=curValue; 
				if(  curValue!=0||(curValue==0&&(curDigit==5||curDigit==13||curDigit==9))  ) 
				{ 
					Yuan+=Ling[perValueIsZero]+UperMoney[curValue]+Digit[indexOfDigit]+Wan[isWan]+Yi[isYi]; 
				} 
			} 
			Yuan+="Ԫ"; 

		
			if(moneyNumber[length-1]=='0'&&moneyNumber[length-2]=='0') 
				Yuan+="��"; 
			else 
			{ 
				if(moneyNumber[length-4]=='0') 
					Yuan+="��"; 
				if(moneyNumber[length-1]=='0') 
					Yuan+=UperMoney[Convert.ToInt32(moneyNumber[length-2].ToString())]+"��"; 
				else if(moneyNumber[length-2]=='0') 
				{ 
					if(moneyNumber[length-4]!='0') 
						Yuan+="��"; 
					Yuan+=UperMoney[Convert.ToInt32(moneyNumber[length-1].ToString())]+"��"; 
				} 
				else 
					Yuan+=UperMoney[Convert.ToInt32(moneyNumber[length-2].ToString())]+"��"+UperMoney[Convert.ToInt32(moneyNumber[length-1].ToString())]+"��"; 
			} 
		}
		else
		{
			if(moneyNumber[length-4]=='0') 
				Yuan+=""; 
			if(moneyNumber[length-1]=='0') 
				Yuan+=UperMoney[Convert.ToInt32(moneyNumber[length-2].ToString())]+"��"; 
			else if(moneyNumber[length-2]=='0') 
			{ 
				if(moneyNumber[length-4]!='0') 
					Yuan+=""; 
				Yuan+=UperMoney[Convert.ToInt32(moneyNumber[length-1].ToString())]+"��"; 
			} 
			else 
				Yuan+=UperMoney[Convert.ToInt32(moneyNumber[length-2].ToString())]+"��"+UperMoney[Convert.ToInt32(moneyNumber[length-1].ToString())]+"��"; 
			
		
		}
		Console.WriteLine(Yuan); 
	} 

	[STAThread] 
	static void Main(string[] args) 
	{ 
		System.Decimal d=0; 
		bool flag=true; 
		bool error=false; 
          
		do 
		{ 
			if(error) 
				System.Console.WriteLine("�����ʽ���ԣ����������룡"); 
			Console.Write("������ת������16λ����,0�˳�����"); 
			try 
			{ 
				d=Convert.ToDecimal(Console.ReadLine()); 
				Console.WriteLine(d);
				toUper(d); 
				error=false;
				break;
			} 
			catch
			{ 
				error=true; 
			} 
             
		}while(flag); 
		Console.ReadLine();
          
	} 

} 