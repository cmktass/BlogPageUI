using BlogPageMvc.Models.Tag;
using BlogPageMvc.Service.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlogPageMvc.Service.Concrete
{
    public class TagService:ITagService
    {
        private readonly HttpClient _httpClient;
        public TagService(HttpClient httpClient)
        {
            _httpClient = httpClient;
           _httpClient.BaseAddress = new Uri(StringInfo.UrlInfo.BaseUrl + "/api/Tag/GetAllTag");
        }
        public async Task<List<TagVM>> GetAllTags()
        {
            var responseMessage = await _httpClient.GetAsync("");
            return JsonConvert.DeserializeObject<List<TagVM>>(await responseMessage.Content.ReadAsStringAsync());
        }
    }
}
