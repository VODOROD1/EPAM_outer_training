using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5.EMPLOYEE
{
    class AskAboutEmployee
    {
        String fullnameLocal = "Бел Мих Ал";
        String birthdayLocal = "18.07.1995";
        String ageLocal = "23";
        String workExperienceLocal = "15";
        String positionLocal = "senior";

        private String fullname;
        public String Fullname
        {
            get { return fullname; }
        }

        private String birthday;
        public String Birthday
        {
            get { return birthday; }
        }

        private String age;
        public String Age
        {
            get { return age; }
        }

        private String workExperience;
        public String WorkExperience
        {
            get { return workExperience; }
        }

        private String position;
        public String Position
        {
            get { return position; }
        }

        public AskAboutEmployee()
        {
            inputFullname();
            inputBirthday();
            inputAge();
            inputWorkExperience();
            inputPosition();
        }

        public void inputFullname()
        {
            bool trueLetter = true;
            //String fullnameLocal = " ";
            Console.Write("Введите фамилию, имя, отчество пользователя: ");
            //fullnameLocal = Console.ReadLine();
            Console.ReadKey();
            Console.WriteLine();
            String[] words = fullnameLocal.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length != 3)
            {
                Console.WriteLine("Введены некорректные данные!");
                inputFullname();
            }
            else
            {
                for (int i = 0; i < words.Length; i++)
                {
                    char[] c = words[i].ToCharArray();
                    for (int j = 0; j < c.Length; j++)
                    {
                        if (char.IsLetter(c[j]))
                        {
                            trueLetter = true;
                        }
                        else
                        {
                            Console.WriteLine("Введены некорректные данные!");
                            inputFullname();
                            trueLetter = false;
                            break;
                        };
                    }
                    if (!trueLetter)
                    {
                        break;
                    }
                }
                if (trueLetter)
                {
                    fullname = fullnameLocal;
                }
            }
        }

        public void inputBirthday()
        {
            bool trueLetter = true;
            int points = 0;
            //String birthdayLocal = " ";
            Console.Write("Введите дату рождения числами через точки: ");
            //birthdayLocal = Console.ReadLine();
            Console.ReadKey();
            Console.WriteLine();
            for (int i = 0; i < birthdayLocal.Length; i++)
            {
                if (birthdayLocal[i] == '.')
                {
                    ++points;
                }
            }
            if (points == 2)
            {
                String[] words = birthdayLocal.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length != 3)
                {
                    Console.WriteLine("Введены некорректные данные!");
                    inputBirthday();
                }
                else
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        char[] c = words[i].ToCharArray();
                        for (int j = 0; j < c.Length; j++)
                        {
                            if (char.IsDigit(c[j]))
                            {
                                trueLetter = true;
                            }
                            else
                            {
                                Console.WriteLine("Введены некорректные данные!");
                                inputBirthday();
                                trueLetter = false;
                                break;
                            };
                        }
                    }
                    if (trueLetter)
                    {
                        birthday = birthdayLocal;
                    }
                }
            }
            else { Console.WriteLine("Введены некорректные данные!"); inputBirthday(); }

        }

        public void inputAge()
        {
            //String ageLocal = " ";
            bool trueLetter = true;
            Console.Write("Введите возраст: ");
            //ageLocal = Console.ReadLine();
            Console.ReadKey();
            Console.WriteLine();
            for (int i = 0; i < ageLocal.Length; i++)
            {
                if (char.IsDigit(ageLocal[i]))
                {
                    trueLetter = true;
                }
                else
                {
                    Console.WriteLine("Введены некорректные данные!"); inputAge();
                    trueLetter = false;
                    break;
                }
            }
            if (trueLetter)
            {
                age = ageLocal;
            }
        }

        public void inputWorkExperience()
        {
            //String workExperienceLocal = " ";
            bool trueLetter = true;
            Console.Write("Введите стаж работы сотрудника: ");
            //workExperienceLocal = Console.ReadLine();
            Console.ReadKey();
            Console.WriteLine();
            for (int i = 0; i < workExperienceLocal.Length; i++)
            {
                if (char.IsDigit(workExperienceLocal[i]))
                {
                    trueLetter = true;
                }
                else
                {
                    Console.WriteLine("Введены некорректные данные!"); inputWorkExperience();
                    trueLetter = false;
                    break;
                }
            }
            if (trueLetter)
            {
                workExperience = workExperienceLocal;
            }
        }

        public void inputPosition()
        {
            //String positionLocal = " ";
            bool trueLetter = true;
            Console.Write("Введите должность сотрудника: ");
            //positionLocal = Console.ReadLine();
            Console.ReadKey();
            Console.WriteLine();
            for (int i = 0; i < positionLocal.Length; i++)
            {
                if (char.IsLetter(positionLocal[i]))
                {
                    trueLetter = true;
                }
                else
                {
                    Console.WriteLine("Введены некорректные данные!"); inputPosition();
                    trueLetter = false;
                    break;
                }
            }
            if (trueLetter)
            {
                position = positionLocal;
            }
        }
    }
}
