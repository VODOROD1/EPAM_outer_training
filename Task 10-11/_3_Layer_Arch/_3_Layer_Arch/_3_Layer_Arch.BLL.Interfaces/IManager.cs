using System.Collections.Generic;

namespace _3_Layer_Arch.BLL.Interfaces
{
    public interface IManager
    {
        bool AddUser(string name, string date, string strAge);
        bool AddNewAward(string title);
        bool AddAwardForUser(string userKey, string awardKey);
        IList<string[]> GetAllUsers();
        IList<string[]> GetAllAwards();
        IList<string[]> GetAllAwardsOfUser(string i);
        IList<string[]> GetAllAwardsUsers();
        bool CheckAwardForUser(string userKey, string awardKey, out string userId, out string awardId);
        bool CheckNewAward(string awardTitle);
        void DeleteUser(int id);
        void DeleteAward(int id);
        void DeleteAwardFromUser(string userId, string awardId);
        void DeleteAwardFromUsers(string awardId);
        bool EditAward(string Id, string title);
        bool EditUser(string Id, string name, string date, string strAge);
    }
}