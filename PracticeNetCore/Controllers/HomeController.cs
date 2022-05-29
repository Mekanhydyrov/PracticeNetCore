using Microsoft.AspNetCore.Mvc;
using PracticeNetCore.Interfaces;

namespace PracticeNetCore.Controllers
{
    public class HomeController : Controller
    {
        IUrunRepository _urunRepository;
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
