using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sefa_Subasi_Portfolio.DAL.Context;

namespace Sefa_Subasi_Portfolio.ViewComponents.HomeViewComponents
{
    public class _SkillComponentPartial : ViewComponent
    {
        PortfolioContext _context = new PortfolioContext();

        public IViewComponentResult Invoke()
        {
            var skills = _context.Skills.Include(x => x.SkillItems).ToList();
            return View(skills);
        }
    }
}

