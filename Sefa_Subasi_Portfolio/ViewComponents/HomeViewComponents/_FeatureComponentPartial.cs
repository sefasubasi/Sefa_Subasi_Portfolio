using Microsoft.AspNetCore.Mvc;
using Sefa_Subasi_Portfolio.DAL.Context;

namespace Sefa_Subasi_Portfolio.ViewCompanents.HomeViewCompanents
{
    public class _FeatureComponentPartial:ViewComponent
    {
        private readonly PortfolioContext context;

        public _FeatureComponentPartial(PortfolioContext _context)
        {
            context = _context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Name = context.Features.Select(x => x.FeatureName).FirstOrDefault();
            ViewBag.Title = context.Features.Select(x => x.FeatureTitle).FirstOrDefault();
            ViewBag.Head = context.Features.Select(x => x.FeatureHead).FirstOrDefault();
            ViewBag.Subtitle = context.Features.Select(x => x.FeatureSubtitle).FirstOrDefault();
            ViewBag.Detail = context.Features.Select(x => x.FeatureDetail).FirstOrDefault();
            ViewBag.FeatureImgUrl = context.Features.Select(x => x.FeatureImgUrl).FirstOrDefault();

            return View();
        }
    }
}
