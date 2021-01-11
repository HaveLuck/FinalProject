using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBigBlog.Models
{
    public class TopicModel
    {
        public int ID { get; set; }
        [Required]
        public string Name_Topic { get; set; }
        public string Description_Topic { get; set; }
        public int Status { get; set; }
    }
}
