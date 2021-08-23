using BlogPageMvc.Models.Controller;
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
        public async Task<IActionResult> PostsAsync()
        {
            return View(await _blogService.GetAllPost());
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
                    return View();
                }
            }
            return View(controllerVM);
        }


    }
}
