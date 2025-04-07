using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.ViewComponents.Default
{
    public class _FeatureDefaultPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
