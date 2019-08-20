using System;
using System.Collections.Generic;

namespace _6._1.USERS_.Common
{
    public class User
    {
        public Guid Id { get; private set; }
        //public List<AwardsAndUsers> AwardsUsers { get; set; }

        public string Name { get; private set; }
        public DateTime BirthDay { get; set; }
        public uint Age { get; set; }

        public User(string name, DateTime birthDay, uint age)
        {
            Id = Guid.NewGuid();
            Name = name;
            BirthDay = birthDay;
            Age = age;
            //AwardsUsers = new List<AwardsAndUsers>();
        }
    }
}