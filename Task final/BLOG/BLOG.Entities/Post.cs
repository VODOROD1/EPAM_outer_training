using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime DataCreate { get; set; }
        public DateTime DataModified { get; set; }
        public int CategoryId { get; set; }

        //public Image Image { get; set; }
    }
}
