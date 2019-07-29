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
            var str1 = "1256";
            var str2 = "-8907";
            Console.WriteLine(str1.CheckPositive());
            Console.WriteLine(str2.CheckPositive());
            Console.ReadKey();
        }
    }
    //Расширяющий класс
    #region EXTENDED_CLASS
    public static class CheckPositiveExtension
    {
        public static bool CheckPositive(this string str)
        {
            bool result = true;
            //Перевожу строку в массив кодов ASCII
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            foreach (byte b in bytes)
            {   //Проверяю -- попадает ли символ в отрезок чисел таблицы ASCII
                if (!(48 <= b && b <= 57))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
    #endregion
}