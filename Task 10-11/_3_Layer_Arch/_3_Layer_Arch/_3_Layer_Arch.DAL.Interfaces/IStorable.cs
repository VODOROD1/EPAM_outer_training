using _3_Layer_Arch.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Layer_Arch.DAL.Interfaces
{
    public interface IStorable
    {
        void AddUser(User user);
        void AddNewAward(Award award);
        void AddAwardForUser(User user, Award award);
        IList<User> GetAllUsers();
        IList<Award> GetAllAwards();
        IList<AwardsAndUsers> GetAllAwardsUsers();
        void EditUser(String id, User user);
        void EditAward(String id, Award award);
        void RemoveUser(int id);
        void DeleteAward(int id);
        void DeleteAwardFromUser(String userId, String awardId);
        void DeleteAwardFromUsers(String awardId);
    }
}
