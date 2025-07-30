using Microsoft.AspNetCore.Mvc;

namespace APIBootcamp.UI.ViewComponents.Default
{
    public class _FooterScriptDefaultPartialComponent : ViewComponent
    {    
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
