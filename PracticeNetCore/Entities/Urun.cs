using System.Collections.Generic;

namespace PracticeNetCore.Entities
{
    public class Urun
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Resim { get; set; }
        public decimal Fiyat { get; set; }

        public List<UrunKategori> urunKategoris { get; set; }
    }
}
