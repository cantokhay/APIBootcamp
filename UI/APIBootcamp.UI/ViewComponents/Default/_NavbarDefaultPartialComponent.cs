using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.ViewComponents.Default
{
    public class _NavbarDefaultPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
