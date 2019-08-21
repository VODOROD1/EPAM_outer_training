using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.USERS_.Common
{//Общий интерфейс благодаря которому работает слабое связывание для
//разной реализации уровня PL.
//В данной программе реализован только консольный интерфейс
    public interface IStorable
    {
        void AddUser(User user);
        void AddNewAward(Award award);
        void RemoveUser(Guid userGuid);
        IList<User> GetAllUsers();
        IList<Award> GetAllAwards();
        IList<AwardsAndUsers> GetAllAwardsUsers();
        void AddAwardForUser(User user, Award award);
    }
}
