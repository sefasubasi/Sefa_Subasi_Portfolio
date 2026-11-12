
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sefa_Subasi_Portfolio.DAL.Context;
using Sefa_Subasi_Portfolio.DAL.Entities;

namespace Sefa_Subasi_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EnterController : Controller
    {
        private readonly PortfolioContext _context;
        private readonly IWebHostEnvironment _environment;

        public EnterController(
            PortfolioContext context,
            IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var feature = await _context.Features.FirstOrDefaultAsync();

            if (feature == null)
                return NotFound("Feature kaydı bulunamadı.");

            return View(feature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FeatureUpdate(
            Feature feature,
            IFormFile? imageFile)
        {
            var existingFeature = await _context.Features
                .FirstOrDefaultAsync(x => x.FeatureId == feature.FeatureId);

            if (existingFeature == null)
                return NotFound();

            // Metin alanlarını güncelle
            existingFeature.FeatureName = feature.FeatureName;
            existingFeature.FeatureTitle = feature.FeatureTitle;
            existingFeature.FeatureHead = feature.FeatureHead;
            existingFeature.FeatureSubtitle = feature.FeatureSubtitle;
            existingFeature.FeatureDetail = feature.FeatureDetail;

            // Yeni resim seçilmişse
            if (imageFile != null && imageFile.Length > 0)
            {
                var allowedExtensions = new[]
                {
                    ".jpg", ".jpeg", ".png", ".webp"
                };

                var extension = Path.GetExtension(imageFile.FileName)
                    .ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                {
                    TempData["Error"] = "Geçersiz resim formatı!";
                    return RedirectToAction("Index");
                }

                if (imageFile.Length > 20 * 1024 * 1024)
                {
                    TempData["Error"] = "Resim boyutu 20 MB'dan büyük olamaz!";
                    return RedirectToAction("Index");
                }

                var folderPath = Path.Combine(
                    _environment.WebRootPath,
                    "images",
                    "features"
                );

                Directory.CreateDirectory(folderPath);

                var fileName = Guid.NewGuid().ToString() + extension;

                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                existingFeature.FeatureImgUrl =
                    "/images/features/" + fileName;
            }

            await _context.SaveChangesAsync();

            TempData["Success"] = "Bilgileriniz başarıyla kaydedildi!";

            return RedirectToAction("Index");
        }
    }
}
