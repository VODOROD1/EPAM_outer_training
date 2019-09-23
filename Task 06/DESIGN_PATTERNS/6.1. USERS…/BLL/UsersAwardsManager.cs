using _6._1.USERS_.Common;
using _6._1.USERS_.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.USERS_.BLL
{
    public static class UsersAwardsManager
    {
        public static IStorable TextFiles;
        static UsersAwardsManager()
        {
            TextFiles = new TextFiles();
        }
        public static void AddUser(String name, DateTime date, uint age)
        {
            User user = new User { Id = Guid.NewGuid(), Name = name, BirthDay = date, Age = age };
            TextFiles.AddUser(user);
        }
        public static void AddNewAward(String title)
        {
            Award award = new Award {Id=Guid.NewGuid(), Title = title };
            TextFiles.AddNewAward(award);
        }
        public static void AddAwardForUser(Guid userGuid, Guid awardGuid) 
        {   //Берем пользователя и награду по их гуайдам
            User user = TextFiles.GetAllUsers().First(u => u.Id == userGuid);
            Award award = TextFiles.GetAllAwards().First(a => a.Id == awardGuid);
            TextFiles.AddAwardForUser(user, award);
        }
        public static void DeleteUser(int key)
        {
            Guid userGuid = TextFiles.GetAllUsers()[key - 1].Id;
            TextFiles.RemoveUser(userGuid);
        }
        public static IList<User> GetAllUsers()
        {
            return TextFiles.GetAllUsers();
        }
        public static IList<Award> GetAllAwards()
        {
            return TextFiles.GetAllAwards();
        }
        public static IList<AwardsAndUsers> GetAllAwardsUsers()
        {
            return TextFiles.GetAllAwardsUsers();
        }
    }
}