namespace CovarianceDelegateProj
{
    //use as a type
    public delegate Small covarDel(Big mc);
    public delegate Big covarDelBig(Big mc);

    internal class Program
    {
        static void Main(string[] args)
        {
            covarDel del1, del2;

            covarDelBig del3;

            del1= Method1;
            Small sm1 = del1(new Big());

            del2 = Method2;
            Small sm2 = del2(new Big());

            del3 = Method3;
            Small sm3 = del3(new Big());

            //error
            //del3 = Method2;
        }

        public static Big Method1(Big big) {
            Console.WriteLine("Method 1");

            return new Big();
        }

        public static Small Method2(Big big) {

            Console.WriteLine("Method 2");

            return new Small();
        }


        public static Bigger Method3(Big big)
        {
            Console.WriteLine("Method 3");

            return new Bigger();
        }


    }


    public class Small { }

    public class Big: Small { }

    public class Bigger : Big { }
}
