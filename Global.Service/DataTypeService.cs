using Framework.UoW;
using Global.Data;
using Global.DataConverter;
using Global.Registry;
using Global.Service.Contract;
using SubjectEngine.Component;
using System.Collections.Generic;

namespace Global.Service
{
    public class DataTypeService : BaseService, IDataTypeService
    {
        public IEnumerable<DataTypeDto> GetDataTypes()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                uow.BeginTransaction();
                DataTypeFacade facade = new DataTypeFacade(uow);
                List<DataTypeDto> result = facade.RetrieveAll(new DataTypeConverter());
                uow.CommitTransaction();
                return result;
            }
        }
    }
}
