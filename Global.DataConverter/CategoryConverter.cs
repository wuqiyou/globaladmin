using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System;

namespace Global.DataConverter
{
    public sealed class CategoryConverter : IDataConverter<CategoryData, CategoryDto>
    {
        public IEnumerable<CategoryDto> Convert(IEnumerable<CategoryData> entitys)
        {
            List<CategoryDto> dtoList = new List<CategoryDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public CategoryDto Convert(CategoryData entity)
        {
            CategoryDto dto = new CategoryDto();

            dto.Id = entity.Id;
            dto.CategoryText = entity.CategoryText;
            dto.Slug = entity.Slug;
            dto.TemplateId = entity.TemplateId;

            return dto;
        }

        public static CategoryData ConvertToData(CategoryDto entity)
        {
            CategoryData dto = new CategoryData();
            dto.Id = entity.Id;
            dto.CategoryText = entity.CategoryText;
            if (!string.IsNullOrEmpty(entity.Slug))
            {
                dto.Slug = entity.Slug;
            }
            else
            {
                dto.Slug = entity.CategoryText.ToSlug();
            }
            dto.TemplateId = entity.TemplateId;

            return dto;
        }
    }
}
