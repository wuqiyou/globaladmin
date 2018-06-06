using Global.Data;
using System.Collections.Generic;

namespace Global.Web.Models
{
    public class SettingViewModel : AdminBaseViewModel
    {
        public IEnumerable<AliasInfoDto> Instances { get; set; }
    }
}