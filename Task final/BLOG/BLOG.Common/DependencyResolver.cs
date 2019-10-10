using BLOG.BLL;
using BLOG.BLL.Interfaces;
using BLOG.DAL.Interfaces;
using BLOG.DBDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Common
{
    public class DependencyResolver
    {   
        private static readonly IStorable _db;
        public static readonly IManager _blogManager;
        public static IStorable DB => _db;
        public static IManager BlogManager => _blogManager;
        static DependencyResolver()
        {
            _db = new DataBase();
            _blogManager = new BlogManager(_db);
        }
    }
}
