using System;
using System.Text.RegularExpressions;

namespace _7._2.HTML_REPLACER
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Введите текст:");
            var inputText = Console.ReadLine();
            Console.WriteLine();
            var replacedText = Regex.Replace(inputText, @"<[^<>]+>", "_");
            Console.WriteLine($"Результат замены {replacedText}");
            Console.ReadKey();
        }
    }
}
