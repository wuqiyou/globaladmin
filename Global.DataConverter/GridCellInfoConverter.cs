using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;

namespace Global.DataConverter
{
    public sealed class GridCellInfoConverter : IDataConverter<GridCellInfoData, DucValueDto>
    {
        public IEnumerable<DucValueDto> Convert(IEnumerable<GridCellInfoData> entitys)
        {
            List<DucValueDto> dtoList = new List<DucValueDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public DucValueDto Convert(GridCellInfoData entity)
        {
            DucValueDto dto = new DucValueDto();

            dto.Id = entity.Id;
            dto.DucId = entity.GridColumnId;
            dto.ValueText = entity.ValueText;
            dto.ValueInt = entity.ValueInt;
            dto.ValueDate = entity.ValueDate;
            dto.ValueUrl = entity.ValueUrl;

            return dto;
        }
    }
}
