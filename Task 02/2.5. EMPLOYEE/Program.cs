using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5.EMPLOYEE
{
    class Program
    {
        static void Main(string[] args)
        {
            AskAboutEmployee ask = new AskAboutEmployee();
            Employee employee = new Employee(ask.Fullname, ask.Birthday, ask.Age, ask.WorkExperience, ask.Position);
            outputUser(employee);
        }

        public static void outputUser(Employee employee)
        {
            Console.WriteLine("\t\tИнформация о работнике");
            Console.WriteLine($"ФИО:\t\t{employee.Surname} {employee.Name} {employee.Patronymic}");
            Console.WriteLine($"Дата рождения:\t{employee.Day}.{employee.Month}.{employee.Year}");
            Console.WriteLine($"Возраст:\t{employee.Age}");
            Console.WriteLine($"Стаж работы:\t{employee.WorkExperience}");
            Console.WriteLine($"Должность:\t{employee.Position}");
            Console.ReadKey();
        }
    }
}
