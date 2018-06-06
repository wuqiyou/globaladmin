using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;

namespace Global.DataConverter
{
    public sealed class GridInfoConverter : IDataConverter<GridInfoData, GridDto>
    {
        public IEnumerable<GridDto> Convert(IEnumerable<GridInfoData> entitys)
        {
            List<GridDto> dtoList = new List<GridDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public GridDto Convert(GridInfoData entity)
        {
            GridDto dto = new GridDto();

            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.ViewMode = entity.ViewMode;

            if (entity.Columns != null)
            {
                dto.Columns = new GridColumnInfoConverter().Convert(entity.Columns);
            }

            return dto;
        }
    }
}
