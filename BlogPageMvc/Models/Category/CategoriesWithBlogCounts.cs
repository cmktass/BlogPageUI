using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.Models.Category
{
    public class CategoriesWithBlogCounts
    {
        public string CategoryName { get; set; }
        public int BlogCount { get; set; }
    }
}
