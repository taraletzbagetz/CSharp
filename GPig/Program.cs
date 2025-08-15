using System.Globalization;
using System.Linq.Expressions;

namespace GPig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            List<Person> list = new List<Person> { 
                new Person { Id = 1, Name = "a"},
                new Person { Id = 2, Name = "b" },
                new Person { Id = 3, Name = "c" },
                new Person { Id = 4, Name = "d" },
                new Person { Id = 5, Name = "e" },
                new Person { Id = 6, Name = "f" },
                new Person { Id = 7, Name = "g" },
                new Person { Id = 8, Name = "h" },
                new Person { Id = 9, Name = "i" },
                new Person { Id = 10, Name = "j" }
            };

            foreach (var item in list) {
               var output = item.ProcessName("Test");

                output.ProcessName = "Test B";
            }


            Person per = null;

            int? count = null;

            if (per is not { })
            {
                Console.WriteLine($"{nameof(per)} is null: {nameof(UtilityTest)}");

            }
            else {
                Console.WriteLine($"{nameof(per)} is the other way around: {nameof(UtilityTest)}");
            }


            if (count is not { })
            {
                Console.WriteLine($"{nameof(count)} is null: {nameof(UtilityTest)}");
            }
            else {
                Console.WriteLine($"{nameof(per)} is the other way around: {nameof(UtilityTest)}");
            }


            String s = null;

            String upc = "UPC";
            String ean = "";
            String outputTest = "";

            ean = "EAN";
            upc = null;


            outputTest = (upc ?? "") == "" ? ean : upc;

            Console.WriteLine(outputTest);



            Console.WriteLine("tgegggggagadsad");
            String s2 = "http://test.com/{0}";

            String s3 = string.Format(s2, "yeba");

            Console.WriteLine(s3);


        }
        
    }

    public static class UtilityTest {
        public static Person ProcessName(this Person item, string inputName) {

            item.ProcessName = inputName;
            return item;
        }

        public static Person CopyPerson(this Person item, Person input)
        {
            item = input;
            return item;
        }

        public static Person CopyPerson(this Person item)
        {
            return item;
        }
        
        public static void swap(Person p1, Person p2) {
            Person temp = p1;
            p1 = p2;
            p2 = p1;
        }
    }

    public class Person {
        public int Id { get; set; }

        public String Name { get; set; }

        public String ProcessName { get; set; }

    }

    public class TestDesign
    {

        CultureInfo culture = new CultureInfo("en-US");

        private Func<string, bool> Test(string value) => author => "s" == "s";

        //private Func<string, bool> Test1 => value => author => true;

        Func<string, bool> statX = x => true;

        Func<int, int, int> addLamda = (x, y) => x + y;

        

        public void Test() {
            statX("");
        }

        public void AnotherTest(Func<string, bool> s) {
            bool check = s("");


        }
    }
}
