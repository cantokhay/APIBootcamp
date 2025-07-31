using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.ViewComponents.AdminLayout
{
    public class _NavbarAdminPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
