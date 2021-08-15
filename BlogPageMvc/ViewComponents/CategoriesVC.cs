using BlogPageMvc.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.ViewComponents
{
    public class CategoriesVC : ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoriesVC(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _categoryService.GetCategories());
        }
    }
}
