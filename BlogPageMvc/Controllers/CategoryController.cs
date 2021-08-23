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
            if (ModelState.IsValid)
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
            }
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> Update(string category)
        {
            var response = await _categoryService.GetCategoryByName(category);
            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                var response = await _categoryService.UpdateCategory(categoryVM);
                if (string.IsNullOrEmpty(response.ErrorMessage))
                {
                    return RedirectToAction("Categories");
                }
                else
                {
                    ModelState.AddModelError("", response.ErrorMessage);
                    return View(categoryVM);
                }
            }
            return View(categoryVM);
            
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string category)
        {
            var response = await _categoryService.GetCategoryByName(category);
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categoryService.DeleteCategory(id);
            if (string.IsNullOrEmpty(response.ErrorMessage))
            {
                return RedirectToAction("Categories");
            }
            else
            {
                ModelState.AddModelError("", response.ErrorMessage);
                return View();
            }
            
        }
    }
}
