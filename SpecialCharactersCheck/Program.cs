using System.Runtime.CompilerServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace SpecialCharactersCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<String> list = new List<String>();

            list.Add("HKI199204811");
            list.Add("HKI1992048ĦØ");
            list.Add("HKI1992048Ħ$");

            foreach (String item in list) {
                Console.WriteLine(item);
                Console.WriteLine(IsTextValid(item));
            }
        }

        public static Boolean IsTextValid(String input) {

            if (!input.IsNormalized(NormalizationForm.FormD)) return false;

            byte[] bytes = Encoding.UTF8.GetBytes(input);
            string textAscii = Encoding.ASCII.GetString(bytes);

            for (int i = 0; i <= (input.Length - 1); i++) {
                if (!Char.IsLetterOrDigit(input[i])){
                    return false;
                }
            }

            if (textAscii == input) { 
            
            }

            return true;
        }
    }
}
