using _6._1.USERS_.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.USERS_.BLL
{
    class UsersAwardsManager
    {
        public static IStorable TextFiles => Dependensies.GetTextFilesObj;
        public void AddUser(String name, DateTime date, uint age)
        {
            TextFiles.AddUser(new User(name, date, age));
        }
        public void AddNewAward(String title)
        {
            TextFiles.AddNewAward(new Award(title));
        }
        public void AddAwardForUser(Guid userGuid, Guid awardGuid)
        {
            User user = TextFiles.GetAllUsers().First(u => u.Id == userGuid);
            Award award = TextFiles.GetAllAwards().First(a => a.Id == awardGuid);
            TextFiles.AddAwardForUser(user, award);
        }
        public void CheckPresenceAward()
        {
            TextFiles.Awards.Add
        }
        public IList<User> GetAllUsers()
        {
            return TextFiles.GetAllUsers();
        }
        public IList<Award> GetAllAwards()
        {
            return TextFiles.GetAllAwards();
        }
        public IList<AwardsAndUsers> GetAllAwardsUsers()
        {
            return TextFiles.GetAllAwardsUsers();
        }
    }
}
