using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.USERS_.Entities
{//Общий интерфейс благодаря которому работает слабое связывание для
 //разной реализации уровня DAL.
 //В данной программе реализовано только хранение на жестком диске в текстовом файле
    public interface IUI
    {
        void LaunchCode();
        bool AddUser(String name, String birthDay, String age);
        bool AddAward(String title);
        bool AddAwardForUser(String userKey, String awardKey);
        IList<String[]> GetAllUsers();
        IList<String[]> GetAllAwards();
        IList<String[]> GetAllAwardsUsers();
        bool EditUser();
        bool EditAward();
        void DeleteUser(String input);
        void DeleteAward(String input);
        void DeleteAwardFromUser(String input);
    }
}
