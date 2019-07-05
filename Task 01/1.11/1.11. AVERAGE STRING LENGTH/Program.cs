using System;

namespace _1._11._AVERAGE_STRING_LENGTH
{
    class Program
    {
        static void Main(string[] args)
        {
            method();
        }

        public static void method()
        {
            Console.Write("Введите текстовую строку: ");
            String str = Console.ReadLine();
            String[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;


            for (int i = 0; i < words.Length; i++)
            {
                char[] word = words[i].ToCharArray();
                int k = 0;
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (char.IsPunctuation(word[j]) || char.IsSeparator(word[j]))
                    {
                        continue;
                    }
                    else { ++k; }
                }
                sum += k;
            }
            int averageValue = sum / words.Length;
            Console.WriteLine($"Средняя слова: {averageValue}");
            Console.ReadKey();
        }
    }
}
