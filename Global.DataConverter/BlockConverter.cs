using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.DataConverter
{
    public sealed class BlockConverter : IDataConverter<BlockData, BlockDto>
    {
        public IEnumerable<BlockDto> Convert(IEnumerable<BlockData> entitys)
        {
            List<BlockDto> dtoList = new List<BlockDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public BlockDto Convert(BlockData entity)
        {
            BlockDto dto = new BlockDto();

            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Description = entity.Description;
            dto.IsBuiltIn = entity.IsBuiltIn;
            dto.WidgetName = entity.WidgetName;
            dto.CreatedDate = entity.CreatedDate;
            dto.ModifiedDate = entity.ModifiedDate;

            if (entity.Subitems != null)
            {
            }

            return dto;
        }
    }
}
