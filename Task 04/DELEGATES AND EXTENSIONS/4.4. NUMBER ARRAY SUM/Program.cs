using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._4.NUMBER_ARRAY_SUM
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[] {1, 9, 2, 8, 3, 7, 4, 6, 5};
            double[] arr2 = new double[] { 6.0, 12.12, 19.35, 1.99, 3.0, 7.15, 8.26, 6.87, 5.88 };
            decimal sum1 = arr1.ExtensionSum();
            decimal sum2 = arr2.ExtensionSum();
            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
            Console.ReadKey();
        }
    }

    public static class SumExtension
    {
        public static decimal ExtensionSum<T>(this T[] arr)
        {
            decimal sum = 0;
            Type t = arr[0].GetType();
            if (t.Equals(typeof(byte)) || t.Equals(typeof(sbyte)) || t.Equals(typeof(short))
                || t.Equals(typeof(ushort)) || t.Equals(typeof(int)) || t.Equals(typeof(uint))
                || t.Equals(typeof(long)) || t.Equals(typeof(float)) || t.Equals(typeof(double))
                || t.Equals(typeof(decimal)))
            {
                foreach (T i in arr)
                {
                    sum += Convert.ToDecimal(i);
                }
            }
            else { Console.WriteLine(); }
            return sum;
        }
    }
}
