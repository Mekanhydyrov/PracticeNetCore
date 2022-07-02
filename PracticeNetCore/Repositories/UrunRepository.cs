using PracticeNetCore.Contexts;
using PracticeNetCore.Entities;
using PracticeNetCore.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;


namespace PracticeNetCore.Repositories
{
    public class UrunRepository : GenericRepository<Urun>, IUrunRepository
    {
        private readonly IUrunKategoriRepository _urunKategoriRepository;
        public UrunRepository(IUrunKategoriRepository urunKategoriRepository)
        {
            _urunKategoriRepository = urunKategoriRepository;
        }
        public List<Kategori> GetirKategoriler(int urunId)
        {
            using var context = new Context();
            return context.Uruns.Join(context.UrunKategoris, urun => urun.Id, urunKategori => urunKategori.UrunId, (u, uc) => new
            {
                urun = u,
                urunKategori = uc
            }).Join(context.Kategoris, iki => iki.urunKategori.KategoriId, kategori => kategori.Id, (uc, k) => new
            {
                urun = uc.urun,
                kategori = k,
                urunKategori = uc.urunKategori
            }).Where(I => I.urun.Id == urunId).Select(I => new Kategori
            {
                Id = I.kategori.Id,
                Ad = I.kategori.Ad
            }).ToList();
        }

        public void SilKategori(UrunKategori urunKategori)
        {
            var kontrolKayit = _urunKategoriRepository.GetirFiltireile(I => I.KategoriId == urunKategori.KategoriId &&
            I.UrunId == urunKategori.UrunId);
            if(kontrolKayit != null)
            {
                _urunKategoriRepository.Sil(kontrolKayit);
            }
        }
        public void EkleKategori(UrunKategori urunKategori)
        {
            var kotrolKayit = _urunKategoriRepository.GetirFiltireile(I => I.KategoriId == urunKategori.KategoriId &&
            I.UrunId == urunKategori.UrunId);
            if (kotrolKayit == null)
            {
                _urunKategoriRepository.Ekle(urunKategori);
            }
        }
        public List<Urun> GetirKategoriIdile(int kategoriId)
        {
            using var context = new Context();

           return context.Uruns.Join(context.UrunKategoris, u => u.Id, uc => uc.UrunId, (urun, urunKategori) => new
            {
                Urun = urun,
                UrunKategori = urunKategori
            }).Where(I => I.UrunKategori.KategoriId == kategoriId).Select(I => new Urun
            {
                Id = I.Urun.Id,
                Ad = I.Urun.Ad,
                Fiyat = I.Urun.Fiyat,
                Resim = I.Urun.Resim
            }).ToList();
        }
    }
}

