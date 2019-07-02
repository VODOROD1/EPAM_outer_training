using System;

namespace _1._2._TRIANGLE
{
    class Program
    {
        static uint N;
        static void Main(string[] args)
        {
            ask();
        }

        public static void ask()
        {
            Console.Write("Введите число N: ");
            String input = Console.ReadLine();
            if (uint.TryParse(input, out N) && Convert.ToUInt32(input) != 0)
            {
                N = Convert.ToUInt32(input);
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < i + 1; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
            else { Console.WriteLine("Ошибка! Введите пожалуйста целое положительное число!");
                ask();
            }
        }
    }
}
