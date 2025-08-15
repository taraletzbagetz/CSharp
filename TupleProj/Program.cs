using Microsoft.Win32.SafeHandles;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace TupleProj
{
    public class Program
    {
        static void Main(string[] args)
        {
            (double, int) t1 = (4.5, 3);
            Console.WriteLine($"Tuple with elements {t1.Item1} and {t1.Item2}");

            (double Sum, int Count) t2 = (4.5, 3);
            Console.WriteLine($"Sum of {t2.Count} element is {t2.Sum}.");

            int[] ys = new int[] { -9, 0, 67, 100 };

            var (minimum, maximum) = FindMinMax(ys);
            Console.WriteLine($"Limits of [{string.Join(" ", ys)} are {minimum} and {maximum}]");

            var t = (Sum: 4.5, Count: 3);
            Console.WriteLine($"Sum of {t.Count} element is {t.Sum}.");

            (double Sum, int Count) d = (4.5, 3);
            Console.WriteLine($"Sum of {d.Count} element is {d.Sum}.");


            var sum = 4.5;
            var count = 3;
            var t3 = (sum, count);
            Console.WriteLine($"Sum of {t3.count} element is {t3.sum}");

            var a = 1;
            var t4 = (a, b: 2, 3, "test");
            Console.WriteLine($"The 1st element is {t4.Item1} (same as {t4.a}).");
            Console.WriteLine($"The 2nd element is {t4.Item2} (same as {t4.b}).");
            Console.WriteLine($"The 3rd element is {t4.Item3}.");
            Console.WriteLine($"The 4th element is {t4.Item4}.");

            //TUPLE as Parameter
            DisplayTuple((1, "Bill", "Gates"));


            //TUPLE as a Return Type
            var person = GetPerson();
            Console.WriteLine($"My name is {person.FirstName} {person.LastName}, Id No. {person.Id}");


            //List of test
            List<(string prop, bool asc)> test = new List<(string prop, bool asc)>();

            test.Add(("id", true));
            test.Add(("name", false));

            foreach (var item in test) {
                Console.WriteLine(item.prop);
                Console.WriteLine(item.asc);
            }

        }


        static (int min, int max) FindMinMax(int[] input) {
            if (input is null || input.Length == 0) {
                throw new ArgumentException("Cannot find minimum and maximum of a null or empty array ");
            }

            var min = input.Min();
            var max = input.Max();

            foreach (var i in input)
            {
                if (i < min) { min = i; }
                if (i > max) { max = i; }
            }

            return (min, max);
        }

        static void DisplayTuple((int, string, string) person) { 
            Console.WriteLine("{0}, {1}, {2}", person.Item1, person.Item2, person.Item3);
        }

        static (int Id, string FirstName, string LastName) GetPerson() {
            return (Id: 1, FirstName: "Bill", LastName: "Gates");
        }
    }
}
