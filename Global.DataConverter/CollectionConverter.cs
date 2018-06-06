using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;
using System.Linq;

namespace Global.DataConverter
{
    public sealed class CollectionConverter : IDataConverter<CollectionData, CollectionDto>
    {
        public IEnumerable<CollectionDto> Convert(IEnumerable<CollectionData> entitys)
        {
            List<CollectionDto> dtoList = new List<CollectionDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public CollectionDto Convert(CollectionData entity)
        {
            CollectionDto dto = new CollectionDto();
            dto.Id = entity.Id;
            if (entity.Id != null)
            {
                dto.StringId = entity.Id.ToString();
            }
            dto.Display = entity.Name;
            dto.Name = entity.Name;
            dto.CreatedById = entity.CreatedById;
            dto.CreatedDate = entity.CreatedDate;
            dto.ModifiedDate = entity.ModifiedDate;

            dto.CollectionItems = new CollectionItemConverter().Convert(entity.CollectionItemsData.OrderBy(o => o.Sort));
            return dto;
        }

        public static CollectionData ConvertToData(CollectionDto entity)
        {
            CollectionData result = new CollectionData();

            result.Id = entity.Id;
            result.Name = entity.Name;
            result.CreatedById = entity.CreatedById;

            return result;
        }

    }
}
