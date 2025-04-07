using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.ViewComponents.Default
{
    public class _AboutDefaultPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
