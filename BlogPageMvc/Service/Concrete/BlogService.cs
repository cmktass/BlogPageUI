using BlogPageMvc.Models.Post;
using BlogPageMvc.Service.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlogPageMvc.Service.Concrete
{
    public class BlogService:IBlogService
    {
        private readonly HttpClient _httpClient;
        public BlogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            string baseAddress = StringInfo.UrlInfo.BaseUrl + "/api/Blog/";
            _httpClient.BaseAddress = new Uri(baseAddress);
        }

        public async Task<List<PostVM>> GetAllPost()
        {
            var responseMessage = await _httpClient.GetAsync("GetAllBlogs");
            return JsonConvert.DeserializeObject<List<PostVM>>(await responseMessage.Content.ReadAsStringAsync());
        }
        public async Task<List<PostVM>> GetBlogsByCategoryName(string name)
        {
            var responseMessage = await _httpClient.GetAsync($"GetPostsByCategory/category?category={name}");
            return JsonConvert.DeserializeObject<List<PostVM>>(await responseMessage.Content.ReadAsStringAsync());
        }
        public async Task<PostVM> GetPostByName(string title)
        {
            var responseMessage = await _httpClient.GetAsync($"GetBlogByName/name?name={title}"); 
            return JsonConvert.DeserializeObject<PostVM>(await responseMessage.Content.ReadAsStringAsync());
        }
    }
}
