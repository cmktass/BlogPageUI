using BlogPageMvc.Models;
using BlogPageMvc.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageMvc.Service.Interface
{
    public interface ICategoryService
    {
        Task<List<CategoriesWithBlogCounts>> GetCategories();
        Task<GenericResponse<CategoryVM>> AddCategory(CategoryVM categoryVM);
        Task<GenericResponse<CategoryVM>> GetCategoryByName(string name);
        Task<GenericResponse<CategoryVM>> UpdateCategory(CategoryVM categoryVM);
        Task<GenericResponse<int>> DeleteCategory(int id);
    }
}
