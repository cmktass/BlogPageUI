using BlogPageMvc.Models.Category;
using BlogPageMvc.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.Controllers
{
       [Route("Admin/[Controller]/[action]")]
       public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Categories()
        {
            return View(await _categoryService.GetCategories());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryVM category)
        {
            var response = await _categoryService.AddCategory(category);
            if (response != null)
            {
                if (string.IsNullOrEmpty(response.ErrorMessage))
                {
                    return RedirectToAction("Categories");
                }
                else
                {
                    ModelState.AddModelError("hatalı", response.ErrorMessage);
                    return View(category);
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(string category)
        {
            var a = await _categoryService.GetCategoryByName(category);
            return View(a.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryVM categoryVM)
        {
            return View();
        }
    }
}
