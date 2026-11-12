using Microsoft.AspNetCore.Mvc;
using Sefa_Subasi_Portfolio.DAL.Context;
using Sefa_Subasi_Portfolio.DAL.Entities;
using System.Text;

namespace Sefa_Subasi_Portfolio.Areas.Admin.Controllers
{ 
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        private readonly PortfolioContext _context;

        public ExperienceController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ExperienceList()
        {
            var values = _context.Experiences.ToList();

            ViewBag.LastUpdate = _context.Experiences
            .Where(x => x.UpdatedAt != null)
            .Max(x => (DateTime?)x.UpdatedAt);

            ViewBag.ExperiencesCount = _context.Experiences.ToList().Count();

            return View(values);
        }

        public IActionResult deleteExperience(int id)
        {
            var value = _context.Experiences.Find(id);
            _context.Experiences.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("ExperienceList");

        }
        [HttpGet]
        public IActionResult updateExperience(int id)
        {
            var experience = _context.Experiences.Find(id);
            return View(experience);
        }
        [HttpPost]
        public IActionResult updateExperience(Experience experience)
        {
            experience.UpdatedAt = DateTime.Now;
            _context.Experiences.Update(experience);
            _context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }
        [HttpGet]
        public IActionResult Export()
        {
            var experiences = _context.Experiences.ToList();

            var csv = new StringBuilder();

            csv.AppendLine("ID;Deneyim Başlığı;Şirket;Detay;Tarih");

            foreach (var item in experiences)
            {
                csv.AppendLine(
                    $"{item.ExperienceId};" +
                    $"{item.Title};" +
                    $"{item.Head};" +
                    $"{item.Description};" +
                    $"{item.ExperienceDate:dd.MM.yyyy}"
                );
            }

            var bytes = Encoding.UTF8.GetPreamble()
                .Concat(Encoding.UTF8.GetBytes(csv.ToString()))
                .ToArray();

            return File(bytes, "text/csv", "Deneyimler.csv");
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            _context.Experiences.Add(experience);
            _context.SaveChanges();

            return RedirectToAction("ExperienceList");
        }
    }
}
