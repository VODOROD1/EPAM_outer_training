﻿using System;
using System.Globalization;

namespace WebUI.Models
{//Класс проверки правильности введенных атрибутов создаваемого пользователя
    public static class CheckUserAttributes
    {
        public static bool CheckName(String inputName)
        {
            if(inputName == "")
            {
                return false;
            }
            string[] words = inputName.Split(new char[] { ' ' });
            foreach (string word in words) {
                if (word == "") { return false; }
                for (int i = 0; i < word.Length; i++) {
                    if (!char.IsLetter(word[i])) {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool CheckDate(String inputDate)
        {
            if (DateTime.TryParseExact(inputDate, "dd.MM.yyyy", null, DateTimeStyles.None, out DateTime date))
            {
                return true;
            }
            return false;
        }
        public static bool CheckAge(String inputAge)
        {
            if (inputAge == "")
            {
                return false;
            }
            for (int i = 0; i < inputAge.Length; i++)
            {
                if (!char.IsDigit(inputAge[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
