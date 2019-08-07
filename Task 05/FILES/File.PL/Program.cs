using System;
using System.Collections.Generic;
using System.Globalization;

namespace _5._1._BACKUP_SYSTEM
{
    class Program
    {
        static void Main()
        {
            LaunchChosenMode();
        }
        //Запускаем выбранный режим работы программы
        #region LAUNCH_CHOSEN_MODE
        static void LaunchChosenMode()
        {
            while (true)
            {
                object mode = ChooseAndCreateMode();
                //Проверим полученный объект
                if (mode is Watcher)
                {
                    Watcher watcher = mode as Watcher;
                    //Запустим мониторинг
                    watcher.FSW.EnableRaisingEvents = true;

                    Console.WriteLine("Нажмите клавишу Q для останова мониторинга изменений");

                    while (true)
                    {
                        char stopWatcher = Console.ReadKey(true).KeyChar;
                        if (stopWatcher == 'Q' || stopWatcher == 'q')
                        {
                            break;
                        }
                    }
                    //Закрываем мониторинг
                    watcher.FSW.EnableRaisingEvents = false;
                }
                else if (mode is Backup)
                {
                    Backup back = mode as Backup;
                    back.DateAndTime = InputDateTime();    //передадим дату и время, введенные пользователем
                    back.RollBack();
                    Console.WriteLine($"Осуществлен откат данных в соответствии с датой  {back.DateAndTime.ToString("dd.MM.yyyy HH.mm")}!");
                }
                else
                    break;
            }
        }
        #endregion
        //Выбираем режим работы программы
        #region CHOOSE_AND_CREATE_MODE
        static object ChooseAndCreateMode()
        {
            Console.WriteLine("Выберите режим работы программы:");
            Console.WriteLine("\t\t1) - Мониторинг");
            Console.WriteLine("\t\t2) - Откат изменений");
            Console.WriteLine("\t\t3) - Выход");

            while (true)
            {
                char key = Console.ReadKey(true).KeyChar;

                switch (key)
                {
                    case '1':
                        return new Watcher();
                    case '2':
                        return new Backup();
                    case '3':
                        return new object();
                }
            }
        }
        #endregion
        //Запрашиваем дату и время, которые нужны для отката файлов
        #region INPUT_DATE_TIME
        static DateTime InputDateTime()
        {
            Console.WriteLine("Введите дату и время, на которые должен быть осуществлён откат:");

            while (true)
            {
                Console.Write("Введите дату и время в соответствии с шаблоном" +
                    " день.мес.год ч:мин: ");
                string input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "dd.MM.yyyy HH:mm", null, DateTimeStyles.None, out DateTime date))
                    return date;
                else
                    Console.WriteLine("Введите существующие дату и время бэкапа!");
            }
        }
        #endregion
    }
}