using BlogPageMvc.Models;
using BlogPageMvc.Models.User;
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
    public class AuthService:IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
            string baseAddress = StringInfo.UrlInfo.BaseUrl + "/api/auth/";
            _httpClient.BaseAddress = new Uri(baseAddress);
        }
        public async Task<GenericResponse<string>> SignIn(UserSignInVM user)
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("login", data);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<GenericResponse<string>>(await response.Content.ReadAsStringAsync());
                if (string.IsNullOrEmpty(result.ErrorMessage))
                {
                    _httpContextAccessor.HttpContext.Session.SetString("token"
                   , result.Data);
                }
                return result;
            }
            return null;
        }
    }
}
