using PracticeNetCore.Entities;
using System.Collections.Generic;

namespace PracticeNetCore.Interfaces
{
    public interface IUrunRepository : IGenericRepository<Urun>
    {
        List<Kategori> GetirKategoriler(int urunId);
    }
}
