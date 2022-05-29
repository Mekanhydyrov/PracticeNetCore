using PracticeNetCore.Contexts;
using PracticeNetCore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PracticeNetCore.Repositories
{
    public class KategoriRepository
    {
        public void Ekle(Kategori tablo)
        {
            using var context = new Context();
            context.Kategoris.Add(tablo);
            context.SaveChanges();
        }
        public void Guncelle(Kategori tablo)
        {
            using var context = new Context();
            context.Kategoris.Update(tablo);
            context.SaveChanges();
        }
        public void Sil(Kategori tablo)
        {
            using var context = new Context();
            context.Kategoris.Remove(tablo);
            context.SaveChanges();
        }
        public List<Kategori> GetirHepsi()
        {
            using var context = new Context();
            return context.Kategoris.OrderByDescending(I=>I.Id).ToList();
        }
        public Kategori GetirIdile(int id)
        {
            using var context = new Context();
            return context.Kategoris.Find(id);
        }
    }
}
