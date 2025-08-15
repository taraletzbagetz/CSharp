namespace GenericFuncDelegateProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Concrete conc = new Concrete();

            conc.testMethod(x => x.Name);

            conc.testMethod(x => x.Id);

            conc.testMethod(x => x.Name);


            
        }
    }

    public class GenericTest<T> 
        where T: class
    {
        

        public void testMethod(Func<T, object> input) 
        {


            //var tst  = input(testObj);

            

        }
    }

    public class Concrete : GenericTest<Person> { 
    
    }

    public class Person {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}
