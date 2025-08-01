using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.ViewComponents.AdminLayout
{
    public class _SettingsAdminPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
