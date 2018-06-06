using Framework.Component;
using Framework.Core;
using Microsoft.Practices.ServiceLocation;
using Global.Core;
using Global.Data;
using Global.DataConverter;
using Global.Service.Contract;
using Global.Web.Models;
using Global.Web.Common;
using Global.Web.Common.Helpers;
using SubjectEngine.Core;
using SubjectEngine.Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trirand.Web.Mvc;

namespace Global.Web.Controllers
{
    [Authorize]
    public class ReferenceController : AdminBaseController
    {
        public const string ControllerName = "Reference";
        public const string CreateAction = "Create";
        public const string ExplorerAction = "Explorer";
        public const string DetailAction = "Detail";
        public const string EditAction = "Edit";
        public const string EditCategoryAction = "EditCategory";
        public const string EditContentAction = "EditContent";
        public const string PublishAction = "Publish";
        public const string UnpublishAction = "Unpublish";
        public const string GetGridDataAction = "GetGridData";
        public const string EditGridRowAction = "EditGridRow";

        private IReferenceService Service { get; set; }

        public ReferenceController()
            : base(FolderType.Content)
        {
            Service = ServiceLocator.Current.GetInstance<IReferenceService>();
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

        #region Grid edit

        // This method is called when the grid requests data
        public JsonResult GetGridData(int referenceId, int jqGridID)
        {
            ReferenceInfoDto reference = GetReference(referenceId);
            GridDto grid = GetGrid(reference, jqGridID);
            List<GridRowDto> gridRows = reference.GridRows.Where(o => object.Equals(o.GridId, jqGridID)).ToList();
            return ConvertToJson(grid, gridRows);
        }

        public ActionResult EditGridRow(int referenceId, int jqGridID)
        {
            ReferenceInfoDto reference = GetReference(referenceId);
            GridDto grid = GetGrid(reference, jqGridID);
            List<GridRowDto> gridRows = reference.GridRows.Where(o => object.Equals(o.GridId, jqGridID)).ToList();
            JQGrid gridInstance = new JQGrid();
            switch (gridInstance.AjaxCallBackMode)
            {
                case AjaxCallBackMode.EditRow:
                    bool isValidEdit = ValidateInput();
                    if (isValidEdit)
                    {
                        int rowId = Convert.ToInt32(Request.Form[BaseDto.FLD_Id]);
                        GridRowDto row = gridRows.SingleOrDefault(r => r.Id.Equals(rowId));
                        foreach (GridColumnDto column in grid.Columns)
                        {
                            DucValueDto cell = row.Cells.SingleOrDefault(o => o.DucId.Equals(column.Id));
                            if (cell != null)
                            {
                                CollectValues(cell, Request.Form, column.ColumnType, reference);
                            }
                        }
                        IFacadeUpdateResult<GridRowData> result = Service.SaveGridRow(row);
                        if (result.IsSuccessful)
                        {
                            GridRowDto savedRow = result.ToDto(new GridRowConverter());
                            gridRows.Remove(row);
                            gridRows.Add(savedRow);
                        }
                    }
                    break;
                case AjaxCallBackMode.AddRow:
                    bool isValid = ValidateInput();
                    if (isValid)
                    {
                        GridRowDto newRow = new GridRowDto();
                        newRow.ReferenceId = referenceId;
                        newRow.GridId = jqGridID;
                        List<DucValueDto> cells = new List<DucValueDto>();
                        newRow.Cells = cells;
                        foreach (GridColumnDto column in grid.Columns)
                        {
                            DucValueDto cell = new DucValueDto();
                            cell.DucId = column.Id;
                            CollectValues(cell, Request.Form, column.ColumnType, reference);
                            cells.Add(cell);
                        }
                        IFacadeUpdateResult<GridRowData> result = Service.SaveGridRow(newRow);
                        if (result.IsSuccessful)
                        {
                            GridRowDto savedRow = result.ToDto(new GridRowConverter());
                            gridRows.Add(savedRow);
                        }
                    }
                    break;
                case AjaxCallBackMode.DeleteRow:
                    int deleteRowId = Convert.ToInt32(Request.Form[BaseDto.FLD_Id]);
                    bool isDeleteSuccessful = Service.DeleteGridRow(deleteRowId);
                    gridRows.Remove(gridRows.SingleOrDefault(o => o.Id.Equals(deleteRowId)));
                    break;
            }

            return ConvertToJson(grid, gridRows);
        }

        private GridDto GetGrid(ReferenceInfoDto reference, int gridId)
        {
            foreach (ZoneInfoDto zone in reference.Template.Zones)
            {
                foreach (var Subitem in zone.Block.Subitems)
                {
                    if (Subitem.Grid != null && Subitem.Grid.Id.Equals(gridId))
                    {
                        return Subitem.Grid;
                    }
                }
            }
            return null;
        }

        private JsonResult ConvertToJson(GridDto grid, List<GridRowDto> gridRows)
        {
            var result = new
            {
                page = 1,
                total = 1,
                records = gridRows.Count,
                rows = gridRows.Select(x => ConvertRow(grid, x))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private string[] ConvertRow(GridDto grid, GridRowDto row)
        {
            List<string> values = new List<string>();
            values.Add(row.Id.ToString());
            foreach (GridColumnDto column in grid.Columns)
            {
                DucValueDto ducValue = row.Cells.SingleOrDefault(o => o.DucId.Equals(column.Id));
                if (ducValue != null)
                {
                    switch (column.ColumnType)
                    {
                        case DucTypes.SubTitle:
                        case DucTypes.Text:
                        case DucTypes.TextArea:
                            values.Add(ducValue.ValueText);
                            break;
                        case DucTypes.Html:
                        case DucTypes.HtmlArea:
                            values.Add(ducValue.ValueHtml);
                            break;
                        case DucTypes.Integer:
                            values.Add(ducValue.ValueInt.HasValue ? ducValue.ValueInt.Value.ToString() : string.Empty);
                            break;
                        case DucTypes.Image:
                            values.Add(ducValue.ValueUrl);
                            values.Add(ducValue.ValueText);
                            break;
                        case DucTypes.Hyperlink:
                            values.Add(ducValue.ValueUrl);
                            values.Add(ducValue.ValueText);
                            break;
                        case DucTypes.Datetime:
                            break;
                        default:
                            break;
                    }
                }
            }
            return values.ToArray();
        }

        private bool ValidateInput()
        {
            return true;
        }

        #endregion Dynamic Grid

        public ViewResult Create(int folderId)
        {
            ReferenceCreateViewModel model = GetCreateViewModel(folderId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(int folderId, FormCollection formData)
        {
            ReferenceCreateViewModel model = GetCreateViewModel(folderId);
            UpdateModel(model.Instance, formData);
            if (ModelState.IsValid)
            {
                model.Instance.FolderId = folderId;
                int selectedTemplateId;
                if (int.TryParse(formData["SelectedTemplateId"], out selectedTemplateId))
                {
                    model.Instance.TemplateId = selectedTemplateId;
                    // Save data
                    IFacadeUpdateResult<ReferenceData> result = Service.SaveReference(model.Instance);
                    if (result.IsSuccessful)
                    {
                        ReferenceDto savedRef = result.ToDto(new ReferenceConverter());
                        return RedirectToAction(DetailAction, new { id = savedRef.Id });
                    }
                    else
                    {
                        ProcUpdateResult(result.ValidationResult, result.Exception);
                    }
                }
                else
                {
                    ModelState.AddModelError("InputError", "Please select Template.");
                }
            }

            return View(model);
        }

        public ActionResult Publish(int id, int folderId)
        {
            Service.SetPublish(id, true);
            return RedirectToAction(FolderController.ExplorerAction, FolderController.ControllerName, new { id = folderId });
        }

        public ActionResult Unpublish(int id, int folderId)
        {
            Service.SetPublish(id, false);
            return RedirectToAction(FolderController.ExplorerAction, FolderController.ControllerName, new { id = folderId });
        }

        public ViewResult Detail(int id)
        {
            ReferenceInfoDto reference = GetReference(id);
            ReferenceViewModel model = new ReferenceViewModel(reference);
            model.FolderTree = GetCurrentFolderTree(reference.FolderId);
            model.CurrentLanguage = CurrentLanguage;
            model.PageTitle = string.Format("Page Detail: {0}", model.Instance.Name);
            return View(model);
        }

        public ViewResult Edit(int id)
        {
            ReferenceEditViewModel model = GetModel(id);
            model.PageTitle = string.Format("Page Basic Edit: {0}", model.Instance.Name);
            if (model.Instance.EnableLocation)
            {
                // Get available Locations
                IGeneralService generalService = ServiceLocator.Current.GetInstance<IGeneralService>();
                model.AvailableLocations = generalService.GetPublishedLocations();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formData)
        {
            // Collect data from FormCollection
            ReferenceInfoDto reference = GetReference(id);
            UpdateModel(reference, formData);
            if (ModelState.IsValid)
            {
                if (reference.EnableLocation)
                {
                    int selectedLocationId;
                    if (int.TryParse(formData["SelectedLocationId"], out selectedLocationId))
                    {
                        reference.LocationId = selectedLocationId;
                    }
                }
                IFacadeUpdateResult<ReferenceData> result;
                if (CurrentLanguage.Id == WebContext.Current.DefaultLanguage.Id)
                {
                    result = Service.SaveReferenceBasic(reference);
                }
                else
                {
                    result = Service.SaveReferenceBasic(reference, CurrentLanguage.Id);
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
            ReferenceEditViewModel model = new ReferenceEditViewModel(reference);
            model.FolderTree = GetCurrentFolderTree(reference.FolderId);
            model.CurrentLanguage = CurrentLanguage;
            model.PageTitle = string.Format("Page Basic Edit: {0}", model.Instance.Name);
            if (model.Instance.EnableLocation)
            {
                // Get available Locations
                IGeneralService generalService = ServiceLocator.Current.GetInstance<IGeneralService>();
                model.AvailableLocations = generalService.GetPublishedLocations();
            }
            return View(model);
        }

        public ViewResult EditCategory(int id)
        {
            ReferenceEditCategoryViewModel model = GetEditCategoryViewModel(id);
            model.PageTitle = string.Format("Page Category Edit: {0}", model.Instance.Name);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCategory(int id, FormCollection formData)
        {
            ReferenceEditCategoryViewModel model = GetEditCategoryViewModel(id);
            // Validate input
            string categorysInput = formData["CategorysInput"].Trim();
            List<CategoryDto> categorys = new List<CategoryDto>();
            if (!string.IsNullOrEmpty(categorysInput))
            {
                string[] items = categorysInput.Split(',');
                foreach (string item in items)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        int itemValue;
                        if (int.TryParse(item, out itemValue))
                        {
                            categorys.Add(new CategoryDto { Id = itemValue });
                        }
                        else
                        {
                            ModelState.AddModelError("InputError", string.Format("Categorys input error: {0}", categorysInput));
                        }
                    }
                }
            }
            if (ModelState.IsValid)
            {
                model.Instance.ReferenceCategorys = categorys;
                IFacadeUpdateResult<ReferenceData> result = Service.SaveReferenceCategorys(model.Instance);
                if (result.IsSuccessful)
                {
                    return RedirectToAction(DetailAction, new { id = id });
                }
                else
                {
                    ProcUpdateResult(result.ValidationResult, result.Exception);
                }
            }
            model.PageTitle = string.Format("Page Category Edit: {0}", model.Instance.Name);
            return View(model);
        }

        public ViewResult EditContent(int id)
        {
            ReferenceEditViewModel model = GetModel(id);
            model.PageTitle = string.Format("Page Content Edit: {0}", model.Instance.Name);
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditContent(int id, FormCollection formData)
        {
            // Collect data from FormCollection
            ReferenceInfoDto reference = GetReference(id);
            if (ModelState.IsValid)
            {
                foreach (ZoneInfoDto zone in reference.Template.Zones)
                {
                    foreach (SubitemInfoDto item in zone.Block.Subitems)
                    {
                        if (item.DucType != DucTypes.Grid)
                        {
                            // Loop for each Subitem
                            DucValueDto subitemValue = null;
                            if (reference.ValuesDic.ContainsKey(item.SubitemId))
                            {
                                // Already has value for current Subitem
                                subitemValue = reference.ValuesDic[item.SubitemId];
                                CollectValues(subitemValue, formData, item.DucType, reference);
                            }
                            else
                            {
                                // No value for current Subitem, add new value
                                subitemValue = new DucValueDto();
                                subitemValue.DucId = item.SubitemId;
                                CollectValues(subitemValue, formData, item.DucType, reference);
                                bool isValid = ValidateValue(subitemValue, item.DucType);
                                if (isValid)
                                {
                                    reference.ValuesDic.Add(item.SubitemId, subitemValue);
                                }
                            }
                        }
                    }
                }

                IFacadeUpdateResult<ReferenceData> result;
                if (CurrentLanguage.Id == WebContext.Current.DefaultLanguage.Id)
                {
                    result = Service.SaveReferenceValues(reference.ReferenceId, reference.ValuesDic);
                }
                else
                {
                    result = Service.SaveReferenceValues(reference.ValuesDic, CurrentLanguage.Id);
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
            ReferenceEditViewModel model = new ReferenceEditViewModel(reference);
            model.FolderTree = GetCurrentFolderTree(reference.FolderId);
            model.CurrentLanguage = CurrentLanguage;
            model.PageTitle = string.Format("Page Content Edit: {0}", model.Instance.Name);
            return View(model);
        }

        private ReferenceEditViewModel GetModel(int referenceId)
        {
            ReferenceInfoDto reference = GetReference(referenceId);
            ReferenceEditViewModel model = new ReferenceEditViewModel(reference);
            model.FolderTree = GetCurrentFolderTree(reference.FolderId);
            model.CurrentLanguage = CurrentLanguage;
            return model;
        }

        private ReferenceInfoDto GetReference(int referenceId)
        {
            ReferenceInfoDto reference = null;
            if (CurrentLanguage.Id == WebContext.Current.DefaultLanguage.Id)
            {
                reference = Service.GetReference(referenceId, null);
            }
            else
            {
                reference = Service.GetReference(referenceId, CurrentLanguage.Id);
            }
            return reference;
        }

        private ReferenceCreateViewModel GetCreateViewModel(int folderId)
        {
            ReferenceCreateViewModel model = new ReferenceCreateViewModel();
            model.FolderTree = GetCurrentFolderTree(folderId);
            model.PageTitle = string.Format("Create New Content in folder: {0}", model.FolderTree.CurrentFolder.Name);
            model.CurrentLanguage = CurrentLanguage;
            // Get available templates
            ITemplateService templateService = ServiceLocator.Current.GetInstance<ITemplateService>();
            model.AvailableTemplates = templateService.GetTemplates();
            return model;
        }

        private ReferenceEditCategoryViewModel GetEditCategoryViewModel(int referenceId)
        {
            ReferenceInfoDto reference = GetReference(referenceId);

            ReferenceEditCategoryViewModel model = new ReferenceEditCategoryViewModel();
            model.Instance = reference;
            model.FolderTree = GetCurrentFolderTree(reference.FolderId);
            model.CurrentLanguage = CurrentLanguage;

            model.AvailableCategorys = new List<CategoryViewModel>();
            foreach (CategoryDto item in reference.Template.Categorys)
            {
                CategoryViewModel presenter = new CategoryViewModel(item);
                model.AvailableCategorys.Add(presenter);
                if (reference.ReferenceCategorys.Any(o => object.Equals(o.Id, item.Id)))
                {
                    presenter.IsSelected = true;
                }
            }

            return model;
        }

        private bool ValidateValue(DucValueDto ducValue, DucTypes ducType)
        {
            return ducValue.ValueInt.HasValue
                || ducValue.ValueDate.HasValue
                || ducValue.ValueText.TrimHasValue()
                || ducValue.ValueHtml.TrimHasValue()
                || ducValue.ValueUrl.TrimHasValue();
        }

        private void CollectValues(DucValueDto ducValue, NameValueCollection formData, DucTypes ducType, ReferenceInfoDto reference)
        {
            switch (ducType)
            {
                case DucTypes.SubTitle:
                case DucTypes.Text:
                case DucTypes.TextArea:
                    ducValue.ValueText = formData[DucHelper.GetClientId(ducValue.DucId)];
                    break;
                case DucTypes.Html:
                case DucTypes.HtmlArea:
                    ducValue.ValueHtml = formData[DucHelper.GetClientId(ducValue.DucId)];
                    break;
                case DucTypes.Image:
                    string fileId = string.Format(UIConst.FileKeyFormatString, DucHelper.GetClientId(ducValue.DucId));
                    string colTitle = string.Format(UIConst.ImageTitleKeyFormatString, DucHelper.GetClientId(ducValue.DucId));
                    string title = formData[colTitle];
                    // Deal with image upload
                    HttpPostedFileBase file = Request.Files[fileId];
                    if (null != file && file.ContentLength > 0)
                    {
                        // Save file and get result
                        FileSaveResult fileResult = FileHelper.SaveFile(title, file);
                        if (fileResult.IsSuccessful)
                        {
                            ducValue.ValueUrl = fileResult.FileUri;
                            ducValue.ValueText = fileResult.Title;
                            // Save image as Document
                            DocumentDto document = new DocumentDto();
                            document.Title = fileResult.Title;
                            document.ContentUri = fileResult.FileUri;
                            document.OriginFile = file.FileName;
                            document.OriginSource = "Reference";
                            document.IssuedDate = DateTime.Now;
                            IDocumentService service = ServiceLocator.Current.GetInstance<IDocumentService>();
                            IFacadeUpdateResult<DocumentData> result = service.SaveDocument(document);
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        string col1Name = string.Format(UIConst.ValueUrlKeyFormatString, DucHelper.GetClientId(ducValue.DucId));
                        string col2Name = string.Format(UIConst.ValueTextKeyFormatString, DucHelper.GetClientId(ducValue.DucId));
                        ducValue.ValueUrl = formData[col1Name];
                        ducValue.ValueText = formData[col2Name];
                    }
                    break;
                case DucTypes.Integer:
                    int valueInteger;
                    if (int.TryParse(formData[DucHelper.GetClientId(ducValue.DucId)], out valueInteger))
                    {
                        ducValue.ValueInt = valueInteger;
                    }
                    break;
                case DucTypes.Hyperlink:
                    string col3Name = string.Format(UIConst.ValueUrlKeyFormatString, DucHelper.GetClientId(ducValue.DucId));
                    string col4Name = string.Format(UIConst.ValueTextKeyFormatString, DucHelper.GetClientId(ducValue.DucId));
                    ducValue.ValueUrl = formData[col3Name];
                    ducValue.ValueText = formData[col4Name];
                    break;
                case DucTypes.Datetime:
                    break;
                case DucTypes.ReferenceList:
                    string col21Name = string.Format(UIConst.ValueIntKeyFormatString, DucHelper.GetClientId(ducValue.DucId));
                    string col22Name = string.Format(UIConst.ValueTextKeyFormatString, DucHelper.GetClientId(ducValue.DucId));
                    int valueInt;
                    if (int.TryParse(formData[col21Name], out valueInt))
                    {
                        ducValue.ValueInt = valueInt;
                    }
                    ducValue.ValueText = formData[col22Name];
                    break;
                case DucTypes.ReferenceCollection:
                    string col5Name = string.Format(UIConst.ValueIntKeyFormatString, DucHelper.GetClientId(ducValue.DucId));
                    int value5Int;
                    if (int.TryParse(formData[col5Name], out value5Int))
                    {
                        ducValue.ValueInt = value5Int;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
