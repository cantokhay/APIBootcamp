using APIBootcamp.UI.DTOs.ImageDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIBootcamp.UI.ViewComponents.Default
{
    public class _ImagesDefaultPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _ImagesDefaultPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient("Default");
            var response = await client.GetAsync("https://localhost:7243/api/Images/");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultImageDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
