using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;

namespace Global.DataConverter
{
    public sealed class SubsiteInfoConverter : IDataConverter<SubsiteInfoData, SubsiteInfoDto>
    {
        public IEnumerable<SubsiteInfoDto> Convert(IEnumerable<SubsiteInfoData> entitys)
        {
            List<SubsiteInfoDto> dtoList = new List<SubsiteInfoDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public SubsiteInfoDto Convert(SubsiteInfoData entity)
        {
            SubsiteInfoDto dto = new SubsiteInfoDto();

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
            dto.DefaultLanguageId = entity.DefaultLanguageId != null ? System.Convert.ToInt32(entity.DefaultLanguageId) : default(int?);
            dto.DefaultLocationId = entity.DefaultLocationId != null ? System.Convert.ToInt32(entity.DefaultLocationId) : default(int?);
            dto.SubsiteFolderId = entity.SubsiteFolder != null ? System.Convert.ToInt32(entity.SubsiteFolder.Id) : default(int?);

            if (entity.Menus != null)
            {
                dto.Menus = new SubsiteMenuConverter().Convert(entity.Menus);
            }

            if (entity.SubsiteFolder != null)
            {
                dto.SubsiteLanguagesDic = new Dictionary<object, SubsiteLanguageInfoDto>();
                foreach (FolderLanguageData item in entity.SubsiteFolder.FolderLanguages)
                {
                    SubsiteLanguageInfoDto newItem = new SubsiteLanguageInfoDto
                    {
                        LanguageId = item.LanguageId != null? System.Convert.ToInt32(item.LanguageId) : default(int),
                        Name = item.Name
                    };
                    dto.SubsiteLanguagesDic.Add(newItem.LanguageId, newItem);
                }
            }

            return dto;
        }

        public static SubsiteData ConvertToData(SubsiteInfoDto entity)
        {
            SubsiteData result = new SubsiteData();

            result.Id = entity.Id;
            result.Address = entity.Address;
            result.Phone = entity.Phone;
            result.Fax = entity.Fax;
            result.Email = entity.Email;
            result.Website = entity.Website;
            result.BackColor = entity.BackColor;
            result.TitleColor = entity.TitleColor;
            result.BannerUrl = entity.BannerUrl;
            result.IsPublished = entity.IsPublished;
            if (entity.SubsiteFolderId.HasValue)
            {
                result.SubsiteFolderId = entity.SubsiteFolderId.Value;
            }
            result.DefaultLanguageId = entity.DefaultLanguageId;
            result.DefaultLocationId = entity.DefaultLocationId;

            return result;
        }
    }
}
