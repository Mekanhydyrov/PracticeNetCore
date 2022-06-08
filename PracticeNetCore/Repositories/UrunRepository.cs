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
    }
}

