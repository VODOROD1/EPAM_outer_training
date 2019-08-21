using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.USERS_.Common
{//Общий интерфейс благодаря которому работает слабое связывание для
 //разной реализации уровня DAL.
 //В данной программе реализовано только хранение на жестком диске в текстовом файле
    interface IUI
    {
        void SelectOption();
        void AskUserAttributes(out String name, out DateTime birthDay, out uint age);
        void DeleteUser();
        void ShowAllUsers();

    }
}
