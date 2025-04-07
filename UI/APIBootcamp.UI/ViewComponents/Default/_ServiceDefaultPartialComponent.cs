using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.ViewComponents.Default
{
    public class _ServiceDefaultPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
