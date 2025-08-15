using System.Linq.Expressions;

namespace ExpressionProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int>> add;

            add = () => 1 + 2;

            var func = add.Compile(); //Create Delegate; Returns a Delegate

            var ans = func(); //Invoke Delegate

            Console.WriteLine(ans);


            Expression<Func<int, bool>> expr;
            expr  = num => num < 5;

            Func<int, bool> result = expr.Compile();  //returns a delegate

            Console.WriteLine(result(4));

            expressionAsInputParameter(add);


            //Func<int> s = expressionAsOutputParameter(() => 1 + 2);
            var s = expressionAsOutputParameter(() => 1 + 2);
            ans = s();

            var gh = CreateBoundResource();
            var testgh = gh(10);


            //Get Property Name and Type
            Expression<Func<int, int>> addFive = (num) => num + 5;

            if (addFive is LambdaExpression lambdaExp)
            {
                var parameter = lambdaExp.Parameters[0]; /*first*/

                Console.WriteLine(parameter.Name);
                Console.WriteLine(parameter.Type);
            }
        }

        static void expressionAsInputParameter(Expression<Func<int>> param) { 
            var func  = param.Compile();
            var ans = func();
        }

        static Func<int> expressionAsOutputParameter(Expression<Func<int>> param) {
            return param.Compile();
        }

        private static Func<int, int> CreateBoundResource()
        {
            using (var constant = new Resource()) // constant is captured by the expression tree
            {
                Expression<Func<int, int>> expression = (b) => constant.Argument + b;
                var rVal = expression.Compile();
                return rVal;
            }
        }
    }

    public class Resource : IDisposable
    {
        private bool _isDisposed = false;
        public int Argument
        {
            get
            {
                if (!_isDisposed)
                    return 5;
                else throw new ObjectDisposedException("Resource");
            }
        }

        public void Dispose()
        {
            _isDisposed = true;
        }
    }


    public class Employee {
        public int Id { get; set; }
        public String Name { get; set; }
    }
}
