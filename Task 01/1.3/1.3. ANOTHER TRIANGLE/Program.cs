using System;

namespace _1._3._ANOTHER_TRIANGLE
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
                    for (int j = 1; j <= N*2; j++)
                    {   int M1 = (int)(N) + 1 - i ;
                        int M2 = (int)(N) + 1 + i;
                        if (j >= M1 & j <= M2) {
                            Console.Write("*");
                        }
                        else { Console.Write(" "); }
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Ошибка! Введите пожалуйста целое положительное число!");
                ask();
            }
        }
    }
}