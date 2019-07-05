using System;

namespace _1._12._CHAR_DOUBLER
{
    class Program
    {
        static void Main(string[] args)
        {
            method();
        }

        public static void method()
        {
            string str1 = "";
            string str2 = "";
            string resultStr = "";
            Console.Write("Введите первую строку: ");
            str1 = Console.ReadLine();
            Console.Write("Введите вторую строку: ");
            str2 = Console.ReadLine();
            foreach (char symbol in str1)
                if (!str2.Contains(symbol))
                    resultStr += symbol;
                else
                {
                    resultStr += symbol;
                    resultStr += symbol;
                }
            Console.Write($"Результирующая строка = {resultStr}");
            Console.ReadKey();
        }
    }
}
