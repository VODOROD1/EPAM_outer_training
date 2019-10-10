using BLOG.BLL.Interfaces;
using BLOG.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.BLL
{
    public class BlogManager : IManager
    {
        private readonly IStorable storage;
        public BlogManager(IStorable storage)
        {
            this.storage = storage;
        }
    }
}
