using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.ViewComponents.Dashboard
{
    public class _EmployeeTaskChartDashboardPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _EmployeeTaskChartDashboardPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
