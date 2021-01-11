using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBigBlog.Models
{
    public class ContentModel
    {
        public int ID { get; set; }
        public int Topic_ID { get; set; }
        public string AuthorID { get; set; }
        public string Content { get; set; }
        public string Tittle { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
