using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;

namespace Global.DataConverter
{
    public sealed class ReferenceBriefConverter : IDataConverter<ReferenceBriefData, ReferenceBriefDto>
    {
        public IEnumerable<ReferenceBriefDto> Convert(IEnumerable<ReferenceBriefData> entitys)
        {
            List<ReferenceBriefDto> dtoList = new List<ReferenceBriefDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public ReferenceBriefDto Convert(ReferenceBriefData entity)
        {
            ReferenceBriefDto dto = new ReferenceBriefDto();

            dto.ReferenceId = entity.Id;
            dto.Name = entity.Name;
            dto.Title = entity.Title;
            dto.Slug = entity.Slug;
            dto.UrlAlias = entity.UrlAlias;
            dto.IsPublished = entity.IsPublished;
            dto.CreatedDate = entity.CreatedDate;
            dto.ModifiedDate = entity.ModifiedDate;
            dto.CreatedById = entity.CreatedById;
            dto.Template = entity.Template;
            dto.LocationName = entity.LocationName;
            dto.TotalCount = entity.TotalCount;
            return dto;
        }
    }
}
