using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sefa_Subasi_Portfolio.DAL.Context;

namespace Sefa_Subasi_Portfolio.ViewComponents.HomeViewComponents
{
    public class _ProjectComponentPartial:ViewComponent
    {
        private readonly PortfolioContext _context;
        public _ProjectComponentPartial(PortfolioContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var projects = _context.Projects.Include(x => x.ProjectTechnologies).ToList();
            return View(projects);
        }
    }
}
