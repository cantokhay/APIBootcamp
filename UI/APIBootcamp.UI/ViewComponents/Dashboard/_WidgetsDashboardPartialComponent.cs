using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.ViewComponents.Dashboard
{
    public class _WidgetsDashboardPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
