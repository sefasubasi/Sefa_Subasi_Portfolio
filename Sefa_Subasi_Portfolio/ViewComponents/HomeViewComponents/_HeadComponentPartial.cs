using Microsoft.AspNetCore.Mvc;

namespace Sefa_Subasi_Portfolio.ViewCompanents.HomeViewCompanents
{
    public class _HeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
