using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;

namespace Global.DataConverter
{
    public sealed class SubsiteBriefConverter : IDataConverter<SubsiteBriefData, SubsiteBriefDto>
    {
        public IEnumerable<SubsiteBriefDto> Convert(IEnumerable<SubsiteBriefData> entitys)
        {
            List<SubsiteBriefDto> dtoList = new List<SubsiteBriefDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public SubsiteBriefDto Convert(SubsiteBriefData entity)
        {
            SubsiteBriefDto dto = new SubsiteBriefDto();

            dto.Id = entity.Id;
            dto.StringId = entity.Id.ToString();
            dto.Display = entity.Name;
            dto.SubsiteId = (int)entity.Id;

            dto.Name = entity.Name;
            dto.Address = entity.Address;
            dto.Phone = entity.Phone;
            dto.Fax = entity.Fax;
            dto.Email = entity.Email;
            dto.Website = entity.Website;
            dto.Slug = entity.Slug;
            dto.Culture = entity.Culture;
            dto.BackColor = entity.BackColor;
            dto.TitleColor = entity.TitleColor;
            dto.BannerUrl = entity.BannerUrl;
            dto.IsPublished = entity.IsPublished;
            dto.SubsiteFolderId = entity.SubsiteFolderId != null ? System.Convert.ToInt32(entity.SubsiteFolderId) : default(int?);
            dto.DefaultLanguageId = entity.DefaultLanguageId != null ? System.Convert.ToInt32(entity.DefaultLanguageId) : default(int?);
            dto.DefaultLocationId = entity.DefaultLocationId != null ? System.Convert.ToInt32(entity.DefaultLocationId) : default(int?);

            return dto;
        }
    }
}
