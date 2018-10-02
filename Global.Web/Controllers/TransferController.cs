using Microsoft.Practices.ServiceLocation;
using Global.Core;
using Global.Data;
using Global.Service.Contract;
using Global.Web.Models;
using Global.Web.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Framework.Component;
using SubjectEngine.Data;

namespace Global.Web.Controllers
{
    [Authorize]
    public class TransferController : AdminBaseController
    {
        public const string ControllerName = "Transfer";
        public const string IndexAction = "Index";

        private IReferenceService Service { get; set; }

        public TransferController()
        {
            Service = ServiceLocator.Current.GetInstance<IReferenceService>();
        }

        public ActionResult Index()
        {
            IFolderService folderService = ServiceLocator.Current.GetInstance<IFolderService>();
            IEnumerable<ReferenceBriefDto> items = folderService.GetReferences(CmsRegister.RecipeFolderId, 1, 6000, null);

            List<ReferenceInfoDto> instances = new List<ReferenceInfoDto>();

            // Transfer keyword to category
            foreach (ReferenceBriefDto item in items)
            {
                ReferenceInfoDto instance = Service.GetReference(item.ReferenceId, null);
                if (instance.ReferenceCategorys.Any())
                {
                    continue;
                }
                List<CategoryDto> categoryList = new List<CategoryDto>();
                foreach (ReferenceKeywordInfoDto keyword in instance.ReferenceKeywords)
                {
                    string key = keyword.KeywordSlug;
                    if (WebContext.Current.RecipeCategories.ContainsKey(key))
                    {
                        CategoryDto category = WebContext.Current.RecipeCategories[key];
                        categoryList.Add(category);
                        // As soon as find one match, exit the loop
                        break;
                    }
                }
                instance.ReferenceCategorys = categoryList;
                instances.Add(instance);
            }

            IFacadeUpdateResult<ReferenceData> result = Service.SaveReferenceCategorysInBatch(instances);

            TransferViewModel model = new TransferViewModel();
            return View(model);
        }
    }
}
