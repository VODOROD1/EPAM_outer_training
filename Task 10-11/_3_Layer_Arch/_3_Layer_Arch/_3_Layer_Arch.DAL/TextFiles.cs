using _3_Layer_Arch.DAL;
using _3_Layer_Arch.DAL.Interfaces;
using _3_Layer_Arch.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Layer_Arch.FileDAL
{
    public class TextFiles : IStorable
    {
        public static string JsonDirectoryPath { get; private set; } = $@"{Environment.CurrentDirectory}\JsonDirectory";
        public static string JsonFilePath { get; private set; } = $@"{Environment.CurrentDirectory}\JsonDirectory\JsonFile.txt";
        private string serialized = "";
        private Storage storage;
        int userId = 0;
        int awardId = 0;

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
            ++awardId;
            ++userId;
            Award award = new Award { Title = "BaseAward1", Id = awardId };
            DateTime birthDay = DateTime.ParseExact("05.11.2001", "dd.MM.yyyy", null);
            User user = new User { Name = "A", BirthDay = birthDay, Age = 34, Id = userId };
            storage.Users.Add(user);
            storage.Awards.Add(award);
            storage.AwardsUsers.Add(new AwardsAndUsers { UserId = user.Id, AwardId = award.Id });

            Award award2 = new Award { Title = "BaseAward2", Id = awardId };
            DateTime birthDay2 = DateTime.ParseExact("15.06.2003", "dd.MM.yyyy", null);
            User user2 = new User { Name = "B", BirthDay = birthDay2, Age = 24, Id = userId };
            storage.Users.Add(user2);
            storage.Awards.Add(award2);
            storage.AwardsUsers.Add(new AwardsAndUsers { UserId = user2.Id, AwardId = award2.Id });
            storage.AwardsUsers.Add(new AwardsAndUsers { UserId = user2.Id, AwardId = award.Id });

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
            ++userId;
            user.Id = userId;
            storage.Users.Add(user);
            Serialize();
            RecordInFile();
        }
        public void AddNewAward(Award award)
        {
            ReadFromFile();
            DeSerialize();
            ++awardId;
            award.Id = awardId;
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
        #region EDIT
        public void EditUser(String id, User newUser)
        {
            newUser.Id = int.Parse(id);
            IList<User> users = GetAllUsers();
            int index = users.IndexOf(users.Where(u => u.Id == newUser.Id).FirstOrDefault());
            users[index] = newUser;
            Serialize();
            RecordInFile();
        }

        public void EditAward(String id, Award award)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region REMOVE
        public void RemoveUser(int id)
        {//применяем анонимные методы для удаления всех тех сущностей, которые имеют GUID равный GUID выбранного юзера
            storage.Users.RemoveAll(x => x.Id == id);
            storage.AwardsUsers.RemoveAll(x => x.UserId == id);
            Serialize();
            RecordInFile();
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
    }
}
