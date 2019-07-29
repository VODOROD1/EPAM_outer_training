using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2.CUSTOM_SORT_DEMO
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[] { "BBB", "AAA", "badbaf", "gsdf", "wwmbn", "ll", "rty", "r","CCC", "DDD", "T", "asd", "asfggrege" };
            Func<string, string, int> cs = CompareString;
            Sort(arr, cs);
            OutputArr(arr);
        }

        public static void Sort<T>(T[] arr, Func<T, T, int> compare)
        {
            if (compare == null)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (compare(arr[i], arr[j]) > 0)
                    {
                        var temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
        }
        public static int CompareString(string s1, string s2)
        {
            if (s1 == s2) return 0;
            if (s1 == null) return -1;
            if (s2 == null) return 1;
            if (s1.Length < s2.Length) return -1;
            if (s1.Length > s2.Length) return 1;
            return s1.CompareTo(s2);
        }
        public static void OutputArr(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadLine();
        }
    }
}
