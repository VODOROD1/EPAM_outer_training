using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Entities
{
    public class PrimaryAnswerComment
    {
        public int Id { get; set; }
        public int PrimaryCommentId { get; set; }
        public int AnswerCommentId { get; set; }
    }
}
