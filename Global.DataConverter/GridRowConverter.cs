using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;

namespace Global.DataConverter
{
    public sealed class GridRowConverter : IDataConverter<GridRowData, GridRowDto>
    {
        public IEnumerable<GridRowDto> Convert(IEnumerable<GridRowData> entitys)
        {
            List<GridRowDto> dtoList = new List<GridRowDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public GridRowDto Convert(GridRowData entity)
        {
            GridRowDto dto = new GridRowDto();

            dto.Id = entity.Id;
            dto.ReferenceId = entity.ReferenceId;
            dto.GridId = entity.GridId;
            dto.Sort = entity.Sort;
            if (entity.Cells != null)
            {
                dto.Cells = new GridCellConverter().Convert(entity.Cells);
            }
            return dto;
        }

        public static GridRowData ConvertToData(GridRowDto entity)
        {
            GridRowData dto = new GridRowData();
            dto.Id = entity.Id;
            dto.ReferenceId = entity.ReferenceId;
            dto.GridId = entity.GridId;
            dto.Sort = entity.Sort;
            if (entity.Cells != null)
            {
                dto.Cells = new List<GridCellData>();
                foreach (DucValueDto item in entity.Cells)
                {
                    dto.Cells.Add(GridCellConverter.ConvertToData(item));
                }
            }

            return dto;
        }
    }
}
