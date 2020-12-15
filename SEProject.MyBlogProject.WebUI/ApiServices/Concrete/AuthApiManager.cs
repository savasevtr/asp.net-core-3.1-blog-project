using Newtonsoft.Json;
using SEProject.MyBlogProject.WebUI.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SEProject.MyBlogProject.WebApi.Models;
using SEProject.MyBlogProject.WebUI.ApiServices.Interfaces;

namespace SEProject.MyBlogProject.WebUI.ApiServices.Concrete
{
    public class AuthApiManager : IAuthApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthApiManager(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:56977/api/Auth/");
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> SignIn(AppUserLoginModel appUserLoginModel)
        {
            var jsonData = JsonConvert.SerializeObject(appUserLoginModel);

            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await _httpClient.PostAsync("SingIn", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                var accesToken = JsonConvert.DeserializeObject<AccesToken>(await responseMessage.Content.ReadAsStringAsync());

                _httpContextAccessor.HttpContext.Session.SetString("token", accesToken.Token);

                return true;
            }

            return false;
        }
    }
}