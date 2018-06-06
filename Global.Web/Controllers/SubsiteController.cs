using Framework.Component;
using Global.Core;
using Global.Data;
using Global.Service.Contract;
using Global.Web.Common.Models;
using Global.Web.Models;
using Microsoft.Practices.ServiceLocation;
using SubjectEngine.Core;
using SubjectEngine.Data;
using System;
using System.Web.Mvc;

namespace Global.Web.Controllers
{
    [Authorize]
    public class SubsiteController : AdminBaseController
    {
        public const string ControllerName = "Subsite";
        public const string IndexAction = "Index";
        public const string CreateAction = "Create";
        public const string CreateBatchAction = "CreateBatch";
        public const string DetailAction = "Detail";
        public const string EditAction = "Edit";

        private ISubsiteService Service { get; set; }

        public SubsiteController()
        {
            Service = ServiceLocator.Current.GetInstance<ISubsiteService>();
        }

        public ActionResult Index()
        {
            SubsiteListViewModel model = new SubsiteListViewModel();
            model.InstanceListViewModel.Instances = Service.GetSubsites();
            model.CurrentLanguage = CurrentLanguage;
            return View(model);
        }

        public ViewResult Detail(int id)
        {
            SubsiteInfoDto instance = Service.GetSubsiteInfo(id);
            InstanceDetailViewModel model = new InstanceDetailViewModel(InstanceTypes.Subsite, instance);
            // Add action for explore subsite
            UIAction explore = new UIAction("Explore", FolderController.ControllerName, FolderController.ExplorerAction);
            explore.AddParameter(FolderController.FolderId, instance.SubsiteFolderId.ToString());
            explore.AddParameter(FolderController.SubsiteIdStateKey, instance.SubsiteFolderId.ToString());
            model.AddAction(explore);
            return View(model);
        }

        public ViewResult Edit(int id)
        {
            SubsiteInfoDto instance = Service.GetSubsiteInfo(id);
            InstanceEditViewModel model = new InstanceEditViewModel(InstanceTypes.Subsite, instance);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formData)
        {
            SubsiteInfoDto instance = Service.GetSubsiteInfo(id);
            InstanceEditViewModel model = new InstanceEditViewModel(InstanceTypes.Subsite, instance);
            UpdateModel(instance, formData);
            if (ModelState.IsValid)
            {
                IFacadeUpdateResult<SubsiteData> result = Service.SaveSubsite(instance);
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

        public ActionResult Create()
        {
            SubsiteCreateDto instance = new SubsiteCreateDto();
            SubsiteCreateViewModel model = new SubsiteCreateViewModel(instance);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FormCollection formData)
        {
            SubsiteCreateDto instance = new SubsiteCreateDto();
            SubsiteCreateViewModel model = new SubsiteCreateViewModel(instance);
            UpdateModel(instance, formData);
            if (ModelState.IsValid)
            {
                int sort = 201;
                if (!instance.DefaultLanguageId.HasValue)
                {
                    instance.DefaultLanguageId = CmsRegister.MIN_LANGUAGE_ID;
                }
                int locationId = CmsRegister.MIN_LOCATION_ID;
                if (instance.DefaultLocationId != null)
                {
                    locationId = instance.DefaultLocationId.Value;
                }
                int categoryId = CmsRegister.MAX_CATEGORY_ID;
                FolderTreeData tree = CreateFolderTreeOfSupplier(instance.Name, instance.ServiceLandingName, instance.ServiceLandingSlug, instance.EventLandingName, instance.EventLandingSlug, CmsRegister.CONTENT_FOLDER_ID, sort, categoryId, locationId, false);
                IFacadeUpdateResult<FolderData> result = Service.SaveSubsiteWhole(tree, Convert(instance));
                if (result.IsSuccessful)
                {
                    return RedirectToAction(IndexAction);
                }
                else
                {
                    ProcUpdateResult(result.ValidationResult, result.Exception);
                }
            }

            return View(model);
        }

        private SubsiteDto Convert(SubsiteCreateDto instance)
        {
            SubsiteDto result = new SubsiteDto()
            {
                Name = instance.Name,
                Address = instance.Address,
                Phone = instance.Phone,
                Fax = instance.Fax,
                Email = instance.Email,
                Website = instance.Website,
                BackColor = "#f0f0f0",
                TitleColor = "#292929",
                BannerHeight = 40,
                IsPublished = instance.IsPublished,
                DefaultLanguageId = instance.DefaultLanguageId,
                DefaultLocationId = instance.DefaultLocationId
            };

            return result;
        }

        public ActionResult CreateBatch()
        {
            SubsiteBatchDto instance = new SubsiteBatchDto();
            SubsiteBatchCreateViewModel model = new SubsiteBatchCreateViewModel(instance);
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateBatch(FormCollection formData)
        {
            SubsiteBatchDto instance = new SubsiteBatchDto();
            SubsiteBatchCreateViewModel model = new SubsiteBatchCreateViewModel(instance);
            UpdateModel(instance, formData);
            if (ModelState.IsValid)
            {
                Random randomValue = new Random();
                for (int index = 1; index <= instance.Total; index++)
                {
                    string instanceName = string.Format("{0}{1}", instance.NameStem, index);
                    int sort = 201 + index;
                    int languageId = randomValue.Next(CmsRegister.MIN_LANGUAGE_ID, CmsRegister.MAX_LANGUAGE_ID + 1);
                    int locationId = randomValue.Next(CmsRegister.MIN_LOCATION_ID, CmsRegister.MAX_LOCATION_ID + 1);
                    int categoryId = randomValue.Next(CmsRegister.MIN_CATEGORY_ID, CmsRegister.MAX_CATEGORY_ID + 1);
                    if (instance.DefaultLanguageId != null)
                    {
                        languageId = instance.DefaultLanguageId.Value;
                    }
                    if (instance.DefaultLocationId != null)
                    {
                        locationId = instance.DefaultLocationId.Value;
                    }
                    string serviceLandingName = "Service";
                    string serviceLandingSlug = "service";
                    string eventLandingName = "Event";
                    string eventLandingSlug = "event";
                    FolderTreeData tree = CreateFolderTreeOfSupplier(instanceName, serviceLandingName, serviceLandingSlug, eventLandingName, eventLandingSlug, CmsRegister.CONTENT_FOLDER_ID, sort, categoryId, locationId, true);
                    SubsiteDto subsite = CreateSubsite(instanceName, languageId, locationId);
                    IFacadeUpdateResult<FolderData> result = Service.SaveSubsiteWhole(tree, subsite);
                    if (!result.IsSuccessful)
                    {
                        ProcUpdateResult(result.ValidationResult, result.Exception);
                        break;
                    }
                }
            }

            return View(model);
        }

        private FolderTreeData CreateFolderTreeOfSupplier(string supplierName, string serviceLandingName, string serviceLandingSlug, string eventLandingName, string eventLandingSlug, int parentId, int sort, int categoryId, int locationId, bool allowLevel2References)
        {
            FolderTreeData tree = new FolderTreeData();
            // level 1 folder node
            string slug = supplierName.ToSlug();
            tree.Folder = CreateFolder(supplierName, slug, sort, parentId);
            // level 1 references
            // Home page
            ReferenceData supplier = CreateReferenceOfSupplier(supplierName, categoryId, locationId, allowLevel2References);
            tree.References.Add(supplier);
            // Service landing page
            ReferenceData serviceLanding = CreateReferenceOfServiceLanding(serviceLandingName, serviceLandingSlug);
            tree.References.Add(serviceLanding);
            // Event landing page
            ReferenceData eventLanding = CreateReferenceOfEventLanding(eventLandingName, eventLandingSlug);
            tree.References.Add(eventLanding);

            // Start to add level 2 folder nodes
            // Home folder
            FolderTreeData sub1Tree = new FolderTreeData();
            tree.SubFolders.Add(sub1Tree);
            sub1Tree.Folder = CreateFolder("Home", "", 1);
            // Service folder
            FolderTreeData sub2Tree = new FolderTreeData();
            tree.SubFolders.Add(sub2Tree);
            sub2Tree.Folder = CreateFolder("Service", serviceLandingSlug, 3);
            // Event folder
            FolderTreeData sub3Tree = new FolderTreeData();
            tree.SubFolders.Add(sub3Tree);
            sub3Tree.Folder = CreateFolder("Event", eventLandingSlug, 5);

            if (allowLevel2References)
            {
                // level 2 references
                // Service1 reference
                ReferenceData service1 = CreateReferenceOfService("Service 1", categoryId + CmsRegister.SERVICE_CATEGORY_OFFSET, locationId);
                sub2Tree.References.Add(service1);
                // Service2 reference
                ReferenceData service2 = CreateReferenceOfService("Service 2", categoryId + CmsRegister.SERVICE_CATEGORY_OFFSET, locationId);
                sub2Tree.References.Add(service2);
                // Service3 reference
                ReferenceData service3 = CreateReferenceOfService("Service 3", categoryId + CmsRegister.SERVICE_CATEGORY_OFFSET, locationId);
                sub2Tree.References.Add(service3);

                // event1 reference
                ReferenceData event1 = CreateReferenceOfEvent("Event 1", locationId);
                sub3Tree.References.Add(event1);
            }

            return tree;
        }

        private ReferenceData CreateReferenceOfSupplier(string supplierName, int categoryId, int locationId, bool allowDefaultImage = false)
        {
            ReferenceData supplier = new ReferenceData();

            supplier.Name = supplierName;
            supplier.Slug = "";
            supplier.Title = supplierName;
            supplier.TemplateId = CmsRegister.SUPPLIER_TEMPLATE_ID;
            supplier.IsPublished = true;
            supplier.EnableAds = true;
            supplier.EnableTopAd = true;
            supplier.Description = supplierName + " home page";
            supplier.IsMaster = true;
            supplier.LocationId = locationId;

            supplier.ReferenceCategorys.Add(new ReferenceCategoryData { CategoryId = categoryId });

            SubitemValueData value1 = new SubitemValueData();
            supplier.Values.Add(value1);
            value1.SubitemId = BlockRegister.SubjectDetailBlock.Title;
            value1.ValueText = supplierName + " Title";
            if (allowDefaultImage)
            {
                SubitemValueData value2 = new SubitemValueData();
                supplier.Values.Add(value2);
                value2.SubitemId = BlockRegister.SubjectDetailBlock.Image;
                value2.ValueUrl = "http://placehold.it/500x300";
            }
            SubitemValueData value3 = new SubitemValueData();
            supplier.Values.Add(value3);
            value3.SubitemId = BlockRegister.SubjectDetailBlock.Description;
            value3.ValueHtml = string.Format("<p>{0} home page content</p>", supplierName);

            return supplier;
        }

        private ReferenceData CreateReferenceOfServiceLanding(string servieLandingName, string slug)
        {
            ReferenceData serviceLanding = new ReferenceData();
            serviceLanding.Name = servieLandingName;
            serviceLanding.Slug = slug;
            //serviceLanding.Title = "Service list";
            serviceLanding.TemplateId = CmsRegister.SUBJECTLIST_TEMPLATE_ID;
            serviceLanding.IsPublished = true;
            serviceLanding.EnableAds = true;
            serviceLanding.EnableTopAd = true;
            serviceLanding.Description = servieLandingName;
            serviceLanding.IsMaster = false;

            SubitemValueData value1 = new SubitemValueData();
            serviceLanding.Values.Add(value1);
            value1.SubitemId = BlockRegister.ListViewWidget.ReferenceList;
            value1.ValueInt = CmsRegister.SERVICE_TEMPLATE_ID;

            return serviceLanding;
        }

        private ReferenceData CreateReferenceOfEventLanding(string eventLandingName, string slug)
        {
            ReferenceData eventLanding = new ReferenceData();
            eventLanding.Name = eventLandingName;
            eventLanding.Slug = slug;
            //eventLanding.Title = "Event list";
            eventLanding.TemplateId = CmsRegister.SUBJECTLIST_TEMPLATE_ID;
            eventLanding.IsPublished = true;
            eventLanding.EnableAds = true;
            eventLanding.EnableTopAd = true;
            eventLanding.Description = eventLandingName;
            eventLanding.IsMaster = false;

            SubitemValueData value1 = new SubitemValueData();
            eventLanding.Values.Add(value1);
            value1.SubitemId = BlockRegister.ListViewWidget.ReferenceList;
            value1.ValueInt = CmsRegister.EVENT_TEMPLATE_ID;

            return eventLanding;
        }

        private ReferenceData CreateReferenceOfService(string serviceName, int? categoryId, object locationId)
        {
            ReferenceData serviceData = new ReferenceData();
            serviceData.Name = serviceName;
            serviceData.Slug = serviceName.ToSlug();
            serviceData.Title = serviceName + " Title";
            serviceData.TemplateId = CmsRegister.SERVICE_TEMPLATE_ID;
            serviceData.IsPublished = true;
            serviceData.IsMaster = false;
            serviceData.EnableAds = true;
            serviceData.EnableTopAd = true;
            serviceData.Description = serviceName + " Description";
            serviceData.LocationId = locationId;

            if (categoryId != null)
            {
                serviceData.ReferenceCategorys.Add(new ReferenceCategoryData { CategoryId = categoryId });
            }

            SubitemValueData value1 = new SubitemValueData();
            serviceData.Values.Add(value1);
            value1.SubitemId = BlockRegister.SubjectDetailBlock.Title;
            value1.ValueText = serviceName + " Title";
            SubitemValueData value2 = new SubitemValueData();
            serviceData.Values.Add(value2);
            value2.SubitemId = BlockRegister.SubjectDetailBlock.Description;
            value2.ValueHtml = string.Format("<p>{0} content</p>", serviceName);

            return serviceData;
        }

        private ReferenceData CreateReferenceOfEvent(string eventName, int locationId)
        {
            ReferenceData eventData = new ReferenceData();
            eventData.Name = eventName;
            eventData.Slug = eventName.ToSlug();
            eventData.Title = eventName + " Title";
            eventData.TemplateId = CmsRegister.EVENT_TEMPLATE_ID;
            eventData.IsPublished = true;
            eventData.IsMaster = false;
            eventData.EnableAds = true;
            eventData.EnableTopAd = true;
            eventData.Description = eventName + " Description";
            eventData.LocationId = locationId;

            SubitemValueData value1 = new SubitemValueData();
            eventData.Values.Add(value1);
            value1.SubitemId = BlockRegister.SubjectDetailBlock.Title;
            value1.ValueText = eventName + " Title";
            SubitemValueData value2 = new SubitemValueData();
            eventData.Values.Add(value2);
            value2.SubitemId = BlockRegister.SubjectDetailBlock.Image;
            value2.ValueUrl = "http://placehold.it/500x300";
            SubitemValueData value3 = new SubitemValueData();
            eventData.Values.Add(value3);
            value3.SubitemId = BlockRegister.SubjectDetailBlock.Description;
            value3.ValueHtml = string.Format("<p>{0} description and content</p>", eventName);

            return eventData;
        }

        private FolderData CreateFolder(string name, string slug, int sort, int? parentId = null)
        {
            FolderData folder = new FolderData();
            folder.Name = name;
            folder.Slug = slug;
            folder.Sort = sort;
            folder.ParentId = parentId;
            folder.FolderType = FolderType.Content;
            folder.IsPublished = true;
            folder.IsSubsiteRoot = false;

            return folder;
        }

        private SubsiteDto CreateSubsite(string instanceName, int languageId, int locationId)
        {
            SubsiteDto data = new SubsiteDto();

            data.BackColor = "#f0f0f0";
            data.TitleColor = "#292929";
            data.IsPublished = true;
            data.BannerHeight = 40;
            data.DefaultLanguageId = languageId;
            data.DefaultLocationId = locationId;
            data.Address = instanceName + " address, Toronto, ON xxx xxx";
            data.Phone = "416-111-1111";
            data.Fax = "416-222-2222";
            data.Email = string.Format("{0}@{0}.com", instanceName.ToSlug());
            data.Website = string.Format("www.{0}.com", instanceName.ToSlug());

            return data;
        }
    }
}
