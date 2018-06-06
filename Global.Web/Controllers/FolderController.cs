using Framework.Component;
using Microsoft.Practices.ServiceLocation;
using Global.Core;
using Global.Data;
using Global.Service.Contract;
using Global.Web.Models;
using Global.Web.Common;
using Global.Web.Common.Models;
using SubjectEngine.Core;
using SubjectEngine.Data;
using System.Linq;
using System.Web.Mvc;

namespace Global.Web.Controllers
{
    [Authorize]
    public class FolderController : AdminBaseController
    {
        public const string ControllerName = "Folder";
        public const string IndexAction = "Index";
        public const string ExplorerAction = "Explorer";
        public const string EditAction = "Edit";
        public const string DetailAction = "Detail";
        public const string FolderId = "id";

        private IFolderService Service { get; set; }

        public FolderController()
            : base(FolderType.Content)
        {
            Service = ServiceLocator.Current.GetInstance<IFolderService>();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            int selectedLanguageId;
            if (int.TryParse(Request.Form["SelectedLanguageId"], out selectedLanguageId))
            {
                CurrentUserContext.SetCurrentLanguage(selectedLanguageId);
                CurrentLanguage = CurrentUserContext.CurrentLanguage;
                Redirect(Request.RawUrl);
            }
        }

        public ActionResult Index()
        {
            ReferenceViewModel model = new ReferenceViewModel();
            model.FolderTree = GetCurrentFolderTree();
            model.CurrentLanguage = CurrentLanguage;
            model.PageTitle = "Index";
            return View(model);
        }

        public ViewResult Explorer(int id, int? page)
        {
            int pageIndex = page.HasValue ? page.Value : 1;

            FolderInfoViewModel model = new FolderInfoViewModel();
            model.References = Service.GetReferences(id, pageIndex, SiteConfig.PageSize);
            int totalCount = 0;
            ReferenceBriefDto first = model.References.FirstOrDefault();
            if (first != null)
            {
                totalCount = first.TotalCount;
            }
            model.Pagination = new PaginationViewModel(totalCount, pageIndex, SiteConfig.PageSize, 5);
            model.Pagination.ShowTotal = true;
            model.FolderTree = GetCurrentFolderTree(id);
            model.Instance = model.FolderTree.CurrentFolder;
            model.PageTitle = string.Format("Folder: {0}", model.FolderTree.CurrentFolder.FullName);
            model.CurrentLanguage = CurrentLanguage;
            return View(model);
        }

        public ViewResult Edit(int id)
        {
            FolderDto instance = GetFolder(id);
            InstanceEditViewModel model = new InstanceEditViewModel(InstanceTypes.Folder, instance);
            model.FolderTree = GetCurrentFolderTree(id);
            model.CurrentLanguage = CurrentLanguage;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formData)
        {
            FolderDto instance = GetFolder(id);
            UpdateModel(instance, formData);
            if (ModelState.IsValid)
            {
                IFacadeUpdateResult<FolderData> result = null;
                if (CurrentLanguage.Id == WebContext.Current.DefaultLanguage.Id)
                {
                    result = Service.SaveFolder(instance);
                }
                else
                {
                    result = Service.SaveFolder(instance, CurrentLanguage.Id);
                }
                if (result.IsSuccessful)
                {
                    return RedirectToAction(DetailAction, new { id = id });
                }
                else
                {
                    ProcUpdateResult(result.ValidationResult, result.Exception);
                }
            }

            InstanceEditViewModel model = new InstanceEditViewModel(InstanceTypes.Folder, instance);
            model.FolderTree = GetCurrentFolderTree(id);
            model.CurrentLanguage = CurrentLanguage;
            return View(model);
        }

        public ViewResult Detail(int id)
        {
            FolderDto instance = GetFolder(id);
            InstanceDetailViewModel model = new InstanceDetailViewModel(InstanceTypes.Folder, instance);
            model.FolderTree = GetCurrentFolderTree(id);
            model.CurrentLanguage = CurrentLanguage;
            return View(model);
        }

        private FolderDto GetFolder(int id)
        {
            FolderDto folder = null;
            if (CurrentLanguage.Id == WebContext.Current.DefaultLanguage.Id)
            {
                folder = Service.GetFolder(id, null);
            }
            else
            {
                folder = Service.GetFolder(id, CurrentLanguage.Id);
            }
            return folder;
        }
    }
}
