using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Http.Headers;
using System.Text;

namespace APIBootcamp.UI.Controllers
{
    public class AIController : Controller
    {
        public IActionResult CreateRecipeWithOpenAI()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipeWithOpenAI(string prompt)
        {
            var prePrompt = "Create a recipe for a dish that includes the following ingredients: ";
            var client = new HttpClient();
            var chatRequest = new ChatRequestModel
            {
                Model = "gpt-4o-mini",
                Messages = new List<Message>
        {
            new Message
            {
                Role = "user",
                Content = prePrompt + prompt
            }
        }
            };


            var json = System.Text.Json.JsonSerializer.Serialize(chatRequest);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://chatgpt-42.p.rapidapi.com/chat"),
                Headers =
                {
                    { "x-rapidapi-key", "" },
                    { "x-rapidapi-host", "chatgpt-42.p.rapidapi.com" },
                },
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                var result = System.Text.Json.JsonSerializer.Deserialize<ChatResponseModel>(responseBody);

                if (result != null && result.Choices != null && result.Choices.Any())
                {
                    ViewBag.Recipe = result.Choices[0].Message.Content;
                }
                else
                {
                    ViewBag.ErrorMessage = "Recipe generation failed. Please try again.";
                }
            }

            return View();
        }

        public class Message
        {
            public string Role { get; set; }
            public string Content { get; set; }
        }

        public class ChatRequestModel
        {
            public List<Message> Messages { get; set; }
            public string Model { get; set; }
        }

        public class ChatChoice
        {
            public int Index { get; set; }
            public string Finish_Reason { get; set; }
            public Message Message { get; set; }
        }

        public class ChatResponseModel
        {
            public string Id { get; set; }
            public string Object { get; set; }
            public long Created { get; set; }
            public string Model { get; set; }
            public List<ChatChoice> Choices { get; set; }
        }
    }
}
