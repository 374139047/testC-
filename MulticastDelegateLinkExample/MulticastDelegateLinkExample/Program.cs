using System;
using System.Collections.Generic;
using System.Text;

namespace MulticastDelegateLinkExample
{
    public delegate int MyDelegate(int value);

    public class A
    {
        public int f1(int i)
        {
            Console.WriteLine("f1.i={0}", i);
            return i;
        }
        public int f2(int i)
        {
            i *= 2;
            Console.WriteLine("f2.i={0}", i);
            return i;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            MyDelegate s1 = new MyDelegate(a.f1);
            s1 += new MyDelegate(a.f2);

            Delegate[] ds;
            
            ds = s1.GetInvocationList();
            Console.WriteLine("S1的方法调用列表中包含{0}个方法", ds.GetLength(0));

            s1(5); 

            MyDelegate s2 = new MyDelegate(a.f1);
            s2 += new MyDelegate(a.f2);

            Delegate mul;
            mul = s1 + s2;
            ds = mul.GetInvocationList();
            Console.WriteLine("mul的方法调用列表中包含{0}个方法", ds.GetLength(0));
            int ret = (mul as MyDelegate)(10);

            Console.WriteLine("ret={0}", ret);
            Console.ReadKey();
        }
    }
}
