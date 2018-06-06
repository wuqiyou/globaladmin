using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;
using System.Linq;

namespace Global.DataConverter
{
    public class FolderInfoConverter : IDataConverter<FolderInfoData, FolderInfoDto>
    {
        public object LanguageId { get; set; }

        public FolderInfoConverter()
        {
        }

        public FolderInfoConverter(object languageId)
        {
            LanguageId = languageId;
        }

        public IEnumerable<FolderInfoDto> Convert(IEnumerable<FolderInfoData> entitys)
        {
            List<FolderInfoDto> dtoList = new List<FolderInfoDto>();

            entitys.ForAll(e => dtoList.Add(Convert(e)));

            return dtoList;
        }

        public FolderInfoDto Convert(FolderInfoData entity)
        {
            FolderInfoDto dto = new FolderInfoDto();
            dto.FolderId = (int)entity.Id;
            dto.Name = entity.Name;
            dto.Slug = entity.Slug;
            dto.ParentId = entity.ParentId != null ? System.Convert.ToInt32(entity.ParentId) : default(int?);
            dto.FolderType = entity.FolderType;
            dto.FullName = entity.FullName;
            dto.FullSlug = entity.FullSlug;
            dto.IsSubsiteRoot = entity.IsSubsiteRoot;
            dto.Sort = entity.Sort;
            dto.IsPublished = entity.IsPublished;
            // Multi-language
            if (LanguageId != null)
            {
                FolderLanguageInfoData item = entity.FolderLanguages.FirstOrDefault(o => object.Equals(o.LanguageId, LanguageId));
                if (item != null)
                {
                    dto.Name = item.Name;
                }
            }

            return dto;
        }
    }
}
