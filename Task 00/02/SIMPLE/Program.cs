using System;

namespace SIMPLE
{
    class Program
    {
        static void Main(string[] args)
        {
            ask();
        }
        public static void ask()
        {   uint N = 0;
            Console.WriteLine("Введите положительное целое число:");
            String input = Console.ReadLine();
            checkNumber(input, out N);
        }
        public static void checkNumber(String input, out uint N)
        {

            if (uint.TryParse(input, out N))
            {
                N = Convert.ToUInt32(input);
                simpleNum(N);
            }
            else
            {
                Console.WriteLine("Пожалуйста, введите целое положительное число!");
                ask();
            }
        }
        public static void simpleNum(uint N)
        {
            if( (N % 2 != 0 & N % 3 != 0 & N != 0 & N != 1) | N == 2 | N == 3)
            {
                Console.WriteLine($"Число {N} является простым!");
            }
            else { Console.WriteLine($"Число {N} не является простым!"); }
        }
        
    }
}
