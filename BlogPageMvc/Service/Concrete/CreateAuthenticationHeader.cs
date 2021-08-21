using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlogPageMvc.Service.Concrete
{
    public static class CreateAuthenticationHeader
    {
        public static HttpClient CreateHttpClientHeader(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            string a = httpContextAccessor.HttpContext.Session.GetString("token");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + a);
            return httpClient;
        }
    }
}
