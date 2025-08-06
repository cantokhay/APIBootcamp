using APIBootcamp.UI.DTOs.NotificationDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIBootcamp.UI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> NotificationList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7243/api/Notifications");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNotificationDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDTO createNotificationDTO)
        {
            createNotificationDTO.NotificationIsRead = false;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createNotificationDTO);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7243/api/Notifications", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("NotificationList");
            }
            return View(createNotificationDTO);
        }

        public async Task<IActionResult> DeleteNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7243/api/Notifications?id={id}");
            return RedirectToAction("NotificationList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7243/api/Notifications/GetNotificationById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateNotificationDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationDTO updateNotificationDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateNotificationDTO);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7243/api/Notifications", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("NotificationList");
            }
            return View(updateNotificationDTO);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeNotificationIsReadStatusFromFalseToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7243/api/Notifications/GetNotificationById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateNotificationDTO>(jsonData);
                var content = new StringContent(JsonConvert.SerializeObject(value), System.Text.Encoding.UTF8, "application/json");
                var result = await client.PutAsync("https://localhost:7243/api/Notifications/ChangeNotificationIsReadStatusFromFalseToTrue", content);
                return RedirectToAction("NotificationList");
            }
            return RedirectToAction("NotificationList");
        }

        [HttpGet]
        public async Task<IActionResult> ChangeNotificationIsReadStatusFromTrueToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7243/api/Notifications/GetNotificationById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateNotificationDTO>(jsonData);
                var content = new StringContent(JsonConvert.SerializeObject(value), System.Text.Encoding.UTF8, "application/json");
                var result = await client.PutAsync("https://localhost:7243/api/Notifications/ChangeNotificationIsReadStatusFromTrueToFalse", content);
                return RedirectToAction("NotificationList");
            }
            return RedirectToAction("NotificationList");
        }
    }
}
