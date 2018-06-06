using Framework.Component;
using Microsoft.Practices.ServiceLocation;
using Global.Data;
using Global.Service.Contract;
using Global.Web.Models;
using SubjectEngine.Core;
using SubjectEngine.Data;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Global.Web.Controllers
{
    [Authorize]
    public class TemplateController : AdminBaseController
    {
        public const string ControllerName = "Template";
        public const string IndexAction = "Index";
        public const string CreateAction = "Create";
        public const string DetailAction = "Detail";
        public const string EditAction = "Edit";
        public const string EditCategoryAction = "EditCategory";
        public const string EditLayoutAction = "EditLayout";

        private ITemplateService Service { get; set; }

        public TemplateController()
            : base(FolderType.Setting)
        {
            Service = ServiceLocator.Current.GetInstance<ITemplateService>();
        }

        public ViewResult Index()
        {
            TemplateListViewModel model = new TemplateListViewModel();
            model.FolderTree = GetCurrentFolderTree();
            model.Instances = Service.GetTemplates();
            return View(model);
        }

        public ViewResult Detail(int id)
        {
            TemplateDetailViewModel model = new TemplateDetailViewModel();
            model.FolderTree = GetCurrentFolderTree();
            model.Instance = Service.GetTemplate(id);
            return View(model);
        }

        public ViewResult Edit(int id)
        {
            TemplateEditViewModel model = GetModel(id);
            return View(model);
        }

        public ViewResult EditCategory(int id)
        {
            TemplateEditViewModel model = GetModel(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCategory(int id, FormCollection formData)
        {
            TemplateEditViewModel model = GetModel(id);
            // Validate input
            string CategorysInput = formData["CategorysInput"].Trim();
            List<CategoryDto> categorys = new List<CategoryDto>();
            if (!string.IsNullOrEmpty(CategorysInput))
            {
                string[] items = CategorysInput.Split(',');
                foreach (string item in items)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        categorys.Add(new CategoryDto { CategoryText = item });
                    }
                }
            }
            if (ModelState.IsValid)
            {
                model.Instance.Categorys = categorys;
                IFacadeUpdateResult<TemplateData> result = Service.SaveTemplateCategorys(model.Instance);
                if (result.IsSuccessful)
                {
                    return RedirectToAction(DetailAction, new { id = id });
                }
                else
                {
                    ProcUpdateResult(result.ValidationResult, result.Exception);
                }
            }
            return View(model);
        }

        public ViewResult EditLayout(int id)
        {
            TemplateEditViewModel model = GetModel(id);
            return View(model);
        }

        private TemplateEditViewModel GetModel(int templateId)
        {
            TemplateEditViewModel model = new TemplateEditViewModel();
            model.FolderTree = GetCurrentFolderTree();
            model.Instance = Service.GetTemplate(templateId);
            return model;
        }
    }
}
