using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.Models.Post
{
    public class PostVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PostImage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
