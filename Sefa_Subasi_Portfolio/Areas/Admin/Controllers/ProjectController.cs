
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sefa_Subasi_Portfolio.DAL.Context;
using Sefa_Subasi_Portfolio.DAL.Entities;

namespace Sefa_Subasi_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly PortfolioContext _context;

        public ProjectController(PortfolioContext context)
        {
            _context = context;
        }

        // Listele
        public IActionResult Index()
        {
            var projects = _context.Projects
                .Include(x => x.ProjectTechnologies)
                .ToList();

            return View(projects);
        }

        // Ekle
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project project, string technologies)
        {
            project.ProjectTechnologies = technologies
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new ProjectTechnology
                {
                    ProjectTechnologyName = x.Trim()
                }).ToList();

            _context.Projects.Add(project);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Güncelle
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var project = _context.Projects
                .Include(x => x.ProjectTechnologies)
                .FirstOrDefault(x => x.ProjectId == id);

            ViewBag.Technologies = string.Join(", ",
                project.ProjectTechnologies.Select(x => x.ProjectTechnologyName));

            return View(project);
        }

        [HttpPost]
        public IActionResult Edit(Project project, string technologies)
        {
            var existing = _context.Projects
                .Include(x => x.ProjectTechnologies)
                .FirstOrDefault(x => x.ProjectId == project.ProjectId);

            existing.Head = project.Head;
            existing.ProjectCategory = project.ProjectCategory;
            existing.Detail = project.Detail;
            existing.WebSite = project.WebSite;

            _context.ProjectTechnologies.RemoveRange(existing.ProjectTechnologies);

            existing.ProjectTechnologies = technologies
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new ProjectTechnology
                {
                    ProjectTechnologyName = x.Trim(),
                    ProjectId = existing.ProjectId
                }).ToList();

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Sil
        public IActionResult Delete(int id)
        {
            var project = _context.Projects
                .Include(x => x.ProjectTechnologies)
                .FirstOrDefault(x => x.ProjectId == id);

            _context.Projects.Remove(project);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
