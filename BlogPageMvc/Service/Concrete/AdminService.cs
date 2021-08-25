using BlogPageMvc.Models;
using BlogPageMvc.Models.Category;
using BlogPageMvc.Models.Controller;
using BlogPageMvc.Models.Role;
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
        public async Task<GenericResponse<ControllerVM>> GetControllerByName(string name)
        {
            var responseMessage = await _httpClient.GetAsync($"GetControllerByName/name?name={name}");
            return JsonConvert.DeserializeObject<GenericResponse<ControllerVM>>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<GenericResponse<ControllerVM>> UpdateController(ControllerVM controllerVM)
        {
            var json = JsonConvert.SerializeObject(controllerVM);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            //CreateAuthenticationHeader.CreateHttpClientHeader(_httpClient, _httpContextAccessor);
            var responseMessage = await _httpClient.PutAsync("UpdateController", data);
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GenericResponse<ControllerVM>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<GenericResponse<int>> DeleteController(int id)
        {
            //CreateAuthenticationHeader.CreateHttpClientHeader(_httpClient, _httpContextAccessor);
            var responseMessage = await _httpClient.DeleteAsync($"DeleteController/id?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GenericResponse<int>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<GenericResponse<ControllerVM>> GetControllerWithActions(int id)
        {
            //CreateAuthenticationHeader.CreateHttpClientHeader(_httpClient, _httpContextAccessor);
            var responseMessage = await _httpClient.GetAsync($"GetControllerWithActions/id?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GenericResponse<ControllerVM>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<GenericResponse<ControllerActionVM>> AddAction(ControllerActionVM controllerAction)
        {
            var json = JsonConvert.SerializeObject(controllerAction);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("AddAction", data);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<GenericResponse<ControllerActionVM>>(await response.Content.ReadAsStringAsync());
                return result;
            }
            return null;
        }
        public async Task<GenericResponse<ControllerActionVM>> GetActionById(int id)
        {
            //CreateAuthenticationHeader.CreateHttpClientHeader(_httpClient, _httpContextAccessor);
            var responseMessage = await _httpClient.GetAsync($"GetAction/id?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GenericResponse<ControllerActionVM>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
        public async Task<GenericResponse<int>> DeleteAction(int id)
        {
            //CreateAuthenticationHeader.CreateHttpClientHeader(_httpClient, _httpContextAccessor);
            var responseMessage = await _httpClient.DeleteAsync($"DeleteAction/id?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GenericResponse<int>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<GenericResponse<RoleVM>> AddRole(RoleVM roleVM)
        {
            var json = JsonConvert.SerializeObject(roleVM);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("AddRole", data);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<GenericResponse<RoleVM>>(await response.Content.ReadAsStringAsync());
                return result;
            }
            return null;
        }

        public async Task<List<RoleVM>> GetRoles()
        {
            var responseMessage = await _httpClient.GetAsync("GetAllRoles");
            return JsonConvert.DeserializeObject<List<RoleVM>>(await responseMessage.Content.ReadAsStringAsync());
        }
        public async Task<GenericResponse<RoleVM>> GetRoleById(int id)
        {
            //CreateAuthenticationHeader.CreateHttpClientHeader(_httpClient, _httpContextAccessor);
            var responseMessage = await _httpClient.GetAsync($"GetRole/id?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GenericResponse<RoleVM>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<GenericResponse<RoleVM>> UpdateRole(RoleVM roleVM)
        {
            var json = JsonConvert.SerializeObject(roleVM);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            //CreateAuthenticationHeader.CreateHttpClientHeader(_httpClient, _httpContextAccessor);
            var responseMessage = await _httpClient.PutAsync("UpdateRole", data);
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GenericResponse<RoleVM>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<GenericResponse<int>> DeleteRoleId(int id)
        {
            //CreateAuthenticationHeader.CreateHttpClientHeader(_httpClient, _httpContextAccessor);
            var responseMessage = await _httpClient.DeleteAsync($"DeleteRole/id?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<GenericResponse<int>>(await responseMessage.Content.ReadAsStringAsync());
            }
            return null;
        }
    }
}
