using PracticeNetCore.Entities;
using System.Collections.Generic;

namespace PracticeNetCore.Interfaces
{
    public interface ISepetRepository
    {
        void SepeteEkle(Urun urun);
        void SepettenCikar(Urun urun);
        List<Urun> GetirSepettekiUrunler();
        void SepetiBosalt();
    }
}
