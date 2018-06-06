using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;
using System.Linq;

namespace Global.DataConverter
{
    public class FolderConverter : IDataConverter<FolderData, FolderDto>
    {
        public object LanguageId { get; set; }

        public FolderConverter()
        {
        }

        public FolderConverter(object languageId)
        {
            LanguageId = languageId;
        }

        public IEnumerable<FolderDto> Convert(IEnumerable<FolderData> entitys)
        {
            List<FolderDto> dtoList = new List<FolderDto>();

            entitys.ForAll(e => dtoList.Add(Convert(e)));

            return dtoList;
        }

        public FolderDto Convert(FolderData entity)
        {
            FolderDto dto = new FolderDto();
            dto.Id = entity.Id;
            dto.Display = entity.Name;
            dto.Name = entity.Name;
            dto.Slug = entity.Slug;
            dto.ParentId = entity.ParentId;
            dto.FolderType = entity.FolderType;
            dto.IsSubsiteRoot = entity.IsSubsiteRoot;
            dto.Sort = entity.Sort;
            dto.IsPublished = entity.IsPublished;
            // Multi-language
            if (LanguageId != null)
            {
                FolderLanguageData item = entity.FolderLanguages.FirstOrDefault(o => object.Equals(o.LanguageId, LanguageId));
                if (item != null)
                {
                    dto.Name = item.Name;
                }
            }

            return dto;
        }

        public static FolderData ConvertToData(FolderDto entity)
        {
            FolderData data = new FolderData();
            data.Id = entity.Id;
            data.Name = entity.Name;
            data.Slug = entity.Slug;
            data.ParentId = entity.ParentId;
            data.FolderType = entity.FolderType;
            data.IsSubsiteRoot = entity.IsSubsiteRoot;
            data.IsPublished = entity.IsPublished;
            data.Sort = entity.Sort;

            return data;
        }
    }
}
