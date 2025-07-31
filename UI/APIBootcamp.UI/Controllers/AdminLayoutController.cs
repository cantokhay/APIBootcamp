using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
