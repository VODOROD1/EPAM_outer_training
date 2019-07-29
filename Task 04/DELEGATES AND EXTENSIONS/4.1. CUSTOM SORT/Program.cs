using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1.CUSTOM_SORT
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] {1, 9, 2, 8, 3, 7, 4, 6, 5 };
            Func<int, int, bool> cs = (int n1, int n2) => { if (n1 < n2) { return true; } else { return false; } };
            Sort(array, cs);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadLine();
        }

        public static void Sort<T>(T[] arr, Func<T, T, bool> compare)
        {
            if (compare == null)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (compare(arr[j], arr[i]))
                    {
                        var temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
        }
    }
}