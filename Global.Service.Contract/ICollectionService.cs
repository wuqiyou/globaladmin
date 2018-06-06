using Framework.Component;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.Service.Contract
{
    public interface ICollectionService : IBaseService
    {
        IEnumerable<CollectionDto> GetCollections();
        CollectionDto GetCollection(int id);
        IFacadeUpdateResult<CollectionData> SaveCollection(CollectionDto instance);
    }
}
