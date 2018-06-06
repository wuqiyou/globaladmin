using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.DataConverter
{
    public sealed class CollectionItemConverter : IDataConverter<CollectionItemData, CollectionItemDto>
    {
        public IEnumerable<CollectionItemDto> Convert(IEnumerable<CollectionItemData> entitys)
        {
            List<CollectionItemDto> dtoList = new List<CollectionItemDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public CollectionItemDto Convert(CollectionItemData entity)
        {
            CollectionItemDto dto = new CollectionItemDto();
            dto.Id = entity.Id;
            if (entity.Id != null)
            {
                dto.StringId = entity.Id.ToString();
            }
            dto.ReferenceId = entity.ReferenceId;
            dto.Sort = entity.Sort;
            return dto;
        }
    }
}
