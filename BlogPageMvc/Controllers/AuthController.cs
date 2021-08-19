using BlogPageMvc.Models.User;
using BlogPageMvc.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.Controllers
{
    [Route("[action]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserSignInVM user)
        {
            if (ModelState.IsValid)
            {
                var response = await _authService.SignIn(user);
                if (response.ErrorMessage != null)
                {
                    ModelState.AddModelError("hatalı", response.ErrorMessage);
                }
                else
                {
                    return RedirectToAction("", "admin");
                }
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterModel userRegister)
        {
            return View();
        }
    }
}
