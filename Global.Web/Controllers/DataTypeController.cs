using Microsoft.Practices.ServiceLocation;
using Global.Service.Contract;
using Global.Web.Models;
using SubjectEngine.Core;
using System.Web.Mvc;

namespace Global.Web.Controllers
{
    [Authorize]
    public class DataTypeController : AdminBaseController
    {
        public const string ControllerName = "DataType";
        public const string IndexAction = "Index";

        private IDataTypeService Service { get; set; }

        public DataTypeController()
            : base(FolderType.Setting)
        {
            Service = ServiceLocator.Current.GetInstance<IDataTypeService>();
        }

        public ViewResult Index()
        {
            DataTypeListViewModel model = new DataTypeListViewModel();
            model.FolderTree = GetCurrentFolderTree(null);
            model.Instances = Service.GetDataTypes();
            return View(model);
        }
    }
}
