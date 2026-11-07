using Microsoft.AspNetCore.Mvc;

namespace Sefa_Subasi_Portfolio.ViewComponents.HomeViewComponents
{
    public class _FooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
