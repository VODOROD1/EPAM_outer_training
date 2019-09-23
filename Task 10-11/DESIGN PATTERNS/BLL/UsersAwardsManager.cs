using _6._1.USERS_.Entities;
using _6._1.USERS_.DAL;
using _6._1.USERS_.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.USERS_.BLL
{
    public static class UsersAwardsManager
    {
        public static IStorable Storage => Dependensies.TextFiles;
        #region CHECK
        public static bool CheckNewAward(String awardTitle)
        {
            bool k = false;
            //проверяем нет ли в перечене наград вводимой награды
            foreach (var award in GetAllAwards())
            {
                if (award[1] == awardTitle)
                {
                    k = true;
                    break;
                }
            }
            if (k)
            {
                return true;
            }
            else { return false; }
        }
        public static bool CheckAwardForUser(String userKey, String awardKey, out String userGuid, out String awardGuid)
        {
            int keyUser = int.Parse(userKey);
            userGuid = GetAllUsers()[keyUser - 1][0];

            int keyAward = int.Parse(awardKey);
            awardGuid = GetAllAwards()[keyAward - 1][0];

            //проверяем есть уже ли у пользователя такая награда через обобщающую сущность
            bool k = true;
            foreach (String[] awardUser in GetAllAwardsUsers())
            {
                if (awardUser[0] == userGuid && awardUser[1] == awardGuid)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        #endregion
        #region ADD
        public static bool AddUser(String name, String date, String strAge)
        {
            DateTime birthDay = DateTime.ParseExact(date, "dd.MM.yyyy", null);
            uint age = Convert.ToUInt32(strAge);
            User user = new User { Id = Guid.NewGuid(), Name = name, BirthDay = birthDay, Age = age };
            Storage.AddUser(user);
            return true;
        }
        public static bool AddNewAward(String title)
        {
            if (CheckNewAward(title)) {
                return false; 
            } else
            {
                Award award = new Award { Id = Guid.NewGuid(), Title = title };
                Storage.AddNewAward(award);
                return true;
            }  
        }
        public static bool AddAwardForUser(String userKey, String awardKey)
        {   //Берем пользователя и награду по их гуайдам
            String userGuid = "";
            String awardGuid = "";
            if (CheckAwardForUser(userKey, awardKey, out userGuid, out awardGuid))
            {
                return false;
            } else
            {
                User user = Storage.GetAllUsers().First(u => u.Id.ToString() == userGuid);
                Award award = Storage.GetAllAwards().First(a => a.Id.ToString() == awardGuid);
                Storage.AddAwardForUser(user, award);
                return true;
            }
        }
        #endregion
        #region GET
        public static IList<String[]> GetAllUsers()
        {
            List<String[]> users = new List<String[]>();
            foreach (User user in Storage.GetAllUsers())
            {
                String[] mas = new String[4];
                mas[0] = user.Id.ToString();
                mas[1] = user.Name;
                mas[2] = user.BirthDay.ToString("dd.MM.yyyy");
                mas[3] = user.Age.ToString();

                users.Add(mas);
            }
            return users;
        }
        public static IList<String[]> GetAllAwards()
        {
            List<String[]> awards = new List<String[]>();
            foreach (Award award in Storage.GetAllAwards())
            {
                String[] mas = new String[2];
                mas[0] = award.Id.ToString();
                mas[1] = award.Title;

                awards.Add(mas);
            }
            return awards;
        }
        public static IList<String[]> GetAllAwardsUsers()
        {
            List<String[]> awardsAndUsers = new List<String[]>();
            foreach (AwardsAndUsers item in Storage.GetAllAwardsUsers())
            {
                String[] mas = new String[2];
                mas[0] = item.UserId.ToString();
                mas[1] = item.AwardId.ToString();

                awardsAndUsers.Add(mas);
            }
            return awardsAndUsers;
        }
        #endregion
        #region EDIT

        #endregion
        #region DELETE
        public static void DeleteUser(String input)
        {
            int key = int.Parse(input);
            Guid userGuid = Storage.GetAllUsers()[key - 1].Id;
            Storage.RemoveUser(userGuid);
        }
        #endregion
    }
}