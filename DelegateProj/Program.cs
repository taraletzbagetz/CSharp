namespace DelegateProj
{
    internal class Program
    {
        //declare delegate
        public delegate void MyDelegate(string msg);

        static void Main(string[] args)
        {
            //set target method
            MyDelegate del = new MyDelegate(MethodA);
            del("Hello World.");

            //set target method
            del = MethodA;
            del("Hello Mars");

            //set lambda
            del = (string msg)  => Console.WriteLine(msg);
            del("Hello Jupiter");

            //Passing Delegate as a Parameter
            del = ClassA.MethodA;
            InvokeDelegate(del);

            del = ClassB.MethodB;
            InvokeDelegate (del);

            del = (string msg) => Console.WriteLine (msg);
            InvokeDelegate(del);

        }

        static void MethodA(string message) { 
            Console.WriteLine(message);
        }

        static void InvokeDelegate(MyDelegate del) {
            del("Hello World");
        }
    }

    public class ClassA { 
        public static void MethodA(string message) {
            Console.WriteLine($"Called ClassA.MethodA() with parameter: {message}");
        }
    }

    public class ClassB
    {
        public static void MethodB(string message)
        {
            Console.WriteLine($"Called ClassB.MethodB() with parameter: {message}");
        }
    }
}
