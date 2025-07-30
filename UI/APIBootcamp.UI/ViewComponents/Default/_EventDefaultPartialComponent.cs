using APIBootcamp.UI.DTOs.EventDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIBootcamp.UI.ViewComponents.Default
{
    public class _EventDefaultPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _EventDefaultPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient("Default");
            var response = await client.GetAsync("https://localhost:7243/api/YummyEvents/");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEventDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
