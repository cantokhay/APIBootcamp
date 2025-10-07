using APIBootcamp.UI.DTOs.ReservationDTOs;
using APIBootcamp.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIBootcamp.UI.ViewComponents.Dashboard
{
    public class _LineChartDashboardPartialComponent : ViewComponent
    {
private readonly IHttpClientFactory _httpClientFactory;

        public _LineChartDashboardPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7243/api/Reservations/GetReservationStats");
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<ChartReservationDTO>>(json);
            return View(data);

            //RevenueChartViewModel model = new RevenueChartViewModel();
            //if (response.IsSuccessStatusCode)
            //{
            //    var data = await response.Content.ReadFromJsonAsync<List<ChartReservationDTO>>();

            //    if (data != null)
            //    {
            //        model.Labels = data.Select(x => x.Month).ToList();
            //        model.Income = data.Select(x => x.Approved).ToList();
            //        model.Expense = data.Select(x => x.Cancelled).ToList();

            //        model.ApprovedResevation = data.Sum(x => x.Approved);
            //        model.CancelledReservation = data.Sum(x => x.Cancelled);
            //        model.PendingReservation = data.Sum(x => x.Pending);
            //    }
            //}
            //var client = _httpClientFactory.CreateClient();
            //client.BaseAddress = new Uri("https://localhost:7020/");
            //var response = await client.GetAsync("api/Reservations/GetReservationStats");
            //return View(data);
        }
    }
}
