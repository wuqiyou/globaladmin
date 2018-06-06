using Framework.Unity;
using Global.Service;
using Global.Service.Contract;
using Microsoft.Practices.Unity;

namespace Global.Web.Common
{
    public class WrapperServiceRegistry : IUnityRegistry
    {
        public void Initialize(IUnityContainer container)
        {
            container
                .RegisterType<IReviewService, ReviewService>()
                .RegisterType<IFolderService, FolderService>()
                .RegisterType<ITemplateService, TemplateService>()
                .RegisterType<IBlockService, BlockService>()
                .RegisterType<IDataTypeService, DataTypeService>()
                .RegisterType<IDocumentService, DocumentService>()
                .RegisterType<IGeneralService, GeneralService>()
                .RegisterType<ISubsiteService, SubsiteService>()
                .RegisterType<ISubjectService, SubjectService>()
                .RegisterType<ICollectionService, CollectionService>()
                .RegisterType<IReferenceService, ReferenceService>();
        }
    }
}
