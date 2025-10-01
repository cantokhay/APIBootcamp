using APIBootcamp.UI.Models;
using Microsoft.AspNetCore.Mvc;

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

            var vm = new RevenueChartViewModel
            {
                Labels = new List<string> { "Jan", "Feb", "Mar", "Apr", "May", "Jun" },
                Income = new List<int> { 5, 15, 14, 36, 32, 32 },
                Expense = new List<int> { 7, 11, 30, 18, 25, 13 },
                WeeklyEarnings = 675,
                MonthlyEarnings = 1587,
                YearlyEarnings = 45965,
                TotalCustomers = 8257,
                TotalIncome = 9857,
                ProjectCompleted = 28,
                TotalExpense = 6287,
                NewCustomers = 684
            };

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7243/api/Reservations/GetTotalReservationCount");

            var jsonData = await response.Content.ReadAsStringAsync();
            ViewBag.TotalReservations = jsonData;

            return View(vm);
        }
    }
}
