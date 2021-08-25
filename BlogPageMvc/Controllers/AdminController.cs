using BlogPageMvc.Models;
using BlogPageMvc.Models.Controller;
using BlogPageMvc.Models.Role;
using BlogPageMvc.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.Controllers
{
    public class AdminController : Controller
    {
        private IBlogService _blogService;
        private IAdminService _adminService;
        public AdminController(IBlogService blogService, IAdminService adminService)
        {
            _blogService = blogService;
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllController()
        {
            return View(await _adminService.GetControllers());
        }

        public IActionResult AddController()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddController(ControllerVM controllerVM)
        {
            if (ModelState.IsValid)
            {
                var response = await _adminService.AddController(controllerVM);
                if (!string.IsNullOrEmpty(response.ErrorMessage))
                {
                    ModelState.AddModelError("hata", response.ErrorMessage);
                    return View(controllerVM);
                }
                else
                {
                    return RedirectToAction("GetAllController");
                }
            }
            return View(controllerVM);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateController(string controllername)
        {
            var a = await _adminService.GetControllerByName(controllername);
            return View(a.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateController(ControllerVM controllerVM)
        {
            if (ModelState.IsValid)
            {
                var response = await _adminService.UpdateController(controllerVM);
                if (!string.IsNullOrEmpty(response.ErrorMessage))
                {
                    ModelState.AddModelError("hata", response.ErrorMessage);
                    return View(controllerVM);
                }
                else
                {
                    return RedirectToAction("getallcontroller","admin");
                }
            }
            return View(controllerVM);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteController(string controllername)
        {
            var data = await _adminService.GetControllerByName(controllername);
            return View(data.Data);
        }

        public async Task<IActionResult> DeleteController(int id)
        {
            var data = await _adminService.DeleteController(id);
            if (data.ErrorMessage == null)
            {
                return RedirectToAction("getallcontroller", "admin");
            }
            return View();
        }

        public async Task<IActionResult> ControllerDetail(int id)
        {
            var data = await _adminService.GetControllerWithActions(id);
            return View(data.Data);
        }

        [HttpGet]
        public async Task<IActionResult> AddAction(int ControllerId)
        {
            ViewBag.ControllerId = ControllerId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAction(ControllerActionVM actionVM)
        {
            if (ModelState.IsValid)
            {
                var response = await _adminService.AddAction(actionVM);
                if (response.ErrorMessage != null)
                {
                    ModelState.AddModelError("hata", response.ErrorMessage);
                    return View(actionVM);
                }
                else
                {
                    return RedirectToAction("ControllerDetail", new { id = actionVM.ControllerId });
                }
            }
            return View(actionVM);
           
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAction(int id)
        {
            var response = await _adminService.GetActionById(id);
            return View(response.Data);
        }
        
        public async Task<IActionResult> DeleteActionId(int id)
        {
            var response = await _adminService.DeleteAction(id);
            if (response.ErrorMessage == null)
            {
                return RedirectToAction("GetAllController");
            }
            return View(response.Data);
        }


        [HttpGet]
        public async Task<IActionResult> AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleVM roleVM)
        {
            
            if (ModelState.IsValid)
            {
                var response = await _adminService.AddRole(roleVM);
                if (response.ErrorMessage != null)
                {
                    ModelState.AddModelError("hata", response.ErrorMessage);
                }
                else
                {
                    return RedirectToAction("GetAllRoles");
                }
            }
            return View(roleVM);
        }



        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            return View(await _adminService.GetRoles());
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var response = await _adminService.GetRoleById(id);
            return View(response.Data);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteRoleId(int id)
        {
            var response = await _adminService.DeleteRoleId(id);
            if (response?.ErrorMessage == null)
            {
                return RedirectToAction("GetAllRoles");
            }
            return View(response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var response = await _adminService.GetRoleById(id);
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleVM roleVM)
        {
            var response = await _adminService.UpdateRole(roleVM);
            if (ModelState.IsValid)
            {
                if (response.ErrorMessage == null)
                {
                    return RedirectToAction("GetAllRoles");
                }
                else
                {
                    ModelState.AddModelError("hata", response.ErrorMessage);
                    return View(roleVM);
                }


            }
            return View(roleVM);
        }



    }
}
