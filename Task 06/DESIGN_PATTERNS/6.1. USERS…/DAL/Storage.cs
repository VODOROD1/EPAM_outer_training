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
        private List<User> users = new List<User>();
        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }

        private List<Award> awards = new List<Award>();
        public List<Award> Awards
        {
            get { return awards; }
            set { awards = value; }
        }

        private List<AwardsAndUsers> awardsUsers = new List<AwardsAndUsers>();
        public List<AwardsAndUsers> AwardsUsers
        {
            get { return awardsUsers; }
            set { awardsUsers = value; }
        }
    }
}