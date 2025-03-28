using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.ViewComponents.Default
{
    public class _HeadDefaultPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
