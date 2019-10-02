using _3_Layer_Arch.BLL.Interfaces;
using _3_Layer_Arch.PL.Interfaces;
using _3_Layer_Arch.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3_Layer_Arch.WebPL.Models
{
    public class EntityWithUsersAwardsManager : IUI
    {
        IManager UsersAwardsManager;
        public EntityWithUsersAwardsManager()
        {
            UsersAwardsManager = DependencyResolver.UsersAwardsManager;
        }
        public void LaunchCode()
        {
            throw new NotImplementedException();
        }
        public bool AddUser(String name, String date, String strAge)
        {
            UsersAwardsManager.AddUser(name, date, strAge);
            Console.WriteLine("FINISH");
            return true;
        }
        public bool AddAward(string title)
        {
            if (UsersAwardsManager.AddNewAward(title))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddAwardForUser(string userKey, string awardKey)
        {
            if (UsersAwardsManager.AddAwardForUser(userKey, awardKey))
            {
                return true;
            }
            else { return false; }
        }
        public IList<String[]> GetAllUsers()
        {
            return UsersAwardsManager.GetAllUsers();
        }
        public IList<string[]> GetAllAwards()
        {
            return UsersAwardsManager.GetAllAwards();
        }
        public IList<string[]> GetAllAwardsUsers()
        {
            return UsersAwardsManager.GetAllAwardsUsers();
        }
        public IList<string[]> GetAllAwardsOfUser(String i)
        {
            return UsersAwardsManager.GetAllAwardsOfUser(i);
        }
        public bool EditAward(String id, String name)
        {
            return UsersAwardsManager.EditAward(id, name);
        }
        public bool EditUser(String id, String name, String date, String age)
        {
            return UsersAwardsManager.EditUser(id, name, date, age);
        }
        public void DeleteUser(int id)
        {
            UsersAwardsManager.DeleteUser(id);
        }
        public void DeleteAward(int id)
        {
            UsersAwardsManager.DeleteAward(id);
        }
        public void DeleteAwardFromUser(String userId, String awardId)
        {
            UsersAwardsManager.DeleteAwardFromUser(userId, awardId);
        }
        public void DeleteAwardFromUsers(String awardId)
        {
            UsersAwardsManager.DeleteAwardFromUsers(awardId);
        }
    }
}