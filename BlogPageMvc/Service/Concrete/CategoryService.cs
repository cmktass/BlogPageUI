using BlogPageMvc.Models.Category;
using BlogPageMvc.Models.Tag;
using BlogPageMvc.Service.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlogPageMvc.Service.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient  _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(StringInfo.UrlInfo.BaseUrl + "/api/Category/GetAllCategory");
        }
      
        public async Task<List<CategoriesWithBlogCounts>> GetCategories()
        {
            var responseMessage = await _httpClient.GetAsync("");
            return JsonConvert.DeserializeObject<List<CategoriesWithBlogCounts>>(await responseMessage.Content.ReadAsStringAsync());
        }
    }
}
