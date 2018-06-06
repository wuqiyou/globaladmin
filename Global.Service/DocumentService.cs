using Framework.Component;
using Framework.UoW;
using Global.Data;
using Global.DataConverter;
using Global.Registry;
using Global.Service.Contract;
using SubjectEngine.Component;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.Service
{
    public class DocumentService : BaseService, IDocumentService
    {
        public IEnumerable<DocumentDto> GetList(int folderId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                DocumentFacade facade = new DocumentFacade(uow);
                return facade.RetrieveAllDocument(new DocumentConverter());
            }
        }

        public DocumentDto GetDocument(int id)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                DocumentFacade facade = new DocumentFacade(uow);
                return facade.RetrieveOrNewDocument(id, new DocumentConverter());
            }
        }

        public IFacadeUpdateResult<DocumentData> SaveDocument(DocumentDto document)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                DocumentFacade facade = new DocumentFacade(uow);
                return facade.SaveDocument(DocumentConverter.ConvertToData(document));
            }
        }
    }
}
