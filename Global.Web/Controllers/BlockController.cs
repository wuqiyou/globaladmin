using Microsoft.Practices.ServiceLocation;
using Global.Service.Contract;
using Global.Web.Models;
using SubjectEngine.Core;
using System.Web.Mvc;

namespace Global.Web.Controllers
{
    [Authorize]
    public class BlockController : AdminBaseController
    {
        public const string ControllerName = "Block";
        public const string IndexAction = "Index";
        public const string CreateAction = "Create";
        public const string DetailAction = "Detail";
        public const string EditAction = "Edit";
        public const string EditLayoutAction = "EditLayout";

        private IBlockService Service { get; set; }

        public BlockController()
            : base(FolderType.Setting)
        {
            Service = ServiceLocator.Current.GetInstance<IBlockService>();
        }

        public ViewResult Index()
        {
            BlockListViewModel model = new BlockListViewModel();
            model.FolderTree = GetCurrentFolderTree();
            model.Instances = Service.GetBlocks();
            return View(model);
        }

        public ViewResult Detail(int id)
        {
            BlockDetailViewModel model = new BlockDetailViewModel();
            model.FolderTree = GetCurrentFolderTree();
            model.Instance = Service.GetBlock(id);
            return View(model);
        }

        public ViewResult Edit(int id)
        {
            BlockEditViewModel model = GetModel(id);
            return View(model);
        }

        public ViewResult EditCategory(int id)
        {
            BlockEditViewModel model = GetModel(id);
            return View(model);
        }

        public ViewResult EditLayout(int id)
        {
            BlockEditViewModel model = GetModel(id);
            return View(model);
        }

        private BlockEditViewModel GetModel(int BlockId)
        {
            BlockEditViewModel model = new BlockEditViewModel();
            model.FolderTree = GetCurrentFolderTree();
            model.Instance = Service.GetBlock(BlockId);
            return model;
        }
    }
}
