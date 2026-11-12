using Microsoft.AspNetCore.Mvc;
using Sefa_Subasi_Portfolio.DAL.Context;
using Microsoft.EntityFrameworkCore;


namespace Sefa_Subasi_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController:Controller
    {
        private readonly PortfolioContext _context;

        public DashboardController(PortfolioContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            // Proje ve deneyim sayıları
            ViewBag.ProjectCount = await _context.Projects.CountAsync();
            ViewBag.ExperienceCount = await _context.Experiences.CountAsync();

            // Mesaj istatistikleri
            ViewBag.MessageCount = await _context.Messages.CountAsync();

            ViewBag.MessageRead = await _context.Messages
                .CountAsync(x => x.IsRead == false);

            ViewBag.MessageUnRead = await _context.Messages
                .CountAsync(x => x.IsRead == true);

            var values = await _context.Messages.ToListAsync();

            return View(values);

        }
    }
}
