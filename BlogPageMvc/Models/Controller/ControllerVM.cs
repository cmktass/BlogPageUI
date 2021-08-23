using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.Models.Controller
{
    public class ControllerVM
    {
        public int Id { get; set; }
        [Required]
        public string ControllerName { get; set; }
    }
}
