using Microsoft.AspNetCore.Mvc;
using PracticeNetCore.Interfaces;

namespace PracticeNetCore.ViewComponents
{
    public class KategoriList : ViewComponent
    {
        private readonly IKategoryRepository _kategoriRepository;
        public KategoriList(IKategoryRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(_kategoriRepository.GetirHepsi());
        }
    }
}
