using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticeNetCore.Interfaces;

namespace PracticeNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUrunRepository _urunRepository;
        public HomeController(IUrunRepository urunRepository)
        {
            _urunRepository = urunRepository;
        }
        public IActionResult Index()
        {
            return View(_urunRepository.GetirHepsi());
        }
    }
}
