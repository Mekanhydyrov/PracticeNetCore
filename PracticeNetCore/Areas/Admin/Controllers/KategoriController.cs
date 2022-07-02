using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticeNetCore.Entities;
using PracticeNetCore.Interfaces;
using PracticeNetCore.Models;

namespace PracticeNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class KategoriController : Controller
    {
        private readonly IKategoryRepository _kategoriRepository;
        public KategoriController(IKategoryRepository kategoryRepository)
        {
            _kategoriRepository = kategoryRepository;
        }
        public IActionResult Index()
        {
            return View(_kategoriRepository.GetirHepsi());
        }
        public IActionResult Ekle()
        {
            return View(new KategoriEkleModel());
        }
        [HttpPost]
        public IActionResult Ekle(KategoriEkleModel model)
        {
            if (ModelState.IsValid)
            {
                _kategoriRepository.Ekle(new Kategori
                {
                    Ad = model.Ad
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        //Güncelleme işlemi
        public IActionResult Guncelle(int id)
        {
            var guncellenecekKategori = _kategoriRepository.GetirIdile(id);

            KategoriGuncelleModel model = new KategoriGuncelleModel
            {
                Id = guncellenecekKategori.Id,
                Ad = guncellenecekKategori.Ad
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Guncelle(KategoriGuncelleModel model)
        {
            if (ModelState.IsValid)
            {
                var guncellenecekKategori = _kategoriRepository.GetirIdile(model.Id);
                guncellenecekKategori.Ad = model.Ad;
                _kategoriRepository.Guncelle(guncellenecekKategori);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Sil(int id)
        {
            _kategoriRepository.Sil(new Kategori { Id = id });
            return RedirectToAction("Index");
        }
    }
}
