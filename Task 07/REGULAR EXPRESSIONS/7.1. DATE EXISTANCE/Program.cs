using System;
using System.Text.RegularExpressions;

namespace _7._1.DATE_EXISTANCE
{

    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Введите текст, содержащий дату в формате dd-mm-yyyy: '");

            var inputString = Console.ReadLine();
            //регулярное выражение поиска даты
            var logic = Regex.IsMatch(inputString, @"((0[1-9]|[1-2]\d|3[0-1])-(0[1-9]|1[0-2])-\d{4})");

            if (logic)
            {
                Console.WriteLine($"В тексте '{inputString}' содержится дата!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"В тексте '{inputString}' НЕ содержится дата!");
                Console.ReadKey();
            }
        }
    }
}
