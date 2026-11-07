using Microsoft.AspNetCore.Mvc;
using Sefa_Subasi_Portfolio.DAL.Context;


namespace Sefa_Subasi_Portfolio.ViewComponents.HomeViewComponents
{
    public class _ExperienceComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;
        public _ExperienceComponentPartial(PortfolioContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Experiences.ToList();
            return View(values);
        }
    }
}
