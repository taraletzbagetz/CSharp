using System.Runtime.CompilerServices;

namespace NumberToWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int x = 123;

            Console.WriteLine(x.ToWords());
        }
    }


    public static class Utility{
        public static String ToWords(this int input)
        {
            String output = "";

            output = NumberToWords(input);

            return output;
        }

        public static String NumberToWords(int input) {
            String output = "";

            if ((input / 100) > 0) {
                output += NumberToWords(input / 100) + " hundred";
                //words += NumberToWords(number / 100) + " hundred ";
                /*
                https://stackoverflow.com/questions/2729752/converting-numbers-in-to-words-c-sharp
                */
                input %= 100;
            }

            if (input > 0)
            {
                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (input < 20)
                {
                    output += unitsMap[input];
                }
                else {

                    output += tensMap[input/10];

                    if ((input % 10) > 0) {
                        output += unitsMap[input % 10];
                    }
                }
            }

            

            return output;
        }
    }

    
}
