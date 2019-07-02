using System;

namespace _1._4._X_MAS_TREE
{
    class Program
    {
        static int N;
        static void Main(string[] args)
        {
            ask();
        }

        public static void ask()
        {
            Console.Write("Введите число N: ");
            String input = Console.ReadLine();
            if (int.TryParse(input, out N) && Convert.ToInt32(input) != 0)
            {
                N = Convert.ToInt32(input);
                for (int i = 1; i <= N; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        string branch = new String('*', j);
                        Console.WriteLine(branch.PadLeft(N + 3) + "*" + branch);
                    }
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
