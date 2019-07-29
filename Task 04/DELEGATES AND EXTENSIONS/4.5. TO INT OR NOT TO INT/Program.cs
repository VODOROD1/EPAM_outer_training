using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._5.TO_INT_OR_NOT_TO_INT
{
    class Program
    {
        static void Main(string[] args)
        {
            String str1 = "1256";
            String str2 = "-8907";
            Console.WriteLine(str1.CheckPositive());
            Console.ReadKey();
        }
    }
    public static class CheckPositiveExtension
    {
        public static int CheckPositive(this string str)
        {
            int result = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '-')
                {
                    Console.WriteLine("Число является положительным!");
                    result += ((int)str[str.Length - i - 1] - 48) * (int)Math.Pow(10, i);
                }
                else { Console.WriteLine("Число не является положительным!"); }
            }
            return result;
        }
    }
}