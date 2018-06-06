using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;

namespace Global.DataConverter
{
    public sealed class ReferenceConverter : IDataConverter<ReferenceData, ReferenceDto>
    {
        public IEnumerable<ReferenceDto> Convert(IEnumerable<ReferenceData> entitys)
        {
            List<ReferenceDto> dtoList = new List<ReferenceDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public ReferenceDto Convert(ReferenceData entity)
        {
            ReferenceDto dto = new ReferenceDto();
            dto.Id = entity.Id;
            if (entity.Id != null)
            {
                dto.StringId = entity.Id.ToString();
            }
            dto.Name = entity.Name;
            dto.Title = entity.Title;
            dto.ThumbnailUrl = entity.ThumbnailUrl;
            dto.Slug = entity.Slug;
            dto.Description = entity.Description;
            dto.Keywords = entity.Keywords;
            dto.TemplateId = entity.TemplateId;
            dto.LocationId = entity.LocationId;
            dto.FolderId = entity.FolderId;
            dto.IsPublished = entity.IsPublished;
            dto.IsMaster = entity.IsMaster;
            dto.EnableAds = entity.EnableAds;
            dto.EnableTopAd = entity.EnableTopAd;
            dto.CreatedDate = entity.CreatedDate;
            dto.ModifiedDate = entity.ModifiedDate;

            return dto;
        }

        public static ReferenceData ConvertToData(ReferenceDto entity)
        {
            ReferenceData data = new ReferenceData();
            data.Id = entity.Id;
            data.Name = entity.Name;
            data.Title = entity.Title;
            data.ThumbnailUrl = entity.ThumbnailUrl;
            data.Slug = entity.Slug != null ? entity.Slug : string.Empty;
            data.Description = entity.Description;
            data.Keywords = entity.Keywords;
            data.TemplateId = entity.TemplateId;
            data.LocationId = entity.LocationId;
            data.FolderId = entity.FolderId;
            data.IsPublished = entity.IsPublished;
            data.IsMaster = entity.IsMaster;
            data.EnableAds = entity.EnableAds;
            data.EnableTopAd = entity.EnableTopAd;
            data.CreatedDate = entity.CreatedDate;

            return data;
        }
    }
}
