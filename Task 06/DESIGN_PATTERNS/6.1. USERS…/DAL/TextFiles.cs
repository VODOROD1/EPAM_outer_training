using _6._1.USERS_.Common;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.IO;

namespace _6._1.USERS_.DAL
{
    class TextFiles : IStorable
    {
        public static string JsonDirectoryPath { get; private set; } = $@"{Environment.CurrentDirectory}\JsonDirectory";
        public static string JsonFilePath { get; private set; } = $@"{Environment.CurrentDirectory}\JsonDirectory\JsonFile.txt";
        private string serialized = "";
        private Storage storage;

        public TextFiles()
        {
            Directory.CreateDirectory(JsonDirectoryPath);
            SetBaseSerialized();
            SetBaseSerialized();
        }
        //Создаю базовую информацию потому как не до конца разобрался с Newtonsoft.Json
        //Поэтому этот набор базовых объектов нельзя удалять
        public void SetBaseSerialized()
        {
            storage = new Storage();
            Award award = new Award {Title = "BaseAward", Id=Guid.NewGuid() };
            DateTime birthDay = DateTime.ParseExact("05.11.2001", "dd.MM.yyyy", null);
            User user = new User {Name = "BaseUser1", BirthDay = birthDay, Age = 34, Id = Guid.NewGuid() };
            storage.Users.Add(user);
            storage.Awards.Add(award);
            storage.AwardsUsers.Add(new AwardsAndUsers { UserId = user.Id, AwardId = award.Id });
            
                Award award1 = new Award { Title = "BaseAward1", Id = Guid.NewGuid() };
                Award award2 = new Award { Title = "BaseAward2", Id = Guid.NewGuid() };
                DateTime birthDay1 = DateTime.ParseExact("05.11.2001", "dd.MM.yyyy", null);
                User user1 = new User { Name = "BaseUser2", BirthDay = birthDay1, Age = 68, Id = Guid.NewGuid() };
                storage.Users.Add(user1);
                storage.Awards.Add(award1);
                storage.Awards.Add(award2);
                storage.AwardsUsers.Add(new AwardsAndUsers { UserId = user1.Id, AwardId = award1.Id });
                storage.AwardsUsers.Add(new AwardsAndUsers { UserId = user1.Id, AwardId = award2.Id });

            Serialize();
            RecordInFile();
        }
        #region SERIALIZE_DESERIALIZE
        public void Serialize()
        {
            serialized = "";
            serialized = JsonConvert.SerializeObject(storage, Formatting.Indented);
        }
        public void DeSerialize()
        {
            storage = JsonConvert.DeserializeObject<Storage>(serialized);
        }
        #endregion
        #region RECORD_READ_FILE
        public void RecordInFile()
        {
            File.WriteAllText(JsonFilePath, serialized, System.Text.Encoding.Default);
        }
        public void ReadFromFile()
        {
            serialized = "";
            serialized = File.ReadAllText(JsonFilePath);
            //Console.WriteLine(serialized); //!!!!!!!!!!!!
        }
        #endregion
        #region ADD_REMOVE
        public void AddUser(User user)
        {
            ReadFromFile();
            DeSerialize();
            storage.Users.Add(user);
            Serialize();
            RecordInFile();
        }
        public void AddNewAward(Award award)
        {
            ReadFromFile();
            DeSerialize();
            storage.Awards.Add(award);
            Serialize();
            RecordInFile();
        }
        public void AddAwardForUser(User user, Award award)
        {
            //добавляем новую награду пользователю
            ReadFromFile();
            DeSerialize();
            storage.AwardsUsers.Add(new AwardsAndUsers { UserId = user.Id, AwardId = award.Id });
            Serialize();
            RecordInFile();
        }
        public void RemoveUser(User user)
        {
            ReadFromFile();
            DeSerialize();
            foreach (User u in storage.Users)
            {
                if (u.Id == user.Id)
                {
                    storage.Users.Remove(u);
                }
            }
            foreach (AwardsAndUsers aau in storage.AwardsUsers)
            {
                if (aau.UserId == user.Id)
                {
                    storage.AwardsUsers.Remove(aau);
                }
            }
            Serialize();
            RecordInFile();
        }
        #endregion
        #region GET
        public IList<User> GetAllUsers()
        {
            ReadFromFile();
            DeSerialize();
            return storage.Users;
        }
        public IList<Award> GetAllAwards()
        {
            ReadFromFile();
            DeSerialize();
            return storage.Awards;
        }
        public IList<AwardsAndUsers> GetAllAwardsUsers()
        {
            ReadFromFile();
            DeSerialize();
            return storage.AwardsUsers;
        }
        #endregion
    }
}