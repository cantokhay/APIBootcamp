using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
