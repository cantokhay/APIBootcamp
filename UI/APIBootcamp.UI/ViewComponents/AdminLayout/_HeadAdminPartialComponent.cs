using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.ViewComponents.AdminLayout
{
    public class _HeadAdminPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
