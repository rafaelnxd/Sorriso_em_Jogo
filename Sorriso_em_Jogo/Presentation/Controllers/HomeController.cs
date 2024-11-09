using Microsoft.AspNetCore.Mvc;

namespace Sorriso_em_Jogo.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
