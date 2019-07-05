using System;

namespace _1._8._NO_POSITIVE
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int[,,] mas = new int[3, 4, 5];
            Console.WriteLine("Исходный трехмерный массив:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Подмассив №{i}");
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        mas[i, j, k] = rnd.Next(-100, 100);
                        Console.Write($"{mas[i, j, k]}, ");
                        if(mas[i, j, k] > 0)
                        {
                            mas[i, j, k] = 0;
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\n");
            }
            Console.ReadKey();

            Console.WriteLine("Массив без положительных элементов:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Подмассив №{i}");
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        if (mas[i, j, k] > 0)
                        {
                            mas[i, j, k] = 0;
                        }
                        Console.Write($"{mas[i, j, k]}, ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\n");
            }
            Console.ReadKey();
        }
    }
}
