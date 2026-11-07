using Microsoft.AspNetCore.Mvc;

namespace Sefa_Subasi_Portfolio.ViewCompanents.HomeViewCompanents
{
    public class _FeatureComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
