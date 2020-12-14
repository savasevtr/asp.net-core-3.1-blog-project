using SEProject.MyBlogProject.WebUI.ApiServices.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.WebUI.ApiServices.Concrete
{
    public class ImageApiManager : IImageApiService
    {
        private readonly HttpClient _httpClient;

        public ImageApiManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:56977/api/images/");
        }

        public async Task<string> GetBlogImageByIdAync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"GetBlogImageById/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var bytes = await responseMessage.Content.ReadAsByteArrayAsync();

                return $"data:image/jpeg;base64,{Convert.ToBase64String(bytes)}";
            }

            return null;
        }
    }
}