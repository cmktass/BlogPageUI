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
        Task<GenericResponse<ControllerVM>> UpdateController(ControllerVM controllerVM);
        Task<GenericResponse<ControllerVM>> GetControllerByName(string name);
        Task<GenericResponse<int>> DeleteController(int id);
        Task<GenericResponse<ControllerVM>> GetControllerWithActions(int id);
        Task<GenericResponse<ControllerActionVM>> AddAction(ControllerActionVM controllerAction);
    }
}
