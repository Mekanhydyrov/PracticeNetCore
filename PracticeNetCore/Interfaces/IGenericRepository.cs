using System.Collections.Generic;

namespace PracticeNetCore.Interfaces
{
    public interface IGenericRepository<Tablo> where Tablo : class, new()
    {
        void Ekle(Tablo tablo);
        void Guncelle(Tablo tablo);
        void Sil(Tablo tablo);
        List<Tablo> GetirHepsi();
        Tablo GetirIdile(int id);
    }
}
