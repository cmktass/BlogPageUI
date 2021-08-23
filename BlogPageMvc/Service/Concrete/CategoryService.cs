using BlogPageMvc.Models;
using BlogPageMvc.Models.Category;
using BlogPageMvc.Models.Tag;
using BlogPageMvc.Service.Interface;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlogPageMvc.Service.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient  _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CategoryService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri(StringInfo.UrlInfo.BaseUrl + "/api/Category/");
        }
      
        public async Task<List<CategoriesWithBlogCounts>> GetCategories()
        {
            var responseMessage = await _httpClient.GetAsync("GetAllCategory");
            return JsonConvert.DeserializeObject<List<CategoriesWithBlogCounts>>(await responseMessage.Content.ReadAsStringAsync());
        }
        public async Task<List<CategoriesWithBlogCounts>> GetCategoryById(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"GetCategoryById/{id}");
            return JsonConvert.DeserializeObject<List<CategoriesWithBlogCounts>>(await responseMessage.Content.ReadAsStringAsync());
        }
        public async Task<GenericResponse<CategoryVM>> GetCategoryByName(string name)
        {
            var responseMessage = await _httpClient.GetAsync($"GetCategoryByName/name?name={name}");
            return JsonConvert.DeserializeObject<GenericResponse<CategoryVM>>(await responseMessage.Content.ReadAsStringAsync());
        }
        public async Task<GenericResponse<CategoryVM>> AddCategory(CategoryVM categoryVM)
        {
            var json = JsonConvert.SerializeObject(categoryVM);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            CreateAuthenticationHeader.CreateHttpClientHeader(_httpClient, _httpContextAccessor);
            var responseMessage = await _httpClient.PostAsync("AddCategory", data);
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GenericResponse<CategoryVM>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<GenericResponse<CategoryVM>> UpdateCategory(CategoryVM categoryVM)
        {
            var json = JsonConvert.SerializeObject(categoryVM);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            CreateAuthenticationHeader.CreateHttpClientHeader(_httpClient, _httpContextAccessor);
            var responseMessage = await _httpClient.PutAsync("UpdateCategory", data);
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GenericResponse<CategoryVM>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<GenericResponse<int>> DeleteCategory(int id)
        { 
            CreateAuthenticationHeader.CreateHttpClientHeader(_httpClient, _httpContextAccessor);
            var responseMessage = await _httpClient.DeleteAsync($"DeleteCategory/id?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GenericResponse<int>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
    }
}
