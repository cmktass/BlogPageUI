using BlogPageMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.Controllers
{
    public class HomeController : Controller
    {
      

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Resume()
        {
            return View();
        }

         public IActionResult Contact()
        {
            return View();
        }

    }
}
