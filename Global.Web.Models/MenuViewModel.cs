using Global.Data;
using System.Collections.Generic;

namespace Global.Web.Models
{
    public class MenuViewModel : AdminBaseViewModel
    {
        public IEnumerable<MainMenuDto> Instances { get; set; }
    }
}