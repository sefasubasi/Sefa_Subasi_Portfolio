using Microsoft.AspNetCore.Mvc;

namespace Sefa_Subasi_Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
