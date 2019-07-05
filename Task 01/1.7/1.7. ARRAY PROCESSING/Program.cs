using System;

namespace _1._7._ARRAY_PROCESSING
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[25];
            int max = 0;
            int min = 0;
            Random rndNum = new Random();
            Console.WriteLine($"Исходный массив: ");
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rndNum.Next(-100, 100);
                Console.Write($"{mas[i]}, ");
            }

            //Нахождение максимального и минимального элементов массива
            min = mas[0];
            max = mas[0];
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > max)
                {
                    max = mas[i];
                }
                if (mas[i] < min)
                {
                    min = mas[i];
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Минимальный элемент массива: {min}, ");
            Console.WriteLine($"Максимальный элемент массива: {max}, ");

            //Пузырьковая сортировка массива
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        int temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Отсортированный массив: ");
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write($"{mas[i]}, ");
            }
            Console.WriteLine();
            Console.WriteLine($"Минимальный элемент массива: {mas[0]}, ");
            Console.WriteLine($"Максимальный элемент массива: {mas[24]}, ");
            Console.ReadKey();
        }
    }
}