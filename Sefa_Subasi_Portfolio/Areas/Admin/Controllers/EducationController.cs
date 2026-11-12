
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sefa_Subasi_Portfolio.DAL.Context;
using Sefa_Subasi_Portfolio.DAL.Entities;

namespace Sefa_Subasi_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationController : Controller
    {
        private readonly PortfolioContext _context;

        public EducationController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Educations.ToList();
            return View(values);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Education education)
        {
            _context.Educations.Add(education);
            _context.SaveChanges();

            TempData["Success"] = "Eğitim bilgisi başarıyla eklendi.";

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Education education)
        {
            var value = _context.Educations.Find(education.EducationId);

            if (value == null)
                return NotFound();

            value.Title = education.Title;
            value.SchoolName = education.SchoolName;
            value.Durum = education.Durum;
            value.Description = education.Description;

            _context.SaveChanges();

            TempData["Success"] = "Eğitim bilgisi başarıyla güncellendi.";

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var value = _context.Educations.Find(id);

            if (value == null)
                return NotFound();

            _context.Educations.Remove(value);
            _context.SaveChanges();

            TempData["Success"] = "Eğitim bilgisi başarıyla silindi.";


            return RedirectToAction("Index");
        }
    }
}
