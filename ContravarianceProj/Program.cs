using System.Numerics;

namespace ContravarianceProj
{
    public delegate Small covarDel(Big mc);

    internal class Program
    {
        static void Main(string[] args)
        {
            covarDel del;

            del = Method1;

            del += Method2;

            del += Method3;

            //Test
            //Another Test
            //Another Push
            //another push
            //push it too
            //push it three
            //del += Method4;

            Small sm = del(new Big());
        }

        public static Big Method1(Big ig) {
            Console.WriteLine("Method 1");

            return new Big();
        }

        public static Small Method2(Big bg) {
            Console.WriteLine("Method 2");

            return new Small();
        }

        public static Small Method3(Small sml)
        {
            Console.WriteLine("Method 3");

            return new Small();
        }

        public static Small Method4(Bigger bgr)
        {
            Console.WriteLine("Method 4");

            return new Small();
        }
    }

    public class Small { }

    public class Big: Small { }

    public class Bigger: Big { }
}
