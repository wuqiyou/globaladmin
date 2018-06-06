using Global.Data;

namespace Global.Web.Models
{
    public class ReferenceBlockViewModel
    {
        public ReferenceInfoDto Reference { get; set; }
        public LanguageDto CurrentLanguage { get; set; }
        public BlockInfoDto Block { get; set; }
    }
}