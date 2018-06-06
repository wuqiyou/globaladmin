using Global.Data;
using System.Collections.Generic;

namespace Global.Service.Contract
{
    public interface IDataTypeService : IBaseService
    {
        IEnumerable<DataTypeDto> GetDataTypes();
    }
}
