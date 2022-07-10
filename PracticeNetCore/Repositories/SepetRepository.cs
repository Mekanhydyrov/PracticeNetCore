using Microsoft.AspNetCore.Http;
using PracticeNetCore.CustomExtensions;
using PracticeNetCore.Entities;
using PracticeNetCore.Interfaces;
using System.Collections.Generic;

namespace PracticeNetCore.Repositories
{
    public class SepetRepository : ISepetRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SepetRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void SepeteEkle(Urun urun)
        {
            var gelenListe = _httpContextAccessor.HttpContext.Session.GetObject<List<Urun>>("Sepet");

            if(gelenListe == null)
            {
                gelenListe = new List<Urun>();
                gelenListe.Add(urun);
            }
            else
            {
                gelenListe.Add(urun);
            }
            _httpContextAccessor.HttpContext.Session.SetObject("Sepet", gelenListe);
        }
        public void SepettenCikar(Urun urun)
        {
            var gelenListe = _httpContextAccessor.HttpContext.Session.GetObject<List<Urun>>("Sepet");
            gelenListe.Remove(urun);

            _httpContextAccessor.HttpContext.Session.SetObject("Sepet", gelenListe);
        }

        public List<Urun> GetirSepettekiUrunler()
        {
            return _httpContextAccessor.HttpContext.Session.GetObject<List<Urun>>("Sepet");
        }
        public void SepetiBosalt()
        {
            _httpContextAccessor.HttpContext.Session.Remove("Sepet");
        }
    }
}
