using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.Models
{
    public class GenericResponse<T>
    {
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
