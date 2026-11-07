using Microsoft.AspNetCore.Mvc;

namespace Sefa_Subasi_Portfolio.ViewComponents.HomeViewComponents
{
    public class _ScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
