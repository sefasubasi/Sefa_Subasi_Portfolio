
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sefa_Subasi_Portfolio.DAL.Context;

namespace Sefa_Subasi_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly PortfolioContext _context;

        public ContactController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var messages = _context.Contacts
                .AsNoTracking()
                .OrderByDescending(x => x.ContactId)
                .ToList();

            return View(messages);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var message = _context.Contacts.Find(id);

            if (message == null)
                return NotFound();

            _context.Contacts.Remove(message);
            _context.SaveChanges();

            TempData["Success"] = "Mesaj başarıyla silindi.";

            return RedirectToAction("Index");
        }
    }
}
