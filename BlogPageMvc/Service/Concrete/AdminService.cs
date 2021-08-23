﻿using BlogPageMvc.Models;
using BlogPageMvc.Models.Category;
using BlogPageMvc.Models.Controller;
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
    public class AdminService:IAdminService
    {

        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
            string baseAddress = StringInfo.UrlInfo.BaseUrl + "/api/admin/";
            _httpClient.BaseAddress = new Uri(baseAddress);
        }
        public async Task<List<ControllerVM>> GetControllers()
        {
            var responseMessage = await _httpClient.GetAsync("GetAllController");
            return JsonConvert.DeserializeObject<List<ControllerVM>>(await responseMessage.Content.ReadAsStringAsync());
        }
        public async Task<GenericResponse<ControllerVM>> AddController(ControllerVM categoryVM)
        {
            var json = JsonConvert.SerializeObject(categoryVM);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("AddController", data);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<GenericResponse<ControllerVM>>(await response.Content.ReadAsStringAsync());
                return result;
            }
            return null;
        }
    }
}
