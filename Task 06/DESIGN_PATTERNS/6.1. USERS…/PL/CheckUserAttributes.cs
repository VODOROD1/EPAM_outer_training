using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.USERS_.PL
{
    class CheckUserAttributes
    {
        public bool CheckName(String inputName)
        {
            string[] words = inputName.Split(new char[] { ' ' });
            foreach (string word in words) {
                for (int i = 0; i < word.Length; i++) {
                    if (!char.IsLetter(word[i])) {
                        Console.WriteLine("Введите имя правильно!");
                        return false;
                    }
                }
            }
            return true;
        }
        public bool CheckDate(String inputDate)
        {
            if (DateTime.TryParseExact(inputDate, "dd.MM.yyyy HH:mm", null, DateTimeStyles.None, out DateTime date))
            {
                return true;
            }
            return false;
        }
        public bool CheckAge(String inputAge)
        {
            for (int i = 0; i < inputAge.Length; i++)
            {
                if (!char.IsLetter(inputAge[i]))
                {
                    Console.WriteLine("Введите возраст правильно!");
                    return false;
                }
            }
            return true;
        }

    }
}
