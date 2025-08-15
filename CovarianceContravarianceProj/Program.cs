namespace CovarianceContravarianceProj
{
    public delegate Small covarDel(Big mc);
    internal class Program
    {
        static void Main(string[] args)
        {
            covarDel del = Method1;

            del = Method2;


            //error
            //del = Method3;



        }

        public static Big Method1(Small sm) { 
            Console.WriteLine("Method 1");

            return new Big();
        }

        public static Bigger Method2(Big bg) { 
            Console.WriteLine("Method 2");
            return new Bigger();
        }

        public static Small Method3(Bigger bgr)
        {
            Console.WriteLine("Method 3");
            return new Small();
        }
    }

    public class Small { }

    public class Big: Small { }

    public class Bigger: Big { }
}
