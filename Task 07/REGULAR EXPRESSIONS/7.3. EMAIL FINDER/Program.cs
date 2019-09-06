using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _7._3.EMAIL_FINDER
{

    public class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Введите строку:");
            var inputString = Console.ReadLine();
            Console.WriteLine();
            var pattern = @"[a-z\d]+[._-]*[a-z\d]+@[a-z\d]+(\.([a-z\d])+)+";
            var reg = new Regex(pattern);
            var matchList = GetMatchList(reg.Matches(inputString));

            WriteMatchList(matchList);
        }

        //В этом методе получаем элементы благодаря коллекции совпадений
        private static List<string> GetMatchList(MatchCollection matchCollection)
        {
            var matchList = new List<string>();

            foreach (var match in matchCollection)
            {
                var stringMatch = match.ToString();

                if (DomainTopLvl(stringMatch))
                {
                    matchList.Add(stringMatch);
                }
            }
            return matchList;
        }
        //Метод проверки совпадения домена верхнего уровня шаблону
        public static bool DomainTopLvl(string stringMatch)
        {
            var lastIndex = stringMatch.LastIndexOf('.');
            var topLvlDomain = stringMatch.Substring(lastIndex + 1, stringMatch.Length - lastIndex - 1);
            //Проверяем наличие сопадения
            return Regex.IsMatch(topLvlDomain, "^[a-z]{2,6}$");
        }
        //Выводим на экран все совпадения
        private static void WriteMatchList(List<string> emailMatchList)
        {
            Console.WriteLine("Найденные адреса электронной почты:");

            foreach (var emailMatch in emailMatchList)
            {
                Console.WriteLine(emailMatch);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
