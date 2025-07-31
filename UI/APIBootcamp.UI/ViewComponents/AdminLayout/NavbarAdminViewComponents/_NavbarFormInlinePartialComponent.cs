using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.ViewComponents.AdminLayout.NavbarAdminViewComponents
{
    public class _NavbarFormInlinePartialComponent : ViewComponent
    { 
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
