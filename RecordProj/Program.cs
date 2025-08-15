using System.Runtime.InteropServices;
using System.Text.Json;

namespace RecordProj
{
    internal class Program
    {

        record FullName(string FirstName, string LastName);

        static void Main(string[] args)
        {
            

            CustomFullName samuel = new("Samuel", "Jackson");
            var (firstName, _) = samuel;

            FullName samuel1 = new("Samuel", "Jackson");
            FullName samuel2 = samuel1 with { FirstName = "Samuei L." };
            var (firstName3, _) = samuel1;


            Console.WriteLine(JsonSerializer.Serialize<FullName>(samuel1).ToString());
            Console.WriteLine(JsonSerializer.Serialize<FullName>(samuel2).ToString());

            NewFullName juan = new("Juan", "dela Cruz");
            NewFullName juan2 = juan;
            juan2.FirstName = "John";

            Console.WriteLine(JsonSerializer.Serialize<NewFullName>(juan).ToString());
            Console.WriteLine(JsonSerializer.Serialize<NewFullName>(juan2).ToString());


            NewFullName juan3 = new("Juan", "dela Cruz");
            //NewFullName juan4 = new(juan3) { FirstName = "John"};
            NewFullName juan4 = new(juan3);

            juan4.FirstName = "Berto";

            Console.WriteLine(JsonSerializer.Serialize<NewFullName>(juan3).ToString());
            Console.WriteLine(JsonSerializer.Serialize<NewFullName>(juan4).ToString());

            Employee emp = new("Gilbert", "Binos");
            Console.WriteLine(JsonSerializer.Serialize<Employee>(emp).ToString());


        }
    }

     class CustomFullName {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public CustomFullName(string firstName, string lastName) =>
            (FirstName, LastName) = (firstName, lastName);

        public CustomFullName(CustomFullName other) : this(other.FirstName, other.LastName) { }

        public void Deconstruct(out string firstName, out string lastName) =>
            (firstName, lastName) = (FirstName, LastName);


    }

    class NewFullName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public NewFullName(string firstName, string lastName) =>
            (FirstName, LastName) = (firstName, lastName);

        public NewFullName(NewFullName other) : this(other.FirstName, other.LastName) { }
    }

    //C# 12
    class CustomFullNameTest(string firstName, string lastName)
    {
        public string FirstName { get; init; } = firstName;
        public string LastName { get; init; } = lastName;
    }
}
