using BlogPageMvc.Models;
using BlogPageMvc.Models.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.Service.Interface
{
    public interface IAdminService
    {
        Task<List<ControllerVM>> GetControllers();
        Task<GenericResponse<ControllerVM>> AddController(ControllerVM categoryVM);
    }
}
