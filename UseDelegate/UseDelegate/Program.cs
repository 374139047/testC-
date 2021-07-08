using System;
using System.Collections.Generic;
using System.Text;

namespace UseDelegate
{
    delegate void MyDelegate(string s);

    class MyClass
    {
        public static void Hello(string s)
        {
            Console.WriteLine("您好, {0}!", s);
        }
        public static void Goodbye(string s)
        {
            Console.WriteLine("再见, {0}!", s);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate a, b, c, d;
            a = MyClass.Hello ;
            Console.WriteLine("调用委托变量 a:");
            a("a"); 

            b = MyClass.Goodbye;
            Console.WriteLine("调用委托变量 b:");
            b("b");

            c = a + b;
            Console.WriteLine("调用委托变量 c:");
            c("c=a+b"); 

            d = c - a;     
            Console.WriteLine("调用委托变量 d:");
            d("d=c-a");

            Console.ReadKey();
        }
    }
}
