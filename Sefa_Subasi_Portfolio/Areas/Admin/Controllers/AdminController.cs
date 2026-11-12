using Microsoft.AspNetCore.Mvc;

namespace Sefa_Subasi_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
