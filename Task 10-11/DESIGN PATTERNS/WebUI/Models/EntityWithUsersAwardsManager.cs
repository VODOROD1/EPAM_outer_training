using _6._1.USERS_.BLL;
using _6._1.USERS_.Entities;
using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public class EntityWithUsersAwardsManager : IUI
    {
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
            } else {
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
        public bool EditAward()
        {
            throw new NotImplementedException();
        }
        public bool EditUser()
        {
            throw new NotImplementedException();
        }
        public void DeleteUser(String input)
        {
            UsersAwardsManager.DeleteUser(input);
        }
        public void DeleteAward(String input)
        {
            throw new NotImplementedException();
        }
        public void DeleteAwardFromUser(String input)
        {
            throw new NotImplementedException();
        }
    }
}