namespace ActionDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<int> printActionDel = ConsolePrint;
            Action<int> printActionDel2 = new Action<int>(ConsolePrint);

            printActionDel(100);
            printActionDel2(200);
        }

        public static void ConsolePrint(int i) {
            Console.WriteLine(i);
        }
    }
}
