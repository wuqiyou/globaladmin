using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;

namespace Global.DataConverter
{
    public class MetadataConverter : IDataConverter<MetadataData, MetadataDto>
    {
        public IEnumerable<MetadataDto> Convert(IEnumerable<MetadataData> entitys)
        {
            List<MetadataDto> dtoList = new List<MetadataDto>();

            entitys.ForAll(e => dtoList.Add(Convert(e)));

            return dtoList;
        }

        public MetadataDto Convert(MetadataData entity)
        {
            MetadataDto dto = new MetadataDto();
            dto.MetadataId = entity.Id;
            dto.MetaKey = entity.MetaKey;
            dto.MetaType = entity.MetaType;
            dto.MetaContent = entity.MetaContent;

            return dto;
        }
    }
}
