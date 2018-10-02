using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System.Linq;

namespace Global.DataConverter
{
    public sealed class ReferenceBriefConverter : IDataConverter<ReferenceBriefData, ReferenceBriefDto>
    {
        public object LanguageId { get; set; }

        public ReferenceBriefConverter()
        {
        }

        public ReferenceBriefConverter(object languageId)
        {
            LanguageId = languageId;
        }

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

            // Multi-language
            if (LanguageId != null)
            {
                ReferenceBriefLanguageData item = entity.ReferenceLanguages.FirstOrDefault(o => object.Equals(o.LanguageId, LanguageId));
                if (item != null)
                {
                    dto.Title = item.Title;
                }
            }
            
            return dto;
        }
    }
}
