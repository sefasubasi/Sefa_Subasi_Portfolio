
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sefa_Subasi_Portfolio.DAL.Context;
using Sefa_Subasi_Portfolio.DAL.Entities;

namespace Sefa_Subasi_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly PortfolioContext _context;

        public SkillController(PortfolioContext context)
        {
            _context = context;
        }

        // Yetenek kategorilerini listele
        public IActionResult Index()
        {
            var values = _context.Skills
                .Include(x => x.SkillItems)
                .AsNoTracking()
                .ToList();

            return View(values);
        }

        // Yeni kategori ekle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Skill skill)
        {
            if (string.IsNullOrWhiteSpace(skill.Title))
                return RedirectToAction("Index");

            skill.SkillId = 0;

            _context.Skills.Add(skill);
            _context.SaveChanges();

            TempData["Success"] = "Kategori başarıyla eklendi.";

            return RedirectToAction("Index");
        }

        // Kategori sil
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var skill = _context.Skills
                .Include(x => x.SkillItems)
                .FirstOrDefault(x => x.SkillId == id);

            if (skill == null)
                return NotFound();

            // Önce kategoriye ait yetenekleri sil
            _context.SkillItems.RemoveRange(skill.SkillItems);

            // Ardından kategoriyi sil
            _context.Skills.Remove(skill);

            _context.SaveChanges();

            TempData["Success"] = "Kategori ve yetenekleri silindi.";

            return RedirectToAction("Index");
        }

        // Kategoriye yetenek ekle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddItem(int skillId, string Name, int Level)
        {
            if (string.IsNullOrWhiteSpace(Name) || Level < 0 || Level > 100)
            {
                TempData["Error"] = "Yetenek adı ve seviyesi geçerli olmalıdır.";
                return RedirectToAction("Index");
            }

            var skill = _context.Skills
                .FirstOrDefault(x => x.SkillId == skillId);

            if (skill == null)
                return NotFound();

            var item = new SkillItem
            {
                Name = Name.Trim(),
                Level = Level,
                SkillId = skillId
            };

            _context.SkillItems.Add(item);
            _context.SaveChanges();

            TempData["Success"] = "Yetenek başarıyla eklendi.";

            return RedirectToAction("Index");
        }

        // Yetenek seviyesini güncelle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateItem(int id, int Level)
        {
            if (Level < 0 || Level > 100)
            {
                TempData["Error"] = "Seviye 0 ile 100 arasında olmalıdır.";
                return RedirectToAction("Index");
            }

            var item = _context.SkillItems
                .FirstOrDefault(x => x.SkillItemId == id);

            if (item == null)
                return NotFound();

            item.Level = Level;

            _context.SaveChanges();

            TempData["Success"] = "Yetenek seviyesi güncellendi.";

            return RedirectToAction("Index");
        }

        // Alt yeteneği sil
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int id)
        {
            var item = _context.SkillItems
                .FirstOrDefault(x => x.SkillItemId == id);

            if (item == null)
                return NotFound();

            _context.SkillItems.Remove(item);
            _context.SaveChanges();

            TempData["Success"] = "Yetenek başarıyla silindi.";

            return RedirectToAction("Index");
        }
    }
}
