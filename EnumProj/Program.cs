namespace EnumProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Test.AAA);

            Test s = Test.AAA;

            String x = Test.AAA.ToString();

            Console.WriteLine(x);

            if (s == Test.AAA)
            {
                Console.WriteLine(true);
            }
        }
    }

    enum Test { 
        AAA,
        BBB,
        CCC
    }
}
