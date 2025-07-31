using APIBootcamp.UI.DTOs.MessageDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIBootcamp.UI.ViewComponents.AdminLayout.NavbarAdminViewComponents
{
    public class _NavbarMessageListAdminPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _NavbarMessageListAdminPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7243/api/Messages/GetMessageByMessageStatusUnRead");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultUnReadMessageDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
