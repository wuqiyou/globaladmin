using Framework.Component;
using Microsoft.Practices.ServiceLocation;
using Global.Data;
using Global.DataConverter;
using Global.Service.Contract;
using Global.Web.Models;
using Global.Web.Common.Helpers;
using SubjectEngine.Core;
using SubjectEngine.Data;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Global.Web.Controllers
{
    [Authorize]
    public class DocumentController : AdminBaseController
    {
        public const string ControllerName = "Document";
        public const string IndexAction = "Index";
        public const string CreateAction = "Create";
        public const string ExplorerAction = "Explorer";
        public const string DetailAction = "Detail";
        public const string EditAction = "Edit";
        public const string DocumentListAction = "DocumentList";

        private IDocumentService Service { get; set; }

        public DocumentController()
            : base(FolderType.Document)
        {
            Service = ServiceLocator.Current.GetInstance<IDocumentService>();
        }

        public ActionResult Index()
        {
            BaseDocumentViewModel model = new BaseDocumentViewModel();
            model.FolderTree = GetCurrentFolderTree();
            return View(model);
        }

        public PartialViewResult DocumentList()
        {
            IEnumerable<DocumentDto> instances = Service.GetList(1);
            return PartialView(instances);
        }

        public ViewResult Explorer(int id)
        {
            DocumentListViewModel model = new DocumentListViewModel();
            model.FolderTree = GetCurrentFolderTree(id);
            model.Instances = Service.GetList(id);
            return View(model);
        }

        public ActionResult Create(int folderId)
        {
            DocumentViewModel model = GetModel(null);
            model.FolderTree = GetCurrentFolderTree(folderId);

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(int folderId, FormCollection formData)
        {
            DocumentViewModel model = GetModel(null);
            UpdateModel(model.Instance, formData);

            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files[0];
                // Deal with file data
                if (null != file && file.ContentLength > 0)
                {
                    FileSaveResult fileResult = FileHelper.SaveFile(model.Instance.Title, file);
                    if (fileResult.IsSuccessful)
                    {
                        model.Instance.Title = fileResult.Title;
                        model.Instance.OriginFile = file.FileName;
                        model.Instance.ContentUri = fileResult.FileUri;
                        model.Instance.OriginSource = "Document";
                        model.Instance.IssuedDate = DateTime.Now;

                        // Save data
                        IFacadeUpdateResult<DocumentData> result = Service.SaveDocument(model.Instance);
                        if (result.IsSuccessful)
                        {
                            DocumentDto savedRef = result.ToDto(new DocumentConverter());
                            return RedirectToAction(DetailAction, new { id = savedRef.Id });
                        }
                        else
                        {
                            ProcUpdateResult(result.ValidationResult, result.Exception);
                        }
                    }
                    else
                    {
                        // TODO: file save exception
                    }
                }
            }

            model.FolderTree = GetCurrentFolderTree(folderId);
            return View(model);
        }

        public ViewResult Detail(int id)
        {
            DocumentViewModel model = GetModel(id);
            model.FolderTree = GetCurrentFolderTree();
            return View(model);
        }

        public ViewResult Edit(int id)
        {
            DocumentViewModel model = GetModel(id);
            model.FolderTree = GetCurrentFolderTree();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formData)
        {
            DocumentViewModel model = GetModel(id);
            // Collect data from FormCollection
            UpdateModel(model.Instance, formData);

            if (ModelState.IsValid)
            {
                // Save data
                IFacadeUpdateResult<DocumentData> result = Service.SaveDocument(model.Instance);
                if (result.IsSuccessful)
                {
                    DocumentDto savedRef = result.ToDto(new DocumentConverter());
                    return RedirectToAction(DetailAction, new { id = savedRef.Id });
                }
                else
                {
                    ProcUpdateResult(result.ValidationResult, result.Exception);
                }
            }
            model.FolderTree = GetCurrentFolderTree();
            return View(model);
        }

        private DocumentViewModel GetModel(int? instanceId)
        {
            DocumentViewModel model = new DocumentViewModel();
            if (instanceId.HasValue)
            {
                model.Instance = Service.GetDocument(instanceId.Value);
            }
            else
            {
                model.Instance = new DocumentDto();
            }
            return model;
        }
    }
}
