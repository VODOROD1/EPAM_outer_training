using System;

namespace SEQUENCE
{
    class Program
    {
        static void Main(string[] args)
        {
            askNumber();
        }

        public static void askNumber()
        {
            uint N = 0;
            Console.Write("Введите число N:");
            String input = Console.ReadLine();
            checkNumber(input, out N);
            String str = returnStr((int)N);
            Console.WriteLine(str);
        }
        public static void checkNumber(String input, out uint N)
        {
            if (uint.TryParse(input, out N) && N !=0 ) {
                N = Convert.ToUInt32(input);
            }
            else { Console.WriteLine("Пожалуйста, введите целое положительное число!");
                askNumber();
            }
        }

        public static string returnStr(int N)
        {
            String[] strArr = new string[N]; 
            String str ="";
            for (int i=0;i<N;i++)
            {
                strArr[i] = (i + 1).ToString();
            }
            str = String.Join(", ", strArr);
            return str;
        }
    }
}
