using BlogPageMvc.Models;
using BlogPageMvc.Models.Controller;
using BlogPageMvc.Models.Role;
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
        Task<GenericResponse<ControllerActionVM>> GetActionById(int id);
        Task<GenericResponse<int>> DeleteAction(int id);
        Task<List<RoleVM>> GetRoles();
        Task<GenericResponse<RoleVM>> GetRoleById(int id);
        Task<GenericResponse<RoleVM>> AddRole(RoleVM roleVM);
        Task<GenericResponse<RoleVM>> UpdateRole(RoleVM roleVM);
        Task<GenericResponse<int>> DeleteRoleId(int id);

    }
}
