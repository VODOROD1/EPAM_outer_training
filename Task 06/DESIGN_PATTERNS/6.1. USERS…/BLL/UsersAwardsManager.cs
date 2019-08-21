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
        //public static IStorable TextFiles => Dependensies.GetTextFilesObj;
        public static IStorable TextFiles;
        public UsersAwardsManager()
        {
            TextFiles = new TextFiles();
        }
        public void AddUser(String name, DateTime date, uint age)
        {
            TextFiles.AddUser(new User {Name = name,BirthDay = date,Age = age });
        }
        public void AddNewAward(String title)
        {
            TextFiles.AddNewAward(new Award { Title = title });
        }
        public void AddAwardForUser(Guid userGuid, Guid awardGuid) //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {   //Берем пользователя и награду по их гуайду
            User user = TextFiles.GetAllUsers().First(u => u.Id == userGuid);
            Award award = TextFiles.GetAllAwards().First(a => a.Id == awardGuid);
            TextFiles.AddAwardForUser(user, award);
        }
        public void DeleteUser(char key)
        {
            User user = TextFiles.GetAllUsers()[key - 1];
            TextFiles.RemoveUser(user);
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