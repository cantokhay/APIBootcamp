using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace APIBootcamp.UI.ViewComponents.Dashboard
{
    public class _WidgetsDashboardPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _WidgetsDashboardPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response1 = await client.GetAsync("https://localhost:7243/api/Reservations/GetTotalReservationCount");
            var response2 = await client.GetAsync("https://localhost:7243/api/Reservations/GetTotalReservationCustomerCount");
            var response3 = await client.GetAsync("https://localhost:7243/api/Reservations/GetCountByReservationStatusPending");
            var response4 = await client.GetAsync("https://localhost:7243/api/Reservations/GetCountByReservationStatusApproved");

            var jsonData1 = await response1.Content.ReadAsStringAsync();
            ViewBag.TotalReservations = jsonData1;
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            ViewBag.TotalReservationCustomers = jsonData2;
            var jsonData3 = await response3.Content.ReadAsStringAsync();
            ViewBag.PendingReservations = jsonData3;
            var jsonData4 = await response4.Content.ReadAsStringAsync();
            ViewBag.ApprovedReservations = jsonData4;

            return View();
        }
    }
}
