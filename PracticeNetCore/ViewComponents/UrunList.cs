﻿using Microsoft.AspNetCore.Mvc;
using PracticeNetCore.Interfaces;

namespace PracticeNetCore.ViewComponents
{
    public class UrunList : ViewComponent
    {
        private readonly IUrunRepository _urunRepository;
        public UrunList(IUrunRepository urunRepository)
        {
            _urunRepository = urunRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(_urunRepository.GetirHepsi());
        }
    }
}
