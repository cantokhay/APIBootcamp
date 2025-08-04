using APIBootcamp.UI.DTOs.EventDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIBootcamp.UI.Controllers
{
    public class YummyEventController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public YummyEventController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> YummyEventList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7243/api/YummyEvents");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultYummyEventDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateYummyEvent()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateYummyEvent(CreateYummyEventDTO createYummyEventDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createYummyEventDTO);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7243/api/YummyEvents", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("YummyEventList");
            }
            return View(createYummyEventDTO);
        }

        public async Task<IActionResult> DeleteYummyEvent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7243/api/YummyEvents?id={id}");
            return RedirectToAction("YummyEventList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateYummyEvent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7243/api/YummyEvents/GetYummyEventById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateYummyEventDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateYummyEvent(UpdateYummyEventDTO updateYummyEventDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateYummyEventDTO);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7243/api/YummyEvents", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("YummyEventList");
            }
            return View(updateYummyEventDTO);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeEventStatusFromFalseToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7243/api/YummyEvents/GetYummyEventById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateYummyEventDTO>(jsonData);
                var content = new StringContent(JsonConvert.SerializeObject(value), System.Text.Encoding.UTF8, "application/json");
                var result = await client.PutAsync("https://localhost:7243/api/YummyEvents/ChangeEventStatusFromFalseToTrue", content);
                return RedirectToAction("YummyEventList");
            }
            return RedirectToAction("YummyEventList");
        }

        [HttpGet]
        public async Task<IActionResult> ChangeEventStatusFromTrueToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7243/api/YummyEvents/GetYummyEventById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateYummyEventDTO>(jsonData);
                var content = new StringContent(JsonConvert.SerializeObject(value), System.Text.Encoding.UTF8, "application/json");
                var result = await client.PutAsync("https://localhost:7243/api/YummyEvents/ChangeEventStatusFromTrueToFalse", content);
                return RedirectToAction("YummyEventList");
            }
            return RedirectToAction("YummyEventList");
        }
    }
}
