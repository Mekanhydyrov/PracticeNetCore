using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PracticeNetCore.Models
{
    public class UrunGuncelleModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad Alanı Gereklidir.")]
        public string Ad { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Fiyat 0 dan Yükesek Olmalıdır.")]
        public decimal Fiyat { get; set; }
        public IFormFile Resim { get; set; }
    }
}
