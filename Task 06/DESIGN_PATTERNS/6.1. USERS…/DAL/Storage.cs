using _6._1.USERS_.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.USERS_.DAL
{
    public class Storage
    {
        private static List<User> users;
        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }

        private static List<Award> awards;
        public List<Award> Awards
        {
            get { return awards; }
            set { awards = value; }
        }

        private static List<AwardsAndUsers> awardsUsers;
        public List<AwardsAndUsers> AwardsUsers
        {
            get { return awardsUsers; }
            set { awardsUsers = value; }
        }
    }
}