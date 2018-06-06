using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;

namespace Global.DataConverter
{
    public sealed class ReferenceCategoryInfoConverter : IDataConverter<ReferenceCategoryInfoData, CategoryDto>
    {
        public IEnumerable<CategoryDto> Convert(IEnumerable<ReferenceCategoryInfoData> entitys)
        {
            List<CategoryDto> dtoList = new List<CategoryDto>();
            entitys.ForAll(e => dtoList.Add(Convert(e)));
            return dtoList;
        }

        public CategoryDto Convert(ReferenceCategoryInfoData entity)
        {
            CategoryDto dto = new CategoryDto();

            dto.Id = entity.Category.Id;
            dto.CategoryText = entity.Category.CategoryText;
            dto.Slug = entity.Category.Slug;
            dto.TemplateId = entity.Category.TemplateId;

            return dto;
        }

        public static List<ReferenceCategoryData> ConvertToData(IEnumerable<CategoryDto> referenceCategorys)
        {
            List<ReferenceCategoryData> result = new List<ReferenceCategoryData>();
            foreach (CategoryDto item in referenceCategorys)
            {
                result.Add(ReferenceCategoryInfoConverter.ConvertToData(item));
            }
            return result;
        }

        public static ReferenceCategoryData ConvertToData(CategoryDto entity)
        {
            ReferenceCategoryData dto = new ReferenceCategoryData();
            dto.CategoryId = entity.Id;

            return dto;
        }
    }
}
