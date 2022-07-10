using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace PracticeNetCore.Entities
{
    public class Urun:IEquatable<Urun>
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Resim { get; set; }
        public decimal Fiyat { get; set; }

        public List<UrunKategori> urunKategoris { get; set; }

        public bool Equals([AllowNull] Urun other)
        {
            return Id == other.Id && Ad == other.Ad && Resim == other.Resim && Fiyat == other.Fiyat;
        }
    }
}
