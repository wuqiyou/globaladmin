using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;

namespace Global.DataConverter
{
    public sealed class SubsiteConverter : IDataConverter<SubsiteData, SubsiteDto>
    {
        public IEnumerable<SubsiteDto> Convert(IEnumerable<SubsiteData> entitys)
        {
            List<SubsiteDto> dtoList = new List<SubsiteDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public SubsiteDto Convert(SubsiteData entity)
        {
            SubsiteDto result = new SubsiteDto();

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
            result.SubsiteFolderId = entity.SubsiteFolderId != null ? System.Convert.ToInt32(entity.SubsiteFolderId) : default(int?);
            result.DefaultLanguageId = entity.DefaultLanguageId != null ? System.Convert.ToInt32(entity.DefaultLanguageId) : default(int?);
            result.DefaultLocationId = entity.DefaultLocationId != null ? System.Convert.ToInt32(entity.DefaultLocationId) : default(int?);

            return result;
        }

        public static SubsiteData ConvertToData(SubsiteDto entity)
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
            result.SubsiteFolderId = entity.SubsiteFolderId;
            result.DefaultLanguageId = entity.DefaultLanguageId;
            result.DefaultLocationId = entity.DefaultLocationId;

            return result;
        }
    }
}
