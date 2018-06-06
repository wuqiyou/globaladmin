using Global.Data;
using SubjectEngine.Core;

namespace Global.Web.Common.Models
{
    public class DucViewModel
    {
        public object DucId { get; set; }
        public DucTypes DucType { get; set; }
        public DucValueDto DucValue { get; set; }
        public LanguageDto CurrentLanguage { get; set; }
    }
}