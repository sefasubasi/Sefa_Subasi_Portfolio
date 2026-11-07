using Microsoft.AspNetCore.Mvc;
using Sefa_Subasi_Portfolio.DAL.Context;

namespace Sefa_Subasi_Portfolio.ViewComponents.HomeViewComponents
{
    public class _EducationComponentPartial:ViewComponent
    {
        private readonly PortfolioContext _context;

        public _EducationComponentPartial(PortfolioContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Educations.ToList();
            return View(values);
        }
    }
}
