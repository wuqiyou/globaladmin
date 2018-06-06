using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;

namespace Global.DataConverter
{
    public class DataTypeConverter : IDataConverter<DataTypeData, DataTypeDto>
    {
        public IEnumerable<DataTypeDto> Convert(IEnumerable<DataTypeData> entitys)
        {
            List<DataTypeDto> dtoList = new List<DataTypeDto>();

            entitys.ForAll(e => dtoList.Add(Convert(e)));

            return dtoList;
        }

        public DataTypeDto Convert(DataTypeData entity)
        {
            DataTypeDto dto = new DataTypeDto();
            dto.Id = entity.Id;
            if (entity.Id != null)
            {
                dto.StringId = entity.Id.ToString();
            }
            dto.Display = entity.Name;
            dto.Name = entity.Name;
            dto.Description = entity.Description;
            dto.DucType = entity.DucType;

            return dto;
        }
    }
}
