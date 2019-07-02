using System;

namespace _1._1._RECTANGLE
{
    class Program
    {
        static void Main(string[] args)
        {
            defineSquare();
        }

        public static void defineSquare()
        {
            int a = 0;
            String A = "";
            askA(A, out a);
            int b = 0;
            String B = "";
            askB(B, out b);
            Console.WriteLine();
            Console.WriteLine($"Площадь прямоугольника равна: {a*b}");
        }

        public static void askA(String A, out int a)
        {
            Console.WriteLine();
            Console.Write("Введите значение стороны a:");
            
            while (true)
            {
                var input = Console.ReadKey(false);
                if (input.Key == ConsoleKey.Enter) { break; }
                if (int.TryParse(input.KeyChar.ToString(), out a))
                {
                    if (Convert.ToInt32(input.KeyChar.ToString()) > 0)
                    {
                        A += input.KeyChar.ToString();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Внимание! Введено число, несоответствующее правилу!");
                        break;
                    }
                }
                else { continue; }
            }
            a = Convert.ToInt32(A);
        }

        public static void askB(String B, out int b)
        {
            Console.WriteLine();
            Console.Write("Введите значение стороны b:");
            while (true)
            {
                var input = Console.ReadKey(false);
                if (input.Key == ConsoleKey.Enter) { break; }
                if (int.TryParse(input.KeyChar.ToString(), out b))
                {
                    if (Convert.ToInt32(input.KeyChar.ToString()) > 0)
                    {
                        B += input.KeyChar.ToString();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Внимание! Введено число, несоответствующее правилу!");
                        break;
                    }
                }
                else { continue; }
            }
            b = Convert.ToInt32(B);
        } 
    }
}
