using _3_Layer_Arch.BLL.Interfaces;
using _3_Layer_Arch.Common;
using _3_Layer_Arch.PL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Layer_Arch.ConsolePL
{
    class ConsoleUI : IUI
    {
        IManager UsersAwardsManager;
        CheckUserAttributes CheckUA;
        public ConsoleUI()
        {
            UsersAwardsManager = DependencyResolver.UsersAwardsManager;
            CheckUA = new CheckUserAttributes();
            SelectOption();
        }
        #region SELECT_OPTION
        public void SelectOption()
        {
            String name = "";
            String birthDay = "";
            String age = "";
            while (true)
            {
                Console.WriteLine("Выберите действие:\n " +
                "\t\t 1) Создать нового пользователя\n " +
                "\t\t 2) Удалить пользователя\n " +
                "\t\t 3) Посмотреть список всех пользователей\n" +
                "\t\t 4) Манипуляции с наградами\n" +
                "\t\t 5) Выход\n");

                char key = Console.ReadKey(true).KeyChar;
                if (char.IsDigit(key) && (uint)Char.GetNumericValue(key) <= 5)
                {
                    switch (key)
                    {
                        case '1':
                            AskUserAttributes(name, birthDay, age);
                            break;
                        case '2':
                            AskDeleteUser();
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
        #endregion
        #region MANIPULATION_WITH_AWARD
        public void ManipulationWithAward()
        {
            while (true)
            {
                Console.WriteLine(
                "\t\t 1) Добавить новую награду в общий перечень наград\n" +
                "\t\t 2) Добавить награду из общего перечня в перечень какого-либо пользователя\n" +
                "\t\t 3) Просмотр перечня вообще всех наград\n " +
                "\t\t 4) Просмотр перечня наград какого-либо пользователя\n" +
                "\t\t 5) Назад\n");

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
        #endregion
        #region ASK_NEW_USER
        public void AskUserAttributes(String name, String birthDay, String age)
        {
            Console.WriteLine("Введите атрибуты пользователя:");
            AskName(out name);
            AskDate(out birthDay);
            AskAge(out age);
            if (AddUser(name, birthDay, age))
            {
                Console.WriteLine("Пользователь успешно добавлен!");
            }
            else { Console.WriteLine("Не удалось добавить пользователя!"); }
        }
        public void AskName(out String name)
        {
            bool temp = false;
            name = default;
            while (!temp)
            {
                Console.Write("\t - Имя (буквами):");
                String inputName = Console.ReadLine();
                temp = CheckUA.CheckName(inputName);
                if (!temp) { Console.WriteLine("Введите имя правильно!"); }
                name = inputName;
            }
        }
        public void AskDate(out String birthDay)
        {
            bool temp = false;
            birthDay = default;
            String inputDate = " ";
            while (!temp)
            {
                Console.Write("\t - Дата рождения (Шаблон dd.MM.yyyy):");
                inputDate = Console.ReadLine();
                temp = CheckUA.CheckDate(inputDate);
                if (!temp) { Console.WriteLine("Введите дату в соответствии с шаблоном!"); }
            }
            birthDay = inputDate;
        }
        public void AskAge(out String age)
        {
            bool temp = false;
            age = default;
            while (!temp)
            {
                Console.Write("\t - Возраст (цифрами):");
                string inputAge = Console.ReadLine();
                temp = CheckUA.CheckAge(inputAge);
                if (!temp) { Console.WriteLine("Введите возраст цифрами!"); }
                age = inputAge;
            }
        }
        #endregion
        //Добавить новую награду в общий перечень наград
        #region ASK_NEW_AWARD
        public void AskNewAward()
        {
            bool cycle = false;
            while (!cycle)
            {
                Console.Write("Введите название добавляемой награды:");
                String awardTitle = Console.ReadLine();
                cycle = AddAward(awardTitle);
                if (cycle)
                {
                    Console.WriteLine("Награда успешно добавлена!");
                }
                else { Console.WriteLine("Эта награда уже присутствует, добавьте другую!"); }
            }
        }
        #endregion
        //Спросить какую награду из общего перечня нужно добавить в перечень какого пользователя
        #region ASK_AWARD_FOR_USER
        public void AskAwardForUser()
        {
            bool b1 = true;
            bool b2 = true;
            bool b3 = false;
            String userKey = "";
            String awardKey = "";
            while (!b3)
            {
                while (b1)
                {
                    Console.WriteLine("Выберите пользователя, которому хотите вручить награду!");
                    ShowAllUsers();
                    char input = Console.ReadKey(true).KeyChar;
                    var users = UsersAwardsManager.GetAllUsers();

                    if (char.IsDigit(input) && (uint)Char.GetNumericValue(input) <= users.Count)
                    {
                        userKey = input.ToString();
                        b1 = false;
                        break;
                    }
                    else { Console.WriteLine("Введите корректное число!"); }
                }
                while (b2)
                {
                    Console.WriteLine("Выберите награду, которую хотите вручить!");
                    ShowAllAwards();
                    char input = Console.ReadKey(true).KeyChar;
                    var awards = UsersAwardsManager.GetAllAwards();

                    if (char.IsDigit(input) && (uint)Char.GetNumericValue(input) <= awards.Count)
                    {
                        awardKey = input.ToString();
                        b2 = false;
                        break;
                    }
                    else { Console.WriteLine("Введите корректное число!"); }
                }

                if (!b1 && !b2)
                {
                    //Добавляем юзера и награду в общую сущность
                    b3 = AddAwardForUser(userKey, awardKey);
                }
                if (b3)
                {
                    Console.WriteLine("Награда успешно добавлена в перечень пользователя!");
                }
                else { Console.WriteLine("Такая награда уже имеется у этого пользователя!"); }
            }
        }
        #endregion
        #region ADD
        public bool AddUser(String name, String birthDay, String age)
        {
            return UsersAwardsManager.AddUser(name, birthDay, age);
        }
        public bool AddAward(string awardTitle)
        {
            return UsersAwardsManager.AddNewAward(awardTitle);
        }
        public bool AddAwardForUser(String userKey, String awardKey)
        {
            return UsersAwardsManager.AddAwardForUser(userKey, awardKey);
        }
        #endregion
        #region SHOW
        public void ShowAllUsers()
        {
            Console.WriteLine("Перечень всех пользователей:");
            int i = 0;
            foreach (String[] user in GetAllUsers())
            {
                ++i;
                Console.Write($"\t\t{i}) {user[1]} - ");
                Console.Write($"{user[2]} - ");
                Console.Write($"{user[3]}");
                Console.WriteLine();
            }
        }
        public void ShowAllAwards()
        {
            Console.WriteLine("Перечень всех наград:");
            int i = 0;
            foreach (String[] award in GetAllAwards())
            {
                ++i;
                Console.WriteLine($"\t\t{i}) {award[1]}");
            }
        }
        public void ShowAllAwardsOfUser()
        {
            Console.WriteLine("Выберите пользователя, награды которого вы хотите посмотреть!");
            ShowAllUsers();
            //Console.Write("Выбор:");
            char input = Console.ReadKey(true).KeyChar;
            var users = GetAllUsers();
            String userGuid;
            if (char.IsDigit(input) && (uint)Char.GetNumericValue(input) <= users.Count)
            {
                int key = (int)Char.GetNumericValue(input);
                userGuid = users[key - 1][0];
                //По гуиду находим выбранного пользователя
                IList<String[]> a = GetAllAwardsUsers();
                if (a.Count != 0)
                {
                    Console.WriteLine("Перечень всех наград пользователя!");
                    var someAwardsUsers = a.Where(p => p[0] == userGuid).ToList();
                    foreach (String[] aau in someAwardsUsers)
                    {
                        foreach (String[] award in GetAllAwards())
                        {
                            if (award[0] == aau[0])
                            {
                                Console.WriteLine($"\t\t- {award[1]}");
                            }
                        }
                    }
                }
                else { Console.WriteLine("У этого пользователя нет наград!"); }
            }
            else
            {
                Console.WriteLine("Введите корректное число!");
                ShowAllAwardsOfUser();
            }
        }
        #endregion
        #region DELETE
        public void AskDeleteUser()
        {
            while (true)
            {
                Console.WriteLine("Выберите пользователя, которого вы хотите удалить!");
                ShowAllUsers();
                char input = Console.ReadKey(true).KeyChar;
                IList<String[]> users = UsersAwardsManager.GetAllUsers();
                if (char.IsDigit(input) && (uint)Char.GetNumericValue(input) <= users.Count)
                {
                    int id = (int)Char.GetNumericValue(input) - 1;
                    DeleteUser(id);
                    break;
                }
                else { Console.WriteLine("Введите корректное число!"); }
            }
        }
        public void DeleteUser(int id)
        {
            UsersAwardsManager.DeleteUser(id);
        }
        public void DeleteAward(int id)
        {
            throw new NotImplementedException();
        }
        public void DeleteAwardFromUser(String userGuid, String awardGuid)
        {
            throw new NotImplementedException();
        }
        public void DeleteAwardFromUsers(String awardGuid)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region EDIT
        public bool EditUser()
        {
            throw new NotImplementedException();
        }
        public bool EditAward()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region GET
        public IList<string[]> GetAllUsers()
        {
            return UsersAwardsManager.GetAllUsers();
        }

        public IList<string[]> GetAllAwards()
        {
            return UsersAwardsManager.GetAllAwards();
        }

        public IList<string[]> GetAllAwardsUsers()
        {
            return UsersAwardsManager.GetAllAwardsUsers();
        }

        public bool EditUser(string guid, string name, string date, string age)
        {
            throw new NotImplementedException();
        }

        public bool EditAward(string guid, string name)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
