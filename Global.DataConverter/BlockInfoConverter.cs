using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.DataConverter
{
    public sealed class BlockInfoConverter : IDataConverter<BlockInfoData, BlockInfoDto>
    {
        public IEnumerable<BlockInfoDto> Convert(IEnumerable<BlockInfoData> entitys)
        {
            List<BlockInfoDto> dtoList = new List<BlockInfoDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public BlockInfoDto Convert(BlockInfoData entity)
        {
            BlockInfoDto dto = new BlockInfoDto();

            dto.BlockId = entity.Id;
            dto.Name = entity.Name;
            dto.Description = entity.Description;
            dto.IsBuiltIn = entity.IsBuiltIn;
            dto.WidgetName = entity.WidgetName;
            dto.CreatedDate = entity.CreatedDate;
            dto.ModifiedDate = entity.ModifiedDate;

            if (entity.Subitems != null)
            {
                dto.Subitems = new SubitemInfoConverter().Convert(entity.Subitems);
            }

            return dto;
        }
    }
}
