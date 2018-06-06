using Global.Data;
using System.Collections.Generic;
using Global.Web.Common;

namespace Global.Web.Models
{
    public class ReferenceCreateViewModel : AdminBaseViewModel
    {
        public ReferenceDto Instance { get; set; }
        public IEnumerable<TemplateInfoDto> AvailableTemplates { get; set; }

        public ReferenceCreateViewModel()
        {
            Instance = new ReferenceDto();
            Instance.EnableAds = true;
            Instance.EnableTopAd = true;
            IsEditing = true;
        }
    }
}