namespace PredicateDelegateProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isUpper = IsUpperCase;
            bool result = isUpper("hello world");

            Console.WriteLine(result);

            //anonymous: Delegate
            Predicate<string> isUpperDelegate = delegate (string s)
            {
                return s.Equals(s.ToUpper());
            };

            result = isUpperDelegate("Hello, World!");

            Console.WriteLine(result);

            //anonymous: Lambda
            Predicate<string> isUpperLambda = (string s) => s.Equals(s.ToUpper());

            result = isUpperLambda("HELLO, WORLD!");

            Console.WriteLine(result);

            result = PredicateAsParameter(isUpperLambda);
        }

        public static bool IsUpperCase(string s)
        {
            return s.Equals(s.ToUpper());
        }

        public static bool PredicateAsParameter(Predicate<string> input) { 

            return input("hello");
        }
    }
}
