using Microsoft.AspNetCore.Mvc;

namespace SurfsProject.Controllers
{
    public class SurfBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
