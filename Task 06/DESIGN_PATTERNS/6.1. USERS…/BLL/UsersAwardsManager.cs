using _6._1.USERS_.Common;
using _6._1.USERS_.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.USERS_.BLL
{
    public class UsersAwardsManager
    {
        public static IStorable TextFiles;
        public UsersAwardsManager()
        {
            TextFiles = new TextFiles();
        }
        public void AddUser(String name, DateTime date, uint age)
        {
            User user = new User { Id = Guid.NewGuid(), Name = name, BirthDay = date, Age = age };
            TextFiles.AddUser(user);
        }
        public void AddNewAward(String title)
        {
            Award award = new Award {Id=Guid.NewGuid(), Title = title };
            TextFiles.AddNewAward(award);
        }
        public void AddAwardForUser(Guid userGuid, Guid awardGuid) 
        {   //Берем пользователя и награду по их гуайдам
            User user = TextFiles.GetAllUsers().First(u => u.Id == userGuid);
            Award award = TextFiles.GetAllAwards().First(a => a.Id == awardGuid);
            TextFiles.AddAwardForUser(user, award);
        }
        public void DeleteUser(int key)
        {
            Guid userGuid = TextFiles.GetAllUsers()[key - 1].Id;
            TextFiles.RemoveUser(userGuid);
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