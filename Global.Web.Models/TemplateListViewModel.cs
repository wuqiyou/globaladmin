using Global.Data;
using System.Collections.Generic;

namespace Global.Web.Models
{
    public class TemplateListViewModel : AdminBaseViewModel
    {
        public IEnumerable<TemplateInfoDto> Instances { get; set; }
    }
}