using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.DataConverter
{
    public sealed class TemplateInfoConverter : IDataConverter<TemplateInfoData, TemplateInfoDto>
    {
        public IEnumerable<TemplateInfoDto> Convert(IEnumerable<TemplateInfoData> entitys)
        {
            List<TemplateInfoDto> dtoList = new List<TemplateInfoDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public TemplateInfoDto Convert(TemplateInfoData entity)
        {
            TemplateInfoDto dto = new TemplateInfoDto();

            dto.TemplateId = entity.Id;
            dto.Name = entity.Name;
            dto.Slug = entity.Slug;
            dto.HideTitle = entity.HideTitle;
            dto.EnableReview = entity.EnableReview;
            dto.EnableCategory = entity.EnableCategory;
            dto.EnableLocation = entity.EnableLocation;
            dto.CreatedDate = entity.CreatedDate;
            dto.ModifiedDate = entity.ModifiedDate;
            dto.RelatedContentNo = entity.RelatedContentNo;

            if (entity.Zones != null)
            {
                dto.Zones = new ZoneInfoConverter().Convert(entity.Zones);
            }

            if (entity.Categorys != null)
            {
                dto.Categorys = new CategoryConverter().Convert(entity.Categorys);
            }
            if (entity.Keywords != null)
            {
                dto.Keywords = new KeywordConverter().Convert(entity.Keywords);
            }
            return dto;
        }
    }
}
