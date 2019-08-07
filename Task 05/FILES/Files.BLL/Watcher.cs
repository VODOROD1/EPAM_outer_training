using System;
using System.IO;
using System.Linq;
using System.Threading;


namespace _5._1._BACKUP_SYSTEM
{
    //Здесь представлен класс, который следит за изменениями файлов,
    //и если таковые были, то создает их копии в папку BACKUP.
    public class Watcher
    {   //Поле типа класса FileSystemWatcher, который ожидает уведомления файловой системы 
        //об изменениях и инициирует события при изменениях каталога или файла в каталоге.
        public FileSystemWatcher FSW { get; protected set; }
        //Адаптивные путь до директории хранения бэкапа
        public static string PathBackup { get; private set; } = $@"{Environment.CurrentDirectory}\BACKUP";

        #region CONSTRUCTORS
        public Watcher()
        {   //Адаптивный путь до директории хранения текстовых файлов
            string pathStorage = $@"{Environment.CurrentDirectory}\STORAGE";
            //Создадим и опишем объект класса FileSystemWatcher
            FSW = new FileSystemWatcher();
            // фильтр расширения файлов, которые будут отслеживаться программой
            FSW.Filter = "*.*";
            //фильтры по которым будут происходить события
            FSW.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            FSW.Path = pathStorage;
            //Подключение мониторинга подпапок
            FSW.IncludeSubdirectories = true;

            //Далее подписываем обработчики событий
            FSW.Changed += OnChangeOrCreate;
            FSW.Created += OnChangeOrCreate;
            FSW.Renamed += OnRename;
            FSW.Deleted += OnDelete;
            FSW.Error += OnError;
        }

        public Watcher(string pathStorage, string pathBackup)
        {
            PathBackup = pathBackup;


            FSW = new FileSystemWatcher(pathStorage)
            {
                Filter = "*.*",
                NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName,
                IncludeSubdirectories = true
            };


            FSW.Changed += OnChangeOrCreate;
            FSW.Created += OnChangeOrCreate;
            FSW.Renamed += OnRename;
            FSW.Deleted += OnDelete;
        }
        #endregion
        //Обработчик, отрабатывающий при изменении или создании директории/файла
        #region CHANGE_CREATE
        private static void OnChangeOrCreate(object sender, FileSystemEventArgs e)
        {
            if (e != null)
            {
                var someObj = new FileInfo(e.FullPath);
                //Проверяем является ли изменяемый объект директорией
                if (someObj.Attributes == FileAttributes.Directory)
                {
                    string newPath = $@"{Environment.CurrentDirectory}\BACKUP\{e.Name}";

                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }
                }
                else if (someObj.Length != 0) { CreateBackup(e); }

                Console.WriteLine("Directory changed({0}): {1}", e.ChangeType, e.FullPath);
            }
        }
        #endregion
        //Обработчик, отрабатывающий при переименовании директории/файла
        #region RENAME
        private static void OnRename(object sender, RenamedEventArgs e)
        {
            if (e != null)
            {
                var extension = Path.GetExtension(e.OldName);

                //Если переименованию был подвергнут файл, то вызывается обработчик RenameDirectory
                if (extension != "")
                {
                    RenameBackupDirectory(e);
                    CreateBackup(e);
                }
                else
                {
                    string oldPath = $@"{Environment.CurrentDirectory}\Backup\{e.OldName}\";


                    if (Directory.Exists(oldPath))
                    {
                        string newPath = $@"{Environment.CurrentDirectory}\Backup\{e.Name}\";

                        try
                        {
                            Directory.Move(oldPath, newPath);
                        }
                        catch
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(0.3));
                            Directory.Move(e.FullPath, e.OldFullPath);
                        }
                    }
                }
                Console.WriteLine("Renamed from {0} to {1}", e.OldFullPath, e.FullPath);
            }
        }
        #endregion
        //Обработчик, отрабатывающий при удалении директории/файла
        #region DELETE
        private void OnDelete(object sender, FileSystemEventArgs e)
        {
            if (e != null)
            {
                bool isTryAgain = false;
                string nameDirectory = "";
                string backupPath = $@"{PathBackup}\{e.Name}";
                bool isExists = Directory.Exists(backupPath);

                if (!isExists)
                {
                    isTryAgain = true;

                    nameDirectory = e.Name.Substring(0, e.Name.LastIndexOf('.'));
                    backupPath = $@"{PathBackup}\{nameDirectory}";

                    isExists = Directory.Exists(backupPath);
                }
                if (isExists)
                {
                    bool isContaintsSub = Directory.GetFileSystemEntries(backupPath).Any();

                    if (isContaintsSub)
                    {
                        string dateTimeRemoved = DateTime.Now.ToString("dd.MM.yyyy HH.mm");
                        dateTimeRemoved = $@"Removed_{dateTimeRemoved}_";

                        if (isTryAgain)
                            nameDirectory = nameDirectory.Insert(nameDirectory.LastIndexOf('\\') + 1, dateTimeRemoved);
                        else
                            nameDirectory = e.Name.Insert(e.Name.LastIndexOf('\\') + 1, dateTimeRemoved);

                        string newBackupPath = $@"{PathBackup}\{nameDirectory}";

                        Directory.Move(backupPath, newBackupPath);
                    }
                    else
                        Directory.Delete(backupPath);
                }
                Console.WriteLine("Directory changed({0}): {1}", e.ChangeType, e.FullPath);
            }
        }
        #endregion
        //Обработчик, отрабатывающий при в случае возникновения ошибки
        #region ERROR
        private void OnError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("Error {0}", e.GetException());
        }
        #endregion
        //Метод для внесения в бэкап измененного файла
        #region CREATE_BACKUP
        private static void CreateBackup(FileSystemEventArgs e)
        {
            if (e != null)
            {
                string directoryInBackUp;
                string dateTime = DateTime.Now.ToString("dd.MM.yyyy HH.mm");//дата создания бэка
                string fileName = Path.GetFileNameWithoutExtension(e.Name); //берем имя файла без расширения
                string backupFileName = $"{dateTime}-{fileName}.txt";      //название измененного файла, который перенесен в бэкап

                string subdirectory = Path.GetDirectoryName(e.Name);        //Получаем путь до папки в которой лежит файл
                //Если файл не лежит прямо в корне
                if (subdirectory == "")
                {
                    directoryInBackUp = $@"{PathBackup}\{fileName}\";
                }
                else
                {
                    directoryInBackUp = $@"{PathBackup}\{subdirectory}\{fileName}\";
                }
                //Создаем директорию в папке BACKUP с названием изменяемого файла
                if (!Directory.Exists(directoryInBackUp))
                {
                    Directory.CreateDirectory(directoryInBackUp);
                }

                string BackupFullPath = $@"{directoryInBackUp}\{backupFileName}";
                //Копируем файл из текущей директории в бэкап
                if (!File.Exists(BackupFullPath))
                    File.Copy(e.FullPath, BackupFullPath);
            }
        }
        #endregion
        //Метод, вызываемый обработчиком переименования файлов.
        //В этом методе проиходит переименование директории этого файла в бэкапе.
        #region RENAME_DIRECTORY
        private static void RenameBackupDirectory(RenamedEventArgs e)
        {
            if (e != null)
            {
                var oldName = e.OldName.Substring(0, e.OldName.LastIndexOf('.'));
                string oldPath = $@"{PathBackup}\{oldName}";    //путь к папке бэка с прошлым названием файла
                //Содержит ли директория файл по старому пути
                if (!Directory.Exists(oldPath))
                {
                    var newName = Path.GetFileNameWithoutExtension(e.Name);
                    string newPath = $@"{PathBackup}\{newName}";

                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);     //создаем директорию с новым именем файла
                    }
                }
                else
                {//
                    string newFullPathDirectory;
                    string oldFullPathDirectory = newFullPathDirectory = PathBackup;
                    string newNameDirectory = Path.GetFileNameWithoutExtension(e.Name);
                    string oldNameDirectory = Path.GetFileNameWithoutExtension(e.OldName);
                    string subDirectory = Path.GetDirectoryName(e.Name);

                    if (subDirectory == "")
                    {
                        newFullPathDirectory += $@"\{newNameDirectory}\";
                        oldFullPathDirectory += $@"\{oldNameDirectory}\";
                    } else {
                        newFullPathDirectory += $@"\{subDirectory}\{newNameDirectory}\";
                        oldFullPathDirectory += $@"\{subDirectory}\{oldNameDirectory}\";
                    }
                    //Переместим директорию по новому пути
                    Directory.Move(oldFullPathDirectory, newFullPathDirectory);
                }
            }
        }
        #endregion
    }
}