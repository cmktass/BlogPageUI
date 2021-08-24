using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.Models.Controller
{
    public class ControllerActionVM
    {
        public int Id { get; set; }
        [Required]
        public string ActionName { get; set; }
        public int ControllerId { get; set; }
        public ControllerVM Controller { get; set; }
    }
}
