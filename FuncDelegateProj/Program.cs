namespace FuncDelegateProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> add = Sum;

            int result = add(10, 20);

            Console.WriteLine(result);

            Func<int, int, int> addLamda = (x, y) => x + y;
            Func<int> getRandomNumber = () => new Random().Next(1, 100);
            Func<int> getRandomNumberDelegate = delegate()
            {
                Random rnd = new Random();
                return rnd.Next(1, 6);
            };

            Console.WriteLine($"Sum: {addLamda(30, 30)}");
            Console.WriteLine($"Random Number: {getRandomNumber()}");
            Console.WriteLine($"Random Number: {getRandomNumberDelegate()}");

            Test(
                (x,y) => {
                    Console.WriteLine("tae");
                   return  x + y;
                }
            );

            Test(add);


            //////////
            Func<Person, object> test1 = x => x.Name;

            Person p = new Person();

            p._name = "Gilbert M. Binos";


            test1 = x => x._name;


            Console.WriteLine($"Sum: {test1(p)}");


        }

        public static int Sum(int x, int y) { 
            return x + y;
        }

        public static void Test(Func<int, int, int> sum) { 
            var result = sum(10, 20);
        }


        class Person {

            public string _name = "";

            public int Id { get; set; }

            public String Name { get; set; }
        }


    }
}
