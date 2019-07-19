using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4.MY_STRING
{
    class Program
    {
        static void Main(string[] args)
        {
            String str1, str2;
            askAboutString(out str1, out str2);
            MyString myStr1 = new MyString(str1);
            MyString myStr2 = new MyString(str2);
            //useMyString(myStr1, myStr2);
        }
        public static void askAboutString(out String str1, out String str2)
        {
            Console.Write("Введите первую строку: ");
            str1 = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Введите вторую строку: ");
            str2 = Console.ReadLine();
            Console.WriteLine();
        }
        //public static void useMyString(MyString myStr1, MyString myStr2)
        //{
        //    MyString newMyString = myStr1 + myStr1;
        //    Console.WriteLine(newMyString);
        //    bool result = MyString.Equals(myStr1, myStr1);
        //    Console.WriteLine(result);
        //    console.write("введите символ: ");
        //    char [] ch = console.readline().tochararray();
        //    mystr1.indexof();
        //    indexof.lastindexof();
        //}
    }
}
