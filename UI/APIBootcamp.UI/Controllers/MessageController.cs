using APIBootcamp.UI.DTOs.MessageDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using static APIBootcamp.UI.Controllers.AIController;

namespace APIBootcamp.UI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MessageList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7243/api/Messages");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDTO createMessageDTO)
        {
            createMessageDTO.MessageStatus = MessageStatus.UnRead;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDTO);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7243/api/Messages", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("MessageList");
            }
            return View(createMessageDTO);
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7243/api/Messages?id={id}");
            return RedirectToAction("MessageList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7243/api/Messages/GetMessageById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateMessageDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDTO updateMessageDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateMessageDTO);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7243/api/Messages", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("MessageList");
            }
            return View(updateMessageDTO);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeMessageStatusFailed(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7243/api/Messages/GetMessageById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateMessageDTO>(jsonData);
                var content = new StringContent(JsonConvert.SerializeObject(value), System.Text.Encoding.UTF8, "application/json");
                var result = await client.PutAsync("https://localhost:7243/api/Messages/ChangeMessageStatusFailed", content);
                return RedirectToAction("MessageList");
            }
            return RedirectToAction("MessageList");
        }

        [HttpGet]
        public async Task<IActionResult> ChangeMessageStatusRead(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7243/api/Messages/GetMessageById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateMessageDTO>(jsonData);
                var content = new StringContent(JsonConvert.SerializeObject(value), System.Text.Encoding.UTF8, "application/json");
                var result = await client.PutAsync("https://localhost:7243/api/Messages/ChangeMessageStatusRead", content);
                return RedirectToAction("MessageList");
            }
            return RedirectToAction("MessageList");
        }

        [HttpGet]
        public async Task<IActionResult> ChangeMessageStatusUnRead(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7243/api/Messages/GetMessageById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateMessageDTO>(jsonData);
                var content = new StringContent(JsonConvert.SerializeObject(value), System.Text.Encoding.UTF8, "application/json");
                var result = await client.PutAsync("https://localhost:7243/api/Messages/ChangeMessageStatusUnRead", content);
                return RedirectToAction("MessageList");
            }
            return RedirectToAction("MessageList");
        }

        [HttpGet]
        public async Task<IActionResult> AnswerMessagesWithOpenAI(int id, string prompt)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7243/api/Messages/GetMessageById?id={id}");
            var jsonData = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateMessageDTO>(jsonData);
            prompt = value.MessageDetails;

            var prePrompt = "Create an auto reply to this following customer message : ";
            var clientAI = new HttpClient();
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
                    { "x-rapidapi-key", "$" },
                    { "x-rapidapi-host", "chatgpt-42.p.rapidapi.com" },
                },
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            using (var responseAI = await clientAI.SendAsync(request))
            {
                responseAI.EnsureSuccessStatusCode();
                var responseBody = await responseAI.Content.ReadAsStringAsync();

                var result = System.Text.Json.JsonSerializer.Deserialize<ChatResponseModel>(responseBody);

                if (result != null && result.Choices != null && result.Choices.Any())
                {
                    ViewBag.Recipe = result.Choices[0].Message.Content;
                }
                else
                {
                    ViewBag.ErrorMessage = "Auto reply generation failed. Please try again.";
                }
            }

            return View(value);
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDTO createMessageDTO)
        {
            var huggingFaceClient = new HttpClient();
            var apiKey = "$";
            huggingFaceClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);


            try
            {
                //Translate
                var translateRequestBody = new
                {
                    inputs = createMessageDTO.MessageDetails
                };

                var translateJson = System.Text.Json.JsonSerializer.Serialize(translateRequestBody);
                var translateContent = new StringContent(translateJson, Encoding.UTF8, "application/json");
                var translateResponse = await huggingFaceClient.PostAsync("https://api-inference.huggingface.com/models/tencent/Hunyuan-MT-7B", translateContent);
                var translateResponseString = await translateResponse.Content.ReadAsStringAsync();
                var translatedText = createMessageDTO.MessageDetails;
                if (translateResponseString.TrimStart().StartsWith("["))
                {
                    var translateDoc = JsonDocument.Parse(translateResponseString);
                    translatedText = translateDoc.RootElement[0].GetProperty("translation_text").GetString();
                    ViewBag.TranslateText = translatedText;
                    createMessageDTO.MessageDetails = translatedText;
                }

                //Toxic
                var toxicRequestBody = new
                {
                    inputs = translatedText
                };

                var toxicJson = System.Text.Json.JsonSerializer.Serialize(toxicRequestBody);
                var toxicContent = new StringContent(toxicJson, Encoding.UTF8, "application/json");
                var toxicResponse = await huggingFaceClient.PostAsync("https://api-inference.huggingface.com/models/j-hartmann/emotion-english-distilroberta-base", toxicContent);
                var toxicResponseString = await toxicResponse.Content.ReadAsStringAsync();
                if (translateResponseString.TrimStart().StartsWith("["))
                {
                    var toxicDoc = JsonDocument.Parse(toxicResponseString);
                    foreach (var item in toxicDoc.RootElement.EnumerateArray())
                    {
                        var label = item.GetProperty("label").GetString();
                        var score = item.GetProperty("score").GetDecimal();

                        if(score > 0.5m)
                        {
                            createMessageDTO.MessageType = label;
                            break;
                        }
                    }
                }
                if(string.IsNullOrEmpty(createMessageDTO.MessageType))
                {
                    createMessageDTO.MessageType = "Non-Toxic";
                }
            }
            catch
            {
                createMessageDTO.MessageType = "Waiting...";
                //throw;
            }

            createMessageDTO.MessageStatus = MessageStatus.UnRead;
            createMessageDTO.SentDate = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDTO);
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7243/api/Messages", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("MessageList");
            }
            return View();
        }
    }
}
