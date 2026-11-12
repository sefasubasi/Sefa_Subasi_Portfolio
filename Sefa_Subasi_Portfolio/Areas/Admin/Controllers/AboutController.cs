using Microsoft.AspNetCore.Mvc;
using Sefa_Subasi_Portfolio.DAL.Context;
using Sefa_Subasi_Portfolio.DAL.Entities;

namespace Sefa_Subasi_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly PortfolioContext _context;
        public AboutController(PortfolioContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values = _context.Abouts.FirstOrDefault();
            return View(values);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(About about, IFormFile? imageFile)
        {
            var value = _context.Abouts.FirstOrDefault();

            if (value == null)
                return NotFound();

            if (string.IsNullOrWhiteSpace(about.Title) ||
                string.IsNullOrWhiteSpace(about.Details) ||
                string.IsNullOrWhiteSpace(about.SubDescription))
            {
                TempData["NullArea"] = "Boş alan bırakılamaz!";
                return RedirectToAction("Index");
            }

            value.Title = about.Title;
            value.SubDescription = about.SubDescription;
            value.Details = about.Details;

            // Resim yükleme
            if (imageFile != null && imageFile.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
                var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                {
                    TempData["NullArea"] = "Geçersiz resim formatı!";
                    return RedirectToAction("Index");
                }

                if (imageFile.Length > 5 * 1024 * 1024)
                {
                    TempData["NullArea"] = "Resim boyutu 5 MB'dan büyük olamaz!";
                    return RedirectToAction("Index");
                }

                var folderPath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot", "images", "about");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                var fileName = Guid.NewGuid().ToString() + extension;
                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                // Eski resmi sil
                if (!string.IsNullOrEmpty(value.AboutImgUrl))
                {
                    var oldImagePath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        value.AboutImgUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));

                    if (System.IO.File.Exists(oldImagePath))
                        System.IO.File.Delete(oldImagePath);
                }

                value.AboutImgUrl = "/images/about/" + fileName;
            }

            _context.SaveChanges();

            TempData["SuccessMessage"] = "Hakkımda bilgileri güncellendi.";

            return RedirectToAction("Index");
        }


    }
}
