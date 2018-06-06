using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.DataConverter
{
    public sealed class TemplateConverter : IDataConverter<TemplateData, TemplateDto>
    {
        public IEnumerable<TemplateDto> Convert(IEnumerable<TemplateData> entitys)
        {
            List<TemplateDto> dtoList = new List<TemplateDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public TemplateDto Convert(TemplateData entity)
        {
            TemplateDto dto = new TemplateDto();

            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Slug = entity.Slug;
            dto.HideTitle = entity.HideTitle;
            dto.EnableReview = entity.EnableReview;
            dto.EnableCategory = entity.EnableCategory;
            dto.EnableLocation = entity.EnableLocation;
            dto.CreatedDate = entity.CreatedDate;
            dto.ModifiedDate = entity.ModifiedDate;
            dto.RelatedContentNo = entity.RelatedContentNo;

            return dto;
        }
    }
}
