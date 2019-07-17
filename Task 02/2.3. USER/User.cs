using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3.USER
{
    class User
    {
        private String name;
        public String Name
        {
            get { return name; }
        }

        private String surname;
        public String Surname
        {
            get { return surname; }
        }

        private String patronymic;
        public String Patronymic
        {
            get { return patronymic; }
        }

        private int age;
        public int Age
        {
            get { return age; }
        }

        private int day;
        public int Day
        {
            get { return day; }
        }

        private int month;
        public int Month
        {
            get { return month; }
        }

        private int year;
        public int Year
        {
            get { return year; }
        }

        public User(String fullname, String birthday, String age)
        {
            decomposeFullname(fullname);
            decomposeBirthday(birthday);
            this.age = Convert.ToInt32(age);
        }

        public void decomposeFullname(String fullname)
        {
            String[] words = fullname.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            name = words[0];
            surname = words[1];
            patronymic = words[2];
        }

        public void decomposeBirthday(String birthday)
        {
            String[] words = birthday.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            day = Convert.ToInt32(words[0]);
            month = Convert.ToInt32(words[1]);
            year = Convert.ToInt32(words[2]);
        }
    }
}
