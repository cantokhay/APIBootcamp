using APIBootcamp.UI.DTOs.NotificationDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIBootcamp.UI.ViewComponents.AdminLayout.NavbarAdminViewComponents
{
    public class _NavbarNotificationListAdminPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _NavbarNotificationListAdminPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7243/api/Notifications/GetNotificationByNotificationStatusUnRead");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultUnReadNotificationDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
