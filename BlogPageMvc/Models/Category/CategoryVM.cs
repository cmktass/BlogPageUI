using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.Models.Category
{
    public class CategoryVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bu alan boş geçilemez.")]
        public string CategoryName { get; set; }
    }
}
