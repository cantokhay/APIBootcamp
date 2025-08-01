using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.ViewComponents.AdminLayout
{
    public class _SidebarAdminPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
