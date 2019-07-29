using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._6.I_SEEK_YOU
{
    public class Program
    {   //Определяем делегат, через который будет передаваться условие IsPositive
        public delegate bool Condition<T>(T x);
        public static bool Positive(int x) => x > 0;
        #region MAIN
        public static void Main(string[] args)
        {
            var arr = new int[] { 99, -13, 77, -65, 23, 96, -55, -8 };

            //1) Здесь вызываем простой метод
            var positiveArr1 = SearchPositive(arr);
            OutputArr(positiveArr1);
            //Далее фигурирует один метод, в который условие поиска передается разными способами

            //2) условие поиска передаётся через экземпляр делегата
            var condition1 = new Condition<int>(Positive);
            var positiveArr2 = Search(arr, condition1);
            OutputArr(positiveArr2);

            //3) условие поиска передаётся через делегат в виде анонимного метода
            Condition<int> condition2 = delegate (int x) { return x > 0; };
            var positiveArr3 = Search(arr, condition2);
            OutputArr(positiveArr3);

            //4) условие поиска передаётся через делегат в виде лямбда-выражения
            var positiveArr4 = Search(arr, x => x > 0);
            OutputArr(positiveArr4);

            //5) Применение LINQ-выражения для поиска положительных элементов массива
            var positiveArr5 = arr.Where(x => x > 0).ToArray();
            OutputArr(positiveArr5);
            Console.ReadKey();
        }
        #endregion
        #region SEARCH_POSITIVE
        public static T[] SearchPositive<T>(T[] arr)
        {
            var resultList = new List<T>();
            //Применим  базовый класс для реализаций универсального интерфейса IComparer<T>
            var defaultComparer = Comparer<T>.Default;

            foreach (T element in arr)
            {
                if (defaultComparer.Compare(element, default) > 0)
                {
                    resultList.Add(element);
                }
            }

            return resultList.ToArray();
        }
        #endregion
        #region SEARCH
        public static T[] Search<T>(T[] arr, Condition<T> condition)
        {
            if (condition is null)
            {
                throw new ArgumentNullException($"{nameof(condition)} is null!");
            }

            var resultList = new List<T>();

            foreach (T element in arr)
            {
                if (condition(element))
                {
                    resultList.Add(element);
                }
            }

            return resultList.ToArray();
        }
        #endregion
        public static void OutputArr<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
        }
    }
}