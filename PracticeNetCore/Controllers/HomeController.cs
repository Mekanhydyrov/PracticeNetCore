using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PracticeNetCore.Entities;
using PracticeNetCore.Interfaces;
using PracticeNetCore.Models;

namespace PracticeNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUrunRepository _urunRepository;
        public HomeController(IUrunRepository urunRepository, SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _urunRepository = urunRepository;
        }
        public IActionResult Index(int? kateogiriId)
        {
            ViewBag.KategoriId = kateogiriId;
            //SetCookie("kisi", "Mekan Hydyrov");
            //SetSession("kisi", "Mekan Hydyrov");
            return View();
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
        public IActionResult GirisYap()
        {
            return View(new KullaniciGirisModel());
        }
        [HttpPost]
        public IActionResult GirisYap(KullaniciGirisModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = _signInManager.PasswordSignInAsync(model.KullaniciAd, model.Sifre, model.BeniHatirla, false).Result;

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index","Home", new {area="Admin"});
                }
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
            }
            return View(model);
        }
    }
}
