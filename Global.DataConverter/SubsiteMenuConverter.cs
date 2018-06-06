using System.Collections.Generic;
using Framework.Core;
using Global.Data;
using SubjectEngine.Data;

namespace Global.DataConverter
{
    public class SubsiteMenuConverter : IDataConverter<SubsiteMenuData, SubsiteMenuDto>
    {
        public IEnumerable<SubsiteMenuDto> Convert(IEnumerable<SubsiteMenuData> entitys)
        {
            List<SubsiteMenuDto> dtoList = new List<SubsiteMenuDto>();

            entitys.ForAll(e => dtoList.Add(Convert(e)));

            return dtoList;
        }

        public SubsiteMenuDto Convert(SubsiteMenuData entity)
        {
            SubsiteMenuDto dto = new SubsiteMenuDto();
            dto.Id = entity.Id;
            if (entity.Id != null)
            {
                dto.StringId = entity.Id.ToString();
            }
            dto.Display = entity.MenuText;
            dto.MenuText = entity.MenuText;
            dto.NavigateUrl = entity.NavigateUrl;
            dto.Tooltip = entity.Tooltip;
            dto.Sort = entity.Sort;
            dto.IsPublished = entity.IsPublished;

            if (entity.SubsiteMenuLanguages != null)
            {
                dto.SubsiteMenuLanguagesDic = new Dictionary<object, SubsiteMenuLanguageDto>();
                foreach (SubsiteMenuLanguageData item in entity.SubsiteMenuLanguages)
                {
                    SubsiteMenuLanguageDto newItem = new SubsiteMenuLanguageDto
                    {
                        LanguageId = System.Convert.ToInt32(item.LanguageId),
                        MenuText = item.MenuText
                    };
                    dto.SubsiteMenuLanguagesDic.Add(newItem.LanguageId, newItem);
                }
            }

            return dto;
        }
    }
}
