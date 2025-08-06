using APIBootcamp.UI.DTOs.ReservationDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIBootcamp.UI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ReservationList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7243/api/Reservations");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReservationDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateReservation()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDTO createReservationDTO)
        {
            createReservationDTO.ReservationStatus = ReservationStatus.Pending;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDTO);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7243/api/Reservations", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ReservationList");
            }
            return View(createReservationDTO);
        }

        public async Task<IActionResult> DeleteReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7243/api/Reservations?id={id}");
            return RedirectToAction("ReservationList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7243/api/Reservations/GetReservationById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateReservationDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReservation(UpdateReservationDTO updateReservationDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateReservationDTO);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7243/api/Reservations", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ReservationList");
            }
            return View(updateReservationDTO);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeReservationStatusToPending(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7243/api/Reservations/GetReservationById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateReservationDTO>(jsonData);
                var content = new StringContent(JsonConvert.SerializeObject(value), System.Text.Encoding.UTF8, "application/json");
                var result = await client.PutAsync("https://localhost:7243/api/Reservations/ChangeReservationStatusToPending", content);
                return RedirectToAction("ReservationList");
            }
            return RedirectToAction("ReservationList");
        }

        [HttpGet]
        public async Task<IActionResult> ChangeReservationStatusToApproved(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7243/api/Reservations/GetReservationById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateReservationDTO>(jsonData);
                var content = new StringContent(JsonConvert.SerializeObject(value), System.Text.Encoding.UTF8, "application/json");
                var result = await client.PutAsync("https://localhost:7243/api/Reservations/ChangeReservationStatusToApproved", content);
                return RedirectToAction("ReservationList");
            }
            return RedirectToAction("ReservationList");
        }

        [HttpGet]
        public async Task<IActionResult> ChangeReservationStatusToCompleted(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7243/api/Reservations/GetReservationById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateReservationDTO>(jsonData);
                var content = new StringContent(JsonConvert.SerializeObject(value), System.Text.Encoding.UTF8, "application/json");
                var result = await client.PutAsync("https://localhost:7243/api/Reservations/ChangeReservationStatusToCompleted", content);
                return RedirectToAction("ReservationList");
            }
            return RedirectToAction("ReservationList");
        }

        [HttpGet]
        public async Task<IActionResult> ChangeReservationStatusToRejected(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7243/api/Reservations/GetReservationById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateReservationDTO>(jsonData);
                var content = new StringContent(JsonConvert.SerializeObject(value), System.Text.Encoding.UTF8, "application/json");
                var result = await client.PutAsync("https://localhost:7243/api/Reservations/ChangeReservationStatusToRejected", content);
                return RedirectToAction("ReservationList");
            }
            return RedirectToAction("ReservationList");
        }
    }
}