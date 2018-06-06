using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System.Linq;

namespace Global.DataConverter
{
    public sealed class ReferenceInfoConverter : IDataConverter<ReferenceInfoData, ReferenceInfoDto>
    {
        public object LanguageId { get; set; }

        public ReferenceInfoConverter()
        {
        }

        public ReferenceInfoConverter(object languageId)
        {
            LanguageId = languageId;
        }

        public IEnumerable<ReferenceInfoDto> Convert(IEnumerable<ReferenceInfoData> entitys)
        {
            List<ReferenceInfoDto> dtoList = new List<ReferenceInfoDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public ReferenceInfoDto Convert(ReferenceInfoData entity)
        {
            ReferenceInfoDto dto = new ReferenceInfoDto();

            dto.ReferenceId = System.Convert.ToInt32(entity.Id);
            dto.Name = entity.Name;
            dto.Slug = entity.Slug;
            dto.Title = entity.Title;
            dto.ThumbnailUrl = entity.ThumbnailUrl;
            dto.Description = entity.Description;
            dto.Keywords = entity.Keywords;
            dto.Folder = entity.Folder;
            dto.FolderId = System.Convert.ToInt32(entity.FolderId);
            dto.IsPublished = entity.IsPublished;
            dto.HideTitle = entity.HideTitle;
            dto.EnableReview = entity.EnableReview;
            dto.EnableCategory = entity.EnableCategory;
            dto.EnableLocation = entity.EnableLocation;
            dto.EnableAds = entity.EnableAds;
            dto.EnableTopAd = entity.EnableTopAd;
            dto.CreatedDate = entity.CreatedDate;
            dto.ModifiedDate = entity.ModifiedDate;
            dto.SubsiteId = entity.SubsiteId != null ? System.Convert.ToInt32(entity.SubsiteId) : default(int?);
            dto.LocationId = entity.LocationId != null ? System.Convert.ToInt32(entity.LocationId) : default(int?);
            dto.LocationName = entity.LocationName;
            // Multi-language
            if (LanguageId != null)
            {
                ReferenceLanguageInfoData item = entity.ReferenceLanguages.FirstOrDefault(o => object.Equals(o.LanguageId, LanguageId));
                if (item != null)
                {
                    dto.Title = item.Title;
                    dto.Description = item.Description;
                    dto.Keywords = item.Keywords;
                }
            }

            dto.Template = new TemplateInfoConverter().Convert(entity.Template);
            if (entity.Values != null)
            {
                dto.ValuesDic = new Dictionary<object, DucValueDto>();
                SubitemValueInfoConverter converter = new SubitemValueInfoConverter();
                converter.LanguageId = LanguageId;
                foreach (SubitemValueInfoData data in entity.Values)
                {
                    dto.ValuesDic.Add(data.SubitemId, converter.Convert(data));
                }
            }
            if (entity.GridRows != null)
            {
                dto.GridRows = new GridRowInfoConverter().Convert(entity.GridRows);
            }
            if (entity.ReferenceCategorys != null)
            {
                dto.ReferenceCategorys = new ReferenceCategoryInfoConverter().Convert(entity.ReferenceCategorys);
            }
            if (entity.ReferenceCategorys != null)
            {
                dto.ReferenceKeywords = new ReferenceKeywordInfoConverter().Convert(entity.ReferenceKeywords);
            }

            if (entity.RelatedSubjects != null)
            {
                SubjectInfoConverter converter = new SubjectInfoConverter();
                dto.RelatedSubjects = converter.Convert(entity.RelatedSubjects);
            }

            return dto;
        }

        public static ReferenceData ConvertToData(ReferenceInfoDto entity)
        {
            ReferenceData dto = new ReferenceData();
            dto.Id = entity.ReferenceId;
            dto.Name = entity.Name;
            dto.Slug = entity.Slug != null ? entity.Slug : string.Empty;
            dto.Title = entity.Title;
            dto.ThumbnailUrl = entity.ThumbnailUrl;
            dto.Description = entity.Description;
            dto.Keywords = entity.Keywords;
            dto.EnableAds = entity.EnableAds;
            dto.EnableTopAd = entity.EnableTopAd;
            dto.LocationId = entity.LocationId;

            if (entity.ReferenceCategorys != null)
            {
                dto.ReferenceCategorys = ReferenceCategoryInfoConverter.ConvertToData(entity.ReferenceCategorys);
            }

            return dto;
        }
    }
}
