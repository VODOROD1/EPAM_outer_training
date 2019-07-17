using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5.EMPLOYEE
{
    class Employee : User
    {
        private int workExperience;
        public int WorkExperience
        {
            get { return workExperience; }
        }

        private String position;
        public String Position
        {
            get { return position; }
        }

        public Employee(String fullname, String birthday, String age, String workExperience, String position) 
            :base(fullname, birthday, age)
        {
            this.workExperience = Convert.ToInt32(workExperience);
            this.position = position;
        }


    }
}
