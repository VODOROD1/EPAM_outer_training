using System;
using System.Collections.Generic;

namespace _3_Layer_Arch.PL.Interfaces
{
    public interface IUI
    {
        bool AddUser(String name, String birthDay, String age);
        bool AddAward(String title);
        bool AddAwardForUser(String userKey, String awardKey);
        IList<String[]> GetAllUsers();
        IList<String[]> GetAllAwards();
        IList<String[]> GetAllAwardsUsers();
        bool EditUser(String id, String name, String date, String age);
        bool EditAward(String id, String name);
        void DeleteUser(int id);
        void DeleteAward(int id);
        void DeleteAwardFromUser(String userId, String awardId);
        void DeleteAwardFromUsers(String awardId);
    }
}
