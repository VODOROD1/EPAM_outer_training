using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Entities
{
    public class PostComment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserID { get; set; }
        public string Description { get; set; }
        public DateTime DataCreate { get; set; }
        public DateTime DataModified { get; set; }
    }
}
