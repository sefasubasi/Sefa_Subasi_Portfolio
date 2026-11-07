using Microsoft.AspNetCore.Mvc;
using Sefa_Subasi_Portfolio.DAL.Context;
using Sefa_Subasi_Portfolio.DAL.Entities;

namespace Sefa_Subasi_Portfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly PortfolioContext _context;

        public ContactController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
