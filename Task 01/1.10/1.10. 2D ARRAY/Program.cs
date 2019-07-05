using System;

namespace _1._10._2D_ARRAY
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mas = new int[10,5];
            int sum = 0;
            Random rndNum = new Random();
            Console.WriteLine($"Исходный массив: ");
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    mas[i, j] = rndNum.Next(-100, 100);
                    Console.Write($"{mas[i, j]}, ");
                    if (i + j % 2 == 0)
                    {
                        sum += mas[i, j];
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Сумма элементов массива, стоящих на чётных позициях: {sum}");
            Console.ReadKey();
        }
    }
}
