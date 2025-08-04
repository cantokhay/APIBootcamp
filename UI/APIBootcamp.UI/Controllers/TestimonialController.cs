﻿using APIBootcamp.UI.DTOs.TestimonialDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIBootcamp.UI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> TestimonialList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7243/api/Testimonials");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDTO createTestimonialDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTestimonialDTO);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7243/api/Testimonials", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("TestimonialList");
            }
            return View(createTestimonialDTO);
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7243/api/Testimonials?id={id}");
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7243/api/Testimonials/GetTestimonialById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateTestimonialDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDTO updateTestimonialDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTestimonialDTO);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7243/api/Testimonials", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("TestimonialList");
            }
            return View(updateTestimonialDTO);
        }
    }
}
