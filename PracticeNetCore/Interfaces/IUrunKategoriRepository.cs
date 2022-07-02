using PracticeNetCore.Entities;
using System;
using System.Linq.Expressions;

namespace PracticeNetCore.Interfaces
{
    public interface IUrunKategoriRepository : IGenericRepository<UrunKategori>
    {
        UrunKategori GetirFiltireile(Expression<Func<UrunKategori, bool>> filter);
    }
}
