using Microsoft.Practices.ServiceLocation;
using Global.Service.Contract;
using Global.Web.Models;
using SubjectEngine.Core;
using System.Web.Mvc;

namespace Global.Web.Controllers
{
    [Authorize]
    public class SettingController : AdminBaseController
    {
        public const string ControllerName = "Setting";
        public const string IndexAction = "Index";
        public const string AliasListAction = "AliasList";
        public const string AppOptionsAction = "AppOptions";
        public const string MenusAction = "Menus";
        public const string TemplatesAction = "Templates";
        public const string BlocksAction = "Blocks";
        public const string DataTypesAction = "DataTypes";

        private IGeneralService Service { get; set; }  

        public SettingController()
            : base(FolderType.Setting)
        {
            Service = ServiceLocator.Current.GetInstance<IGeneralService>();
        }

        public ActionResult Index()
        {
            return RedirectToAction(AppOptionsAction);
        }

        public ActionResult Templates()
        {
            return RedirectToAction(TemplateController.IndexAction, TemplateController.ControllerName);
        }

        public ActionResult Blocks()
        {
            return RedirectToAction(BlockController.IndexAction, BlockController.ControllerName);
        }

        public ActionResult DataTypes()
        {
            return RedirectToAction(DataTypeController.IndexAction, DataTypeController.ControllerName);
        }

        public ViewResult AliasList()
        {
            SettingViewModel model = new SettingViewModel();
            model.FolderTree = GetCurrentFolderTree();
            model.Instances = Service.GetAllAliases();
            return View(model);
        }

        public ViewResult AppOptions()
        {
            AppOptionViewModel model = new AppOptionViewModel();
            model.FolderTree = GetCurrentFolderTree();
            model.Instances = Service.GetAppSettings();
            return View(model);
        }

        public ViewResult Menus()
        {
            MenuViewModel model = new MenuViewModel();
            model.FolderTree = GetCurrentFolderTree();
            model.Instances = Service.GetMainMenus();
            return View(model);
        }
    }
}
