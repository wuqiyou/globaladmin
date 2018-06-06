using Framework.Component;
using Microsoft.Practices.ServiceLocation;
using Global.Core;
using Global.Data;
using Global.Service.Contract;
using Global.Web.Models;
using SubjectEngine.Data;
using System.Web.Mvc;

namespace Global.Web.Controllers
{
    [Authorize]
    public class CollectionController : AdminBaseController
    {
        public const string ControllerName = "Collection";
        public const string IndexAction = "Index";
        public const string CreateAction = "Create";
        public const string DetailAction = "Detail";
        public const string EditAction = "Edit";

        private ICollectionService Service { get; set; }

        public CollectionController()
        {
            Service = ServiceLocator.Current.GetInstance<ICollectionService>();
        }

        public ActionResult Index()
        {
            CollectionListViewModel model = new CollectionListViewModel();
            model.InstanceListViewModel.Instances = Service.GetCollections();
            return View(model);
        }

        public ViewResult Detail(int id)
        {
            CollectionDto instance = Service.GetCollection(id);
            InstanceDetailViewModel model = new InstanceDetailViewModel(InstanceTypes.Collection, instance);
            // CollectionItem list
            InstanceChildListViewModel items = new InstanceChildListViewModel(InstanceTypes.CollectionItem);
            items.Instances = instance.CollectionItems;
            items.AllowListAdd = false;
            model.ChildLists.Add(items);
            return View(model);
        }

        public ViewResult Edit(int id)
        {
            CollectionDto instance = Service.GetCollection(id);
            InstanceEditViewModel model = new InstanceEditViewModel(InstanceTypes.Collection, instance);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formData)
        {
            CollectionDto instance = Service.GetCollection(id);
            InstanceEditViewModel model = new InstanceEditViewModel(InstanceTypes.Collection, instance);
            UpdateModel(instance, formData);
            if (ModelState.IsValid)
            {
                IFacadeUpdateResult<CollectionData> result = Service.SaveCollection(instance);
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
            CollectionDto instance = new CollectionDto();
            CollectionCreateViewModel model = new CollectionCreateViewModel(instance);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FormCollection formData)
        {
            CollectionDto instance = new CollectionDto();
            CollectionCreateViewModel model = new CollectionCreateViewModel(instance);
            UpdateModel(instance, formData);
            if (ModelState.IsValid)
            {
                IFacadeUpdateResult<CollectionData> result = Service.SaveCollection(instance);
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
    }
}
