using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _5._1._BACKUP_SYSTEM
{
    public class Backup
    {
        private string StoragePath { get; }
        private string BackupPath { get; }
        public DateTime DateAndTime { get; set; }

        #region CONSTRUCTORS
        public Backup()
        {   //Адаптивные пути
            StoragePath = $@"{Environment.CurrentDirectory}\STORAGE";
            BackupPath = $@"{Environment.CurrentDirectory}\BACKUP";
        }

        public Backup(string backupPath, string storagePath)
        {
            this.StoragePath = storagePath;
            this.BackupPath = backupPath;
        }
        #endregion
        #region ROLLBACK
        public void RollBack()
        {   //Берем абсолютно всё из сториджа
            var storageInfo = new DirectoryInfo(StoragePath);
            var whollyStorage = storageInfo.GetFiles("*.txt", SearchOption.AllDirectories);
            //Берем абсолютно всё из бэкапа
            var backupInfo = new DirectoryInfo(BackupPath);
            var whollyBackup = backupInfo.GetFiles("*.txt", SearchOption.AllDirectories);

            foreach (var storageFile in whollyStorage)
            {
                //Это имя должно быть таковым directoryFullNameInBackup, но для краткости написал иначе -
                //т.е. это полное имя директории которая называется именем файла, и в которой находятся все его копии.
                string directoryName;
                //Это строка представляет собой имя файла, которым называется папка в бэкапе.
                string nameFileDirectory = Path.GetFileNameWithoutExtension(storageFile.Name);

                //Проверяем находится ли файл в корневой директории
                if (storageFile.DirectoryName != storageInfo.FullName)
                {//Находим название поддиректории в которой находится файл
                    string nameSubDirectoryOfFile = storageFile.Directory.FullName.Remove(0, StoragePath.Length);
                    directoryName = $@"{BackupPath}{nameSubDirectoryOfFile}\{nameFileDirectory}";
                }
                else
                {
                    directoryName = $@"{BackupPath}\{nameFileDirectory}";
                }
                //Далее берем все версии одного рассматриваемого файла на этой итерации цикла,
                //посредством фильтрации через полное имя директории, в которой хранятся эти копии 
                //(т.е это имя самого файла без расширения)
                var backupVersionsOfFile = whollyBackup.Where(x => x.DirectoryName == directoryName)
                                              .OrderByDescending(x => x.Name);

                foreach (var versionOfFile in backupVersionsOfFile)
                {   //Вычленяем дату из имени версии файла и преобразуем к объекту типа DateTime
                    var strDateOfVersion = versionOfFile.Name.Substring(0, versionOfFile.Name.LastIndexOf('-'));
                    DateTime.TryParseExact(strDateOfVersion, "dd.MM.yyyy HH.mm", null, DateTimeStyles.None, out DateTime date);
                    //Сравниваем дату версии файла с датой, введенной пользователем
                    if (date.Date <= DateAndTime.Date)
                    {//Сравниваем даты при помощи тактов.
                        if (date.Ticks <= DateAndTime.Ticks)
                        {
                            // Берем содержимое подходящего бэк-файла и вставляем его в сторидж-файл
                            var text = File.ReadAllText(versionOfFile.FullName);
                            File.WriteAllText(storageFile.FullName, text);

                            // Получим имя из имени(с датой) версии бэк-файла.
                            var name = versionOfFile.Name.Substring(versionOfFile.Name.LastIndexOf('-') + 1);

                            directoryName = $@"{versionOfFile.Directory.Parent.FullName}\{name.Substring(0, name.LastIndexOf('.'))}";

                            if (versionOfFile.DirectoryName != directoryName)
                            {
                                Directory.Move(versionOfFile.DirectoryName, directoryName);
                            }
                            //Формируем полное имя версии файла для того чтобы заменить им полное имя файла в сторидже.
                            var fullName = $@"{storageFile.DirectoryName}\{name}";
                            storageFile.MoveTo(fullName);
                            break;
                        }
                    }
                }
            }
        }
        #endregion
    }
}