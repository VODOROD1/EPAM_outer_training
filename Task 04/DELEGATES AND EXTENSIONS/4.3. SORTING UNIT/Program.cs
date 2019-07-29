using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _4._3.SORTING_UNIT
{
    class Program
    {
        static void Main(string[] args)
        {
            SortModule<string> sortModule = new SortModule<string>();
            string[] arr = new string[] { "BBB", "AAA", "badbaf", "gsdf", "wwmbn", "ll", "rty", "r", "CCC", "DDD", "T", "asd", "asfggrege", "a" };
            Func<string, string, int> compareString = CompareString;

            sortModule.CreateThreadForSorting(arr, compareString);
            sortModule.SortFinish += (object o, EventArgs arg) => Console.WriteLine("Сортировка завершена!");
            Thread.Sleep(100);
            OutputArr(arr);
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
        public static void OutputArr<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadLine();
        }
    }
    public class SortModule<T>
    {
        public event EventHandler SortFinish;

        public void Sort(T[] arr, Func<T, T, int> compare)
        {
            if (compare == null)
            {
                throw new ArgumentNullException();
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
            SortFinish?.Invoke(this, EventArgs.Empty);
        }

        public void CreateThreadForSorting(T[] arr, Func<T, T, int> compare)
        {
            Thread th = new Thread(() => this.Sort(arr, compare));
            th.Start();
        }
    }
}