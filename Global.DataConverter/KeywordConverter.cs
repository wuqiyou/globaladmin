using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System;
using System.Collections.Generic;

namespace Global.DataConverter
{
    public class KeywordConverter : IDataConverter<KeywordData, KeywordDto>
    {
        public IEnumerable<KeywordDto> Convert(IEnumerable<KeywordData> entitys)
        {
            List<KeywordDto> dtoList = new List<KeywordDto>();

            entitys.ForAll(e => dtoList.Add(Convert(e)));

            return dtoList;
        }

        public KeywordDto Convert(KeywordData entity)
        {
            KeywordDto dto = new KeywordDto();
            dto.Id = entity.Id;
            if (entity.Id != null)
            {
                dto.StringId = entity.Id.ToString();
            }
            dto.Display = entity.Name;
            dto.Name = entity.Name;
            if (!string.IsNullOrEmpty(entity.Slug))
            {
                dto.Slug = entity.Slug;
            }
            else
            {
                dto.Slug = entity.Name.ToSlug();
            }
            dto.TemplateId = entity.TemplateId;

            return dto;
        }

        public static KeywordData ConvertToData(KeywordDto entity)
        {
            KeywordData dto = new KeywordData();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            if (!string.IsNullOrEmpty(entity.Slug))
            {
                dto.Slug = entity.Slug;
            }
            else
            {
                dto.Slug = entity.Name.ToSlug();
            }
            dto.TemplateId = entity.TemplateId;

            return dto;
        }

    }
}
