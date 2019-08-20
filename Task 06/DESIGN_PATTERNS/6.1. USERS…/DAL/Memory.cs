using _6._1.USERS_.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.USERS_.DAL
{
    class Memory : IStorable
    {
        private static List<User> Users { get; set; }
        static Memory()
        {
            Users = new List<User>();
        }
        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public bool RemoveUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
