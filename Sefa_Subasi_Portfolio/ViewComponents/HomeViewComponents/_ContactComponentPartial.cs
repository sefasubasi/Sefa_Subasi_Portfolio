using Microsoft.AspNetCore.Mvc;

namespace Sefa_Subasi_Portfolio.ViewComponents.HomeViewComponents
{
    public class _ContactComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
