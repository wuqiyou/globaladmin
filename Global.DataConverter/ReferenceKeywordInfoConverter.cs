using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System;
using System.Collections.Generic;

namespace Global.DataConverter
{
    public sealed class ReferenceKeywordInfoConverter : IDataConverter<ReferenceKeywordInfo, ReferenceKeywordInfoDto>
    {
        public IEnumerable<ReferenceKeywordInfoDto> Convert(IEnumerable<ReferenceKeywordInfo> entitys)
        {
            List<ReferenceKeywordInfoDto> dtoList = new List<ReferenceKeywordInfoDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public ReferenceKeywordInfoDto Convert(ReferenceKeywordInfo entity)
        {
            ReferenceKeywordInfoDto dto = new ReferenceKeywordInfoDto();

            dto.Id = entity.Id;
            dto.KeywordId = entity.KeywordId;
            dto.KeywordName = entity.KeywordName;
            dto.KeywordSlug = string.IsNullOrEmpty(entity.KeywordSlug) ? entity.KeywordName.ToSlug() : entity.KeywordSlug;
            dto.Sort = entity.Sort;

            return dto;
        }
    }
}
