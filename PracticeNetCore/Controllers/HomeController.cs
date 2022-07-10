using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLog;
using PracticeNetCore.Entities;
using PracticeNetCore.Interfaces;
using PracticeNetCore.Models;
using System.Linq;

namespace PracticeNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUrunRepository _urunRepository;
        private readonly ISepetRepository _sepetRepository;
        public HomeController(IUrunRepository urunRepository, SignInManager<AppUser> signInManager, ISepetRepository sepetRepository)
        {
            _sepetRepository = sepetRepository;
            _signInManager = signInManager;
            _urunRepository = urunRepository;
        }
        public IActionResult Index(int? kategoriId)
        {
            ViewBag.KategoriId = kategoriId;
            //SetCookie("kisi", "Mekan Hydyrov");
            //SetSession("kisi", "Mekan Hydyrov");
            if (_sepetRepository.GetirSepettekiUrunler() != null)
            {
                @ViewBag.Sepet = _sepetRepository.GetirSepettekiUrunler().Count();
            }

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
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
            }
            return View(model);
        }
        public IActionResult EkleSepet(int id)
        {
            var urun = _urunRepository.GetirIdile(id);
            _sepetRepository.SepeteEkle(urun);
            TempData["bildirim"] = "Ürün Sepete Eklendi";
            return RedirectToAction("Index");
        }
        public IActionResult Sepet()
        {
            @ViewBag.Sepet = _sepetRepository.GetirSepettekiUrunler().Count();
            return View(_sepetRepository.GetirSepettekiUrunler());
        }
        public IActionResult SepetiBosalt(decimal fiyat)
        {
            _sepetRepository.SepetiBosalt();
            return RedirectToAction("Tesekkur", new { fiyat = fiyat });
        }
        public IActionResult Tesekkur(decimal fiyat)
        {
            ViewBag.Fiyat = fiyat;
            return View();
        }
        public IActionResult SepettenCikar(int id)
        {
            var cikarilcakUrun = _urunRepository.GetirIdile(id);
            _sepetRepository.SepettenCikar(cikarilcakUrun);
            return RedirectToAction("Sepet");
        }

        public IActionResult NorFound(int code)
        {
            ViewBag.Code = code;
            return View();
        }

        [Route("/Error")]
        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var logger = LogManager.GetLogger("FileLogger");
            logger.Log(LogLevel.Error, $"\n Hatanın Gerçekleştiği Yer:{errorInfo.Path} \n Hata Mesajı: {errorInfo.Error.Message} \n Stack Trace: {errorInfo.Error.StackTrace}");
            return View();
        }
    }
}
