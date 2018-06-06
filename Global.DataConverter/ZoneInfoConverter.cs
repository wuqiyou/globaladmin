using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.DataConverter
{
    public sealed class ZoneInfoConverter : IDataConverter<ZoneInfoData, ZoneInfoDto>
    {
        public IEnumerable<ZoneInfoDto> Convert(IEnumerable<ZoneInfoData> entitys)
        {
            List<ZoneInfoDto> dtoList = new List<ZoneInfoDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public ZoneInfoDto Convert(ZoneInfoData entity)
        {
            ZoneInfoDto dto = new ZoneInfoDto();

            dto.ZoneId = entity.Id;
            dto.Label = entity.Label;
            dto.ShowLabel = entity.ShowLabel;
            dto.Row = entity.Row;
            dto.Col = entity.Col;
            dto.Style = entity.Style;
            
            if (entity.Block != null)
            {
                dto.Block = new BlockInfoConverter().Convert(entity.Block);
            }

            return dto;
        }
    }
}
