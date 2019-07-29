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
            var arr = new string[] { "BBB", "AAA", "badbaf", "gsdf", "wwmbn", "ll", "rty", "r", "CCC", "DDD", "T", "asd", "asfggrege", "a" };
            Func<string, string, int> compareString = CompareString;

            sortModule.CreateThreadForSorting(arr, compareString);
            sortModule.SortFinish += (object o, EventArgs arg) => Console.WriteLine("Сортировка завершена!");
            //Приостанавливаем основной поток, чтобы дополнительный успел доделать сортировку
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
                Console.Write($"{arr[i]} ");
            }
            Console.ReadKey();
        }
    }
    #region SORT_MODULE
    public class SortModule<T>
    {   //Применяем базовый делегат для события
        public event EventHandler SortFinish;

        public void Sort(T[] arr, Func<T, T, int> compare)
        {
            if (compare is null)
            {
                throw new ArgumentNullException($"{nameof(compare)} is null!");
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
        //Метод для создания дополнительного потока
        public void CreateThreadForSorting(T[] arr, Func<T, T, int> compare)
        {   //применяем анонимный лямбда-метод для того чтобы в помещенный в него метод Sort передать параметры
            Thread th = new Thread(() => this.Sort(arr, compare));
            th.Start();
        }
    }
    #endregion
}