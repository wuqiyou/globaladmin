using Global.Data;
using Global.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Global.Web.Controllers
{
    public class HeaderController : Controller
    {
        public const string ControllerName = "Header";
        public const string IndexAction = "Index";

        public PartialViewResult Index()
        {
            HeaderViewModel model = new HeaderViewModel();

            List<MainMenuDto> items = new List<MainMenuDto>();
            model.MainMenus = items;

            MainMenuDto item1 = new MainMenuDto { MenuText = "Content", NavigateUrl = "Folder?subsiteid=0" };
            MainMenuDto item2 = new MainMenuDto { MenuText = "Document", NavigateUrl = "Document" };
            MainMenuDto item3 = new MainMenuDto { MenuText = "Setting", NavigateUrl = "Setting" };
            MainMenuDto item4 = new MainMenuDto { MenuText = "Subsite", NavigateUrl = "Subsite" };
            MainMenuDto item5 = new MainMenuDto { MenuText = "Collection", NavigateUrl = "Collection" };
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            items.Add(item4);
            items.Add(item5);

            return PartialView(model);
        }
    }
}
