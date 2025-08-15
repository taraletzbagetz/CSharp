using System.Linq.Expressions;
using System.Reflection;

namespace BuildExpressionProj
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<Employee> listEmp = new List<Employee>()
            {
                new Employee{ Name = "Bagets", Age = 40},
                new Employee{ Name = "Karen", Age = 41},
                new Employee{ Name = "Quanisha", Age = 19},
            };


            IQueryable<Employee> empList = listEmp.AsQueryable();


            String propName = "name";

            var sd1 = BuildExpression<Employee>(propName);
            //Expression<Func<Employee, object>> sd1 = BuildExpression<Employee>(propName);

            //var properties = typeof(Employee).GetProperties();

            //var propertyInfo = typeof(Employee).GetProperty(propName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) ?? throw new ArgumentException($"yeba:  {nameof(propName)}");


            //ParameterExpression pe = Expression.Parameter(typeof(Employee), "x");
            //var propertyExpr = Expression.Property(pe, propertyInfo.Name);
            //var convertedProp = Expression.Convert(propertyExpr, typeof(object));

            //Expression<Func<Employee, object>> sd = Expression.Lambda<Func<Employee, object>>(convertedProp, pe);
            //var test = empList.Test(x => x.Age);


            var testR = empList.Test(sd1);



            foreach (var item in testR) {
                Console.WriteLine($"{item.Name}, {item.Age}");
            }

            Console.WriteLine("Hello, World!");

            //https://blog.zhaytam.com/2020/05/17/dynamic-sorting-filtering-csharp/
        }


        public static Expression<Func<T, object>> BuildExpression<T>(String fieldName) {

            var propertyInfo = typeof(T).GetProperty(fieldName, 
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) ?? throw new ArgumentException($"{nameof(fieldName)} is not a valid sort property.");
            var pe = Expression.Parameter(typeof(T), "x");
            var propertyExpr = Expression.Property(pe, propertyInfo.Name);
            var convertedProp = Expression.Convert(propertyExpr, typeof(object));

            //Expression<Func<T, object>> sd = Expression.Lambda<Func<T, object>>(convertedProp, pe);

            return Expression.Lambda<Func<T, object>>(convertedProp, pe);
        } 


    }

    public static class HelperClass{
        public static List<Employee> Test(this IQueryable<Employee> empList, Expression<Func<Employee, object>> sortCond)
        {
            

            var test = empList.OrderBy(sortCond).ToList();

            return test;
        }
    }

    public class Employee {
        public String? Name { get; set; }
        public int Age { get; set; }
    }
}
