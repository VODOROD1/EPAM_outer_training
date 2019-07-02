using System;

namespace SQUARE
{
    class Program
    {
        static void Main(string[] args)
        {
            func();
        }
        public static void func()
        {
            uint N = 0;
            Console.Write("Введите положительное нечетное целое число:");
            String input = Console.ReadLine();
            checkNumber(input, out N);
            square(N);
        }
        public static void checkNumber(String input, out uint N)
        {
            if (uint.TryParse(input, out N) && N % 2 == 1)
            {
                N = Convert.ToUInt32(input);
            }
            else
            {
                Console.WriteLine("Пожалуйста, введите положительное нечетное целое число!");
                func();
            }
        }
        public static void square(uint N)
        {
            int middle = ((int)N)/ 2 + 1;
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (i == middle && j == middle)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
