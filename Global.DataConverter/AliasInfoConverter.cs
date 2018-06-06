using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.DataConverter
{
    public class AliasInfoConverter : IDataConverter<AliasInfoData, AliasInfoDto>
    {
        public IEnumerable<AliasInfoDto> Convert(IEnumerable<AliasInfoData> entitys)
        {
            List<AliasInfoDto> dtoList = new List<AliasInfoDto>();

            entitys.ForAll(e => dtoList.Add(Convert(e)));

            return dtoList;
        }

        public AliasInfoDto Convert(AliasInfoData entity)
        {
            AliasInfoDto dto = new AliasInfoDto();
            dto.UrlAlias = entity.UrlAlias;
            dto.ReferenceId = entity.ReferenceId;
            dto.Name = entity.Name;
            dto.Folder = entity.Folder;
            dto.Template = entity.Template;
            return dto;
        }
    }
}
