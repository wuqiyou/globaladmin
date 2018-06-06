using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;

namespace Global.DataConverter
{
    public sealed class GridColumnInfoConverter : IDataConverter<GridColumnInfoData, GridColumnDto>
    {
        public IEnumerable<GridColumnDto> Convert(IEnumerable<GridColumnInfoData> entitys)
        {
            List<GridColumnDto> dtoList = new List<GridColumnDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public GridColumnDto Convert(GridColumnInfoData entity)
        {
            GridColumnDto dto = new GridColumnDto();

            dto.Id = entity.Id;
            dto.ColumnName = entity.ColumnName;
            dto.ColumnWidth = entity.ColumnWidth;
            dto.ColumnType = entity.ColumnType;
            dto.IsHidden = entity.IsHidden;

            return dto;
        }
    }
}
