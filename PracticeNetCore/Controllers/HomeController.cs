using Microsoft.AspNetCore.Mvc;

namespace PracticeNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
