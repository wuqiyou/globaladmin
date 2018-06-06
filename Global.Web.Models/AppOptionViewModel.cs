using Global.Data;
using System.Collections.Generic;

namespace Global.Web.Models
{
    public class AppOptionViewModel : AdminBaseViewModel
    {
        public IEnumerable<ApplicationSettingDto> Instances { get; set; }
    }
}