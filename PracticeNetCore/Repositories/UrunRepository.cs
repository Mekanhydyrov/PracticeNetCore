using PracticeNetCore.Contexts;
using PracticeNetCore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PracticeNetCore.Repositories
{
    public class UrunRepository
    {
        public void Ekle(Urun tablo)
        {
            using var context = new Context();
            context.Uruns.Add(tablo);
            context.SaveChanges();
        }
        public void Guncelle(Urun tablo)
        {
            using var context = new Context();
            context.Uruns.Update(tablo);
            context.SaveChanges();
        }
        public void Sil(Urun tablo)
        {
            using var context = new Context();
            context.Uruns.Remove(tablo);
            context.SaveChanges();
        }
        public List<Urun> GetirHepsi()
        {
            using var context = new Context();
            return context.Uruns.OrderByDescending(I => I.Id).ToList();
        }
        public Urun GetirIdile(int id)
        {
            using var context = new Context();
            return context.Uruns.Find(id);
        }
    }
}
