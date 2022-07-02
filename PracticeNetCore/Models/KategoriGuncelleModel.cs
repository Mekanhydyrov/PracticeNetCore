using System.ComponentModel.DataAnnotations;

namespace PracticeNetCore.Models
{
    public class KategoriGuncelleModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ("Ad Alanı Boş Bırakılamaz."))]
        public string Ad { get; set; }
    }
}
