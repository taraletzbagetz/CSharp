namespace MulticastDelegateProj
{
    //declaring a delegate
    public delegate void MyDelegate(string msg);
    public delegate int IntDelegate();
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDelegate del, del1, del2, del3;

            del1 = ClassA.MethodA;
            del2 = ClassB.MethodB;

            del = del1 + del2;
            del("Hello World");

            del3 = (string msg) => Console.WriteLine($"Called a lambda expression: {msg}.");
            del += del3;
            del("Hello World");

            del = del - del2;
            del("Hello Mars");

            del -= del1;
            del("Hello Jupiter");


            IntDelegate delInt, delInt1, delInt2; 

            delInt1 = ClassAA.MethodAA;
            delInt2 = ClassBB.MethodBB;

            Console.WriteLine(delInt1());
            Console.WriteLine(delInt2());

            delInt = delInt1 + delInt2;
            Console.WriteLine(delInt()); //for delegates that are returning values only the last one is being displayed

        }
    }

    public class ClassA {
        public static void MethodA(string message) { 
            Console.WriteLine($"Called ClassA.MethodA() with parameter: {message}.");
        }
    }

    public class ClassB
    {
        public static void MethodB(string message)
        {
            Console.WriteLine($"Called ClassB.MethodB() with parameter: {message}.");
        }
    }


    public class ClassAA
    {
        public static int MethodAA()
        {
            return 100;
        }
    }

    public class ClassBB
    {
        public static int MethodBB()
        {
            return 200;
        }
    }
}
