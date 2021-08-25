using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.Models.Role
{
    public class RoleVM
    {
        public int Id { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
