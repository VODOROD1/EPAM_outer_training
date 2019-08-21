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
        {   //Возможно здесь и не нужно содавать напрямую директорию, но я создал на всякий случай
            Directory.CreateDirectory(JsonDirectoryPath);
            SetBaseSerialized();
            SetBaseSerialized();
        }
        //Создаем базовую информацию потому как не до конца разобрался с Newtonsoft.Json
        //Не получится десериализовать файл в котором будет не заполнена хотя бы одна коллекция -
        //- содержимое файла не будет соответствовать структуре класса Storage
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
        //добавляем новую награду пользователю
        public void AddAwardForUser(User user, Award award)
        {
            ReadFromFile();
            DeSerialize();
            //Добавляем в обобщающую сущность полученные объекты
            storage.AwardsUsers.Add(new AwardsAndUsers { UserId = user.Id, AwardId = award.Id });
            Serialize();
            RecordInFile();
        }
        public void RemoveUser(Guid userGuid)
        {//применяем анонимные методы для удаления всех тех сущностей, которые имеют GUID равный GUID выбранного юзера
            storage.Users.RemoveAll(x => x.Id == userGuid);
            storage.AwardsUsers.RemoveAll(x => x.UserId == userGuid);
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