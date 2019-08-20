using _6._1.USERS_.BLL;
using _6._1.USERS_.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.USERS_.PL
{
    class ConsoleUI : IUI
    {
        UsersAwardsManager UAM = new UsersAwardsManager();
        CheckUserAttributes CheckUA = new CheckUserAttributes();
        public void SelectOption()
        {
            String name;
            DateTime birthDay;
            uint age;
            Console.WriteLine("Выберите действие:\n " +
                "\t\t 1) Создать нового пользователя\n " +
                "\t\t 2) Удалить пользователя\n " +
                "\t\t 3) Посмотреть список всех пользователей\n" +
                "\t\t 4) Манипуляции с наградами\n" +
                "\t\t 5) Выход\n");
            while (true)
            {
                char key = Console.ReadKey(true).KeyChar;
                if (char.IsDigit(key) && (uint)Char.GetNumericValue(key) <= 5)
                {
                    switch (key)
                    {
                        case '1':
                            AskUserAttributes(out name, out birthDay, out age);
                            UAM.AddUser(name, birthDay, age);
                            break;
                        case '2':
                            DeleteUser();
                            break;
                        case '3':
                            ShowAllUsers();
                            Console.ReadKey();
                            break;
                        case '4':
                            ManipulationWithAward();
                            break;
                        case '5':
                            return;
                    }
                }
            }
        }
        public void ManipulationWithAward()
        {
            Console.WriteLine(
                "\t 1) Добавить новую награду в общий перечень наград\n" +
                "\t 2) Добавить награду из общего перечня в перечень какого-либо пользователя\n" +
                "\t 3) Просмотр перечня вообще всех наград\n " +
                "\t 4) Просмотр перечня наград какого-либо пользователя\n" +
                "\t 5) Назад\n");
            while (true)
            {
                char key = Console.ReadKey(true).KeyChar;
                if (char.IsDigit(key) && (uint)Char.GetNumericValue(key) <= 5)
                {
                    switch (key)
                    {
                        case '1':
                            AskNewAward();
                            break;
                        case '2':
                            AskAwardForUser();
                            break;
                        case '3':
                            ShowAllAwards();
                            Console.ReadKey();
                            break;
                        case '4':
                            ShowAllAwardsOfUser();
                            Console.ReadKey();
                            break;
                        case '5':
                            return;
                    }
                }
            }
        }
        public void ShowAllAwards()
        {
            Console.WriteLine("Перечень всех наград:");
            int i = 0;
            foreach (Award award in UAM.GetAllAwards())
            {
                ++i;
                Console.WriteLine($"\t\t{i}) {award.Title}");
            }
        }
        public void ShowAllUsers()
        {
            Console.WriteLine("Перечень всех пользователей:");
            int i = 0;
            foreach (User user in UAM.GetAllUsers())
            {
                ++i;
                Console.Write($"\t\t{i}) {user.Name} - ");
                Console.Write($"{user.BirthDay} - ");
                Console.Write($"{user.Age}");
                Console.WriteLine();
            }
        }
        #region SHOW_ALL_AWARDS_OF_USER
        public void ShowAllAwardsOfUser()
        {
            Console.WriteLine("Выберите пользователя, награды которого вы хотите посмотреть!");
            ShowAllUsers();
            char key = Console.ReadKey(true).KeyChar;
            Guid userGuid;
            if (char.IsDigit(key) && (uint)Char.GetNumericValue(key) <= 5)
            {
                userGuid = UAM.GetAllUsers()[key - 1].Id;
                Console.WriteLine("Перечень всех наград пользователя");
                var someAwardsUsers = UAM.GetAllAwardsUsers().Where(p => p.UserId == userGuid);
                foreach (AwardsAndUsers aau in someAwardsUsers)
                {
                    foreach (Award award in UAM.GetAllAwards())
                    {
                        if (award.Id == aau.AwardId)
                        {
                            Console.WriteLine($"\t\t- {award.Title}");
                        }
                    } 
                }
            }
            else { Console.WriteLine("Введите корректное число!");
                ShowAllAwardsOfUser();
            }
        }
        #endregion
        //Спросить о добавлении награды из общего перечня в перечень какого-либо пользователя
        #region ASK_AWARD_FOR_USER
        public void AskAwardForUser()
        {
            bool b1 = true;
            bool b2 = true;
            Guid userGuid = default;
            Guid awardGuid = default;
            while (b1) {
                Console.WriteLine("Выберите пользователя, которому хотите вручить награду!");
                ShowAllUsers();
                char key = Console.ReadKey(true).KeyChar;
                var users = UAM.GetAllUsers();
                
                if (char.IsDigit(key) && (uint)Char.GetNumericValue(key) <= users.Count)
                {
                    userGuid = users[key - 1].Id;
                    b1 = false;
                    continue;
                }
                else { Console.WriteLine("Введите корректное число!"); }
            }
            while (b2)
            {
                Console.WriteLine("Выберите награду, которую хотите вручить!");
                ShowAllAwards();
                char key = Console.ReadKey(true).KeyChar;
                var awards = UAM.GetAllAwards();

                if (char.IsDigit(key) && (uint)Char.GetNumericValue(key) <= awards.Count)
                {
                    awardGuid = awards[key - 1].Id;
                }
                else { Console.WriteLine("Введите корректное число!"); }

                //проверяем есть уже ли у пользователя такая награда
                bool k = true;
                foreach (var awardUser in UAM.GetAllAwardsUsers())
                {
                    if (awardUser.UserId == userGuid && awardUser.AwardId == awardGuid)
                    {
                        Console.WriteLine("Такая награда уже имеется у этого пользователя!");
                        b2 = true;
                        break;
                    }
                    else { b2 = false; }
                }
            }
            
            if (!b1 && !b2) {
                UAM.AddAwardForUser(userGuid, awardGuid);
            }
        }                   
        #endregion
        //Добавить новую награду в общий перечень наград
        #region ASK_NEW_AWARD
        public void AskNewAward()
        {
            var awards = UAM.GetAllAwards();
            bool cycle = true;
            while (cycle)
            {
                Console.Write("Введите название новой награды:");
                String awardTitle = Console.ReadLine();

                bool k = true;
                //проверяем нет ли в перечене наград вводимой награды
                foreach (var award in awards)
                {
                    if (award.Title == awardTitle)
                    {
                        k = false;
                        Console.WriteLine("Такая награда уже существует!");
                        break;
                    }
                    }
                    if (k)
                    {
                        UAM.AddNewAward(awardTitle);
                        cycle = false;
                    }
                    k = true;
            }
        }
        #endregion
        #region ASK_NEW_USER
        public void AskUserAttributes(out String name, out DateTime birthDay, out uint age)
        {
            Console.WriteLine("Введите атрибуты пользователя:");
            AskName(out name);
            AskDate(out birthDay);
            AskAge(out age);
        }
        public void AskName(out String name)
        {
            bool temp = false;
            name = default;
            while (!temp)
            {
                Console.Write("\t - Имя:");
                String inputName = Console.ReadLine();
                temp = CheckUA.CheckName(inputName);
                name = inputName;
            }
        }
        public void AskDate(out DateTime birthDay)
        {
            bool temp = false;
            birthDay = default;
            while (!temp) {
                Console.Write("\t - Дата рождения (Шаблон dd.MM.yyyy HH:mm):");
                String inputDate = Console.ReadLine();
                temp = CheckUA.CheckDate(inputDate);
                birthDay = DateTime.Parse(inputDate);
            }
        }
        public void AskAge(out uint age)
        {
            bool temp = false;
            age = default;
            while (!temp) {
                Console.Write("\t - Возраст:");
                string inputAge = Console.ReadLine();
                temp = CheckUA.CheckAge(inputAge);
                age = Convert.ToUInt32(Console.ReadLine());
            }
        }
        #endregion
        public void DeleteUser()
        {
            
        }
    }
}
