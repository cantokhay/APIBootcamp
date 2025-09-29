using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult SendChatWithAI()
        {
            return View();
        }
    }
}
