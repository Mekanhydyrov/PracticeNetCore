using PracticeNetCore.Contexts;
using PracticeNetCore.Entities;
using PracticeNetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PracticeNetCore.Repositories
{
    public class UrunKategoriRepository : GenericRepository<UrunKategori>, IUrunKategoriRepository
    {
        public UrunKategori GetirFiltireile(Expression<Func<UrunKategori, bool>> filter)
        {
            using var context = new Context();
            return context.UrunKategoris.FirstOrDefault(filter);
        }
    }
}
