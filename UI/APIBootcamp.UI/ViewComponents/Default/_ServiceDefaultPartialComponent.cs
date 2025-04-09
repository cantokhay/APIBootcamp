using APIBootcamp.UI.DTOs.ServiceDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIBootcamp.UI.ViewComponents.Default
{
    public class _ServiceDefaultPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ServiceDefaultPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7243/api/Services/");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
