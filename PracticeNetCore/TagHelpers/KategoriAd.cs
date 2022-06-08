using Microsoft.AspNetCore.Razor.TagHelpers;
using PracticeNetCore.Interfaces;
using System.Linq;

namespace PracticeNetCore.TagHelpers
{
    [HtmlTargetElement("getirKategoriAd")]
    public class KategoriAd : TagHelper
    {
        private readonly IUrunRepository _urunRepository;
        public KategoriAd(IUrunRepository urunRepository)
        {
            _urunRepository = urunRepository;
        }
        public int UrunId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string data = "";
            var gelenKategoriler = _urunRepository.GetirKategoriler(UrunId).Select(I => I.Ad);
            foreach (var item in gelenKategoriler)
            {
                data += item + " ";
            }
            output.Content.SetContent(data);    
        }
    }
}
