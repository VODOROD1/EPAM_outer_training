using _6._1.USERS_.Common;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.IO;

namespace _6._1.USERS_.DAL
{
    class TextFiles : IStorable
    {
        //private static List <User> Users{ get; set; }
        //private static List<Award> Awards { get; set; }
        //private static List<AwardsAndUsers> AwardsUsers { get; set; }
        public static string JsonDirectoryPath { get; private set; } = $@"{Environment.CurrentDirectory}\JsonDirectory";
        public static string JsonFilePath { get; private set; } = $@"{Environment.CurrentDirectory}\JsonDirectory\JsonFile.txt";
        //JsonSerializer serializer = new JsonSerializer();
        private string serialized = " ";
        private Storage storage;
        public TextFiles()
        {
            Directory.CreateDirectory(JsonDirectoryPath);
            storage = new Storage();
            //Users = new List<User>();
            //Awards = new List<Award>();
            //AwardsUsers = new List<AwardsAndUsers>();
            //storage.Users = Users;
            //storage.Awards = Awards;
            //storage.AwardsUsers = AwardsUsers;
            //Serialize();
            //FirstRecordInFile();
        }
        #region SERIALIZE_DESERIALIZE
        public void Serialize()
        {
            serialized = JsonConvert.SerializeObject(storage);
        }
        public void DeSerialize()
        {
            Storage storage = JsonConvert.DeserializeObject<Storage>(serialized);
        }
        #endregion
        #region RECORD_READ_FILE
        public void RecordInFile()
        {
            //File.AppendText(serialized);
            File.WriteAllText(JsonFilePath, serialized, System.Text.Encoding.Default);
        }
        public void ReadFromFile()
        {
            serialized = File.ReadAllText(JsonFilePath);
        }
        #endregion
        #region ADD_DELETE
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