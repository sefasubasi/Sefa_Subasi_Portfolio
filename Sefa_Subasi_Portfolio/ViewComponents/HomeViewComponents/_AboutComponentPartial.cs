using Microsoft.AspNetCore.Mvc;
using Sefa_Subasi_Portfolio.DAL.Context;

namespace Sefa_Subasi_Portfolio.ViewComponents.HomeViewComponents
{
    public class _AboutComponentPartial : ViewComponent
    {
        PortfolioContext context = new PortfolioContext();
        public IViewComponentResult Invoke()
        {

            ViewBag.Title = context.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.SubDescription = context.Abouts.Select(x => x.SubDescription).FirstOrDefault();
            ViewBag.Details = context.Abouts.Select(x => x.Details).FirstOrDefault();
            ViewBag.AboutImgUrl = context.Abouts.Select(x => x.AboutImgUrl).FirstOrDefault();


            return View();
        }
    }
}
