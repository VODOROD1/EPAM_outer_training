using _3_Layer_Arch.BLL;
using _3_Layer_Arch.BLL.Interfaces;
using _3_Layer_Arch.DAL.Interfaces;
using _3_Layer_Arch.DBDAL;
using _3_Layer_Arch.FileDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Layer_Arch.Common
{
    public class DependencyResolver
    {   //когда используем файл
        //private static readonly IStorable _textFiles;
        //public static readonly IManager _usersAwardsManager;
        //public static IStorable TextFiles => _textFiles;
        //public static IManager UsersAwardsManager => _usersAwardsManager;
        //static DependencyResolver()
        //{
        //    _textFiles = new TextFiles();
        //    _usersAwardsManager = new UsersAwardsManager(_textFiles);
        //}


        //когда используем базу данных
        private static readonly IStorable _db;
        public static readonly IManager _usersAwardsManager;
        public static IStorable DB => _db;
        public static IManager UsersAwardsManager => _usersAwardsManager;
        static DependencyResolver()
        {
            _db = new DataBase();
            _usersAwardsManager = new UsersAwardsManager(_db);
        }
    }
}
