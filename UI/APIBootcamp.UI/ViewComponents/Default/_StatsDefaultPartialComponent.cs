
using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.ViewComponents.Default
{
    public class _StatsDefaultPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _StatsDefaultPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response1 = await client.GetAsync("https://localhost:7243/api/Statistics/ProductCount");
            var response2 = await client.GetAsync("https://localhost:7243/api/Statistics/ReservationCount");
            var response3 = await client.GetAsync("https://localhost:7243/api/Statistics/TotalGuestCount");
            var response4 = await client.GetAsync("https://localhost:7243/api/Statistics/ChefCount");

            var jsonData1 = await response1.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData1;
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            ViewBag.ReservationCount = jsonData2;
            var jsonData3 = await response3.Content.ReadAsStringAsync();
            ViewBag.TotalGuestCount = jsonData3;
            var jsonData4 = await response4.Content.ReadAsStringAsync();
            ViewBag.ChefCount = jsonData4;

            return View();
        }
    }
}
