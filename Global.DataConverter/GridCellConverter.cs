using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;

namespace Global.DataConverter
{
    public sealed class GridCellConverter : IDataConverter<GridCellData, DucValueDto>
    {
        public IEnumerable<DucValueDto> Convert(IEnumerable<GridCellData> entitys)
        {
            List<DucValueDto> dtoList = new List<DucValueDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public DucValueDto Convert(GridCellData entity)
        {
            DucValueDto dto = new DucValueDto();

            dto.Id = entity.Id;
            dto.DucId = entity.GridColumnId;
            dto.ValueText = entity.ValueText;
            dto.ValueHtml = entity.ValueHtml;
            dto.ValueInt = entity.ValueInt;
            dto.ValueDate = entity.ValueDate;
            dto.ValueUrl = entity.ValueUrl;

            return dto;
        }

        public static GridCellData ConvertToData(DucValueDto entity)
        {
            GridCellData dto = new GridCellData();
            dto.Id = entity.Id;
            dto.GridColumnId = entity.DucId;
            dto.ValueText = entity.ValueText;
            dto.ValueHtml = entity.ValueHtml;
            dto.ValueInt = entity.ValueInt;
            dto.ValueDate = entity.ValueDate;
            dto.ValueUrl = entity.ValueUrl;

            return dto;
        }
    }
}
