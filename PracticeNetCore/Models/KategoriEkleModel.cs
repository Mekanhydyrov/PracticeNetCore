using System.ComponentModel.DataAnnotations;

namespace PracticeNetCore.Models
{
    public class KategoriEkleModel
    {
        [Required(ErrorMessage =("Ad Alanı Boş Bırakılamaz."))]
        public string Ad { get; set; }
    }
}
