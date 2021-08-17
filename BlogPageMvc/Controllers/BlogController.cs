using BlogPageMvc.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.Controllers
{
    public class BlogController : Controller
    {

        private IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IActionResult> IndexAsync(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return View(await _blogService.GetAllPost());
            }
            else
            {
                return View(await _blogService.GetBlogsByCategoryName(category));
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string title)
        {
            return View(await _blogService.GetPostByName(title));
        }


    }
}
