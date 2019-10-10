using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Entities
{
    public class MetaAboutUser
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public DateTime DateBirth { get; set; }
        public int Age { get; set; }
    }
}
