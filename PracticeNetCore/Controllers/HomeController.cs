using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeNetCore.Interfaces;

namespace PracticeNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUrunRepository _urunRepository;
        public HomeController(IUrunRepository urunRepository)
        {
            _urunRepository = urunRepository;
        }
        public IActionResult Index()
        {
            //SetCookie("kisi", "Mekan Hydyrov");
            //SetSession("kisi", "Mekan Hydyrov");
            return View(_urunRepository.GetirHepsi());
        }
        public IActionResult UrunDetay(int id)
        {
            //ViewBag.Cookie = GetCookie("kisi");
            //ViewBag.Session = GetSession("kisi");
            return View(_urunRepository.GetirIdile(id));
        }
        //cookie
        //public void SetCookie(string key, string value)
        //{
        //    HttpContext.Response.Cookies.Append(key, value);
        //}
        //public string GetCookie(string key)
        //{
        //    HttpContext.Request.Cookies.TryGetValue(key, out var value);
        //    return value;
        //}

        //Session
        //public void SetSession(string key, string value)
        //{
        //    HttpContext.Session.SetString(key, value);
        //}
        //public string GetSession(string key)
        //{
        //    return HttpContext.Session.GetString(key);
        //}
    }
}
