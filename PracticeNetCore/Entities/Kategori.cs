using System.Collections.Generic;

namespace PracticeNetCore.Entities
{
    public class Kategori
    {
        public int Id{ get; set; }
        public string Ad { get; set; }

        public List<UrunKategori> urunKategoris { get; set; }
    }
}
