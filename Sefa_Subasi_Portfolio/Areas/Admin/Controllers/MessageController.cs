
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sefa_Subasi_Portfolio.DAL.Context;

namespace Sefa_Subasi_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly PortfolioContext _context;

        public MessageController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var messages = _context.Messages
                .AsNoTracking()
                .OrderByDescending(x => x.SendDate)
                .ToList();

            return View(messages);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var message = _context.Messages.Find(id);

            if (message == null)
                return NotFound();

            _context.Messages.Remove(message);
            _context.SaveChanges();

            TempData["Success"] = "Mesaj başarıyla silindi.";

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var message = await _context.Messages
                .FirstOrDefaultAsync(x => x.MessageId == id);

            if (message == null)
                return NotFound();

            message.IsRead = true;
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }
    }
}
