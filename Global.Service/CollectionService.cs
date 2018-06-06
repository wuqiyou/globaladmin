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
    public class CollectionService : BaseService, ICollectionService
    {
        public IEnumerable<CollectionDto> GetCollections()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                CollectionFacade facade = new CollectionFacade(uow);
                List<CollectionDto> result = facade.RetrieveAllCollection(new CollectionConverter());
                return result;
            }
        }

        public CollectionDto GetCollection(int id)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                CollectionFacade facade = new CollectionFacade(uow);
                CollectionDto result = facade.RetrieveOrNewCollection(id, new CollectionConverter());
                return result;
            }
        }

        public IFacadeUpdateResult<CollectionData> SaveCollection(CollectionDto instance)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                CollectionFacade facade = new CollectionFacade(uow);
                IFacadeUpdateResult<CollectionData> result = facade.SaveCollection(CollectionConverter.ConvertToData(instance));
                return result;
            }
        }
    }
}
