using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3.USER
{
    class Program
    {
        static void Main(string[] args)
        {
            AskAboutUser ask = new AskAboutUser();
            User user = new User(ask.Fullname, ask.Birthday, ask.Age);
            outputUser(user);
        }

        public static void outputUser(User user)
        {
            Console.WriteLine("\t\tИнформация о пользователе");
            Console.WriteLine($"ФИО:\t\t{user.Surname} {user.Name} {user.Patronymic}");
            Console.WriteLine($"Дата рождения:\t{user.Day}.{user.Month}.{user.Year}");
            Console.WriteLine($"Возраст:\t{user.Age}");
            Console.ReadKey();
        }
    }
}