using System;

namespace _1._9._NON_NEGATIVE_SUM
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[25];
            int sum = 0;
            Random rndNum = new Random();
            Console.Write($"Исходный массив: ");
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rndNum.Next(-100, 100);
                Console.Write($"{mas[i]}, ");
                if (mas[i]>0)
                {
                    sum += mas[i];
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Сумма неотрицательных элементов: {sum}");
            Console.ReadKey();
        }
    }
}
