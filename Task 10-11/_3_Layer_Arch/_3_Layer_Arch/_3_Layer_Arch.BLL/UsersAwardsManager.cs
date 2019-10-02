using _3_Layer_Arch.BLL.Interfaces;
using _3_Layer_Arch.DAL.Interfaces;
using _3_Layer_Arch.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Layer_Arch.BLL
{
    public class UsersAwardsManager : IManager
    {
        private readonly IStorable storage;
        public UsersAwardsManager(IStorable storage)
        {
            this.storage = storage;
        }
        #region CHECK
        public bool CheckNewAward(String awardTitle)
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
        public bool CheckAwardForUser(String userKey, String awardKey, out String userId, out String awardId)
        {
            bool b = false;

            int keyUser = int.Parse(userKey);
            userId = GetAllUsers()[keyUser - 1][0];

            int keyAward = int.Parse(awardKey);
            awardId = GetAllAwards()[keyAward - 1][0];

            //проверяем есть уже ли у пользователя такая награда через обобщающую сущность
            foreach (String[] awardUser in GetAllAwardsUsers())
            {
                if (awardUser[0] == userId && awardUser[1] == awardId)
                {
                    b = true;
                    break;
                }
                b = false;
            }
            return b;
        }
        #endregion
        #region ADD
        public bool AddUser(String name, String date, String strAge)
        {
            DateTime birthDay = DateTime.ParseExact(date, "dd.MM.yyyy", null);
            int age = Convert.ToInt32(strAge);
            User user = new User { Name = name, BirthDay = birthDay, Age = age };
            storage.AddUser(user);
            return true;
        }
        public bool AddNewAward(String title)
        {
            if (CheckNewAward(title))
            {
                return false;
            }
            else
            {
                Award award = new Award { Title = title };
                storage.AddNewAward(award);
                return true;
            }
        }
        public bool AddAwardForUser(String userKey, String awardKey)
        {   //Берем пользователя и награду по их гуайдам
            String userId = "";
            String awardId = "";
            if (CheckAwardForUser(userKey, awardKey, out userId, out awardId))
            {
                return false;
            }
            else
            {
                User user = storage.GetAllUsers().First(u => u.Id.ToString() == userId);
                Award award = storage.GetAllAwards().First(a => a.Id.ToString() == awardId);
                storage.AddAwardForUser(user, award);
                return true;
            }
        }
        #endregion
        #region GET
        public IList<String[]> GetAllUsers()
        {
            List<String[]> users = new List<String[]>();
            foreach (User user in storage.GetAllUsers())
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
        public IList<String[]> GetAllAwards()
        {
            List<String[]> awards = new List<String[]>();
            foreach (Award award in storage.GetAllAwards())
            {
                String[] mas = new String[2];
                mas[0] = award.Id.ToString();
                mas[1] = award.Title;

                awards.Add(mas);
            }
            return awards;
        }
        public IList<String[]> GetAllAwardsUsers()
        {
            List<String[]> awardsAndUsers = new List<String[]>();
            foreach (AwardsAndUsers item in storage.GetAllAwardsUsers())
            {
                String[] mas = new String[2];
                mas[0] = item.UserId.ToString();
                mas[1] = item.AwardId.ToString();

                awardsAndUsers.Add(mas);
            }
            return awardsAndUsers;
        }
        public IList<string[]> GetAllAwardsOfUser(String i)
        {
            String userId = i;
            List<string[]> awardsOfUser = new List<string[]>();
            //По id находим выбранного пользователя
            IList<String[]> a = GetAllAwardsUsers();
            var someAwardsUsers = a.Where(p => p[0] == userId).ToList();
            foreach (String[] aau in someAwardsUsers)
            {
                foreach (String[] award in GetAllAwards())
                {
                    if (award[0] == aau[1])
                    {
                        awardsOfUser.Add(award);
                    }
                }
            }
            return awardsOfUser;
        }
        #endregion
        #region EDIT
        public bool EditAward(String id, String title)
        {
            Award award = new Award { Title = title, };
            storage.EditAward(id, award);
            return true;
        }
        public bool EditUser(String id, String name, String date, String strAge)
        {
            DateTime birthDay = DateTime.ParseExact(date, "dd.MM.yyyy", null);
            int age = Convert.ToInt32(strAge);
            User user = new User { Name = name, BirthDay = birthDay, Age = age };
            storage.EditUser(id, user);
            return true;
        }
        #endregion
        #region DELETE
        public void DeleteUser(int id)
        {
            storage.RemoveUser(id);
        }
        public void DeleteAward(int id)
        {
            storage.DeleteAward(id);
        }
        public void DeleteAwardFromUser(String userId, String awardId)
        {
            storage.DeleteAwardFromUser(userId, awardId);
        }
        public void DeleteAwardFromUsers(String awardId)
        {
            storage.DeleteAwardFromUsers(awardId);
        }
        #endregion
    }
}
