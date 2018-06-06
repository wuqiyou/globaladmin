using Global.Data;
using System.Collections.Generic;

namespace Global.Web.Models
{
    public class HeaderViewModel : AdminBaseViewModel
    {
        public IEnumerable<MainMenuDto> MainMenus { get; set; }
    }
}