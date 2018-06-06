using Framework.Core;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.DataConverter
{
    public class MainMenuConverter : IDataConverter<MainMenuData, MainMenuDto>
    {
        public IEnumerable<MainMenuDto> Convert(IEnumerable<MainMenuData> entitys)
        {
            List<MainMenuDto> dtoList = new List<MainMenuDto>();

            entitys.ForAll(e => dtoList.Add(Convert(e)));

            return dtoList;
        }

        public MainMenuDto Convert(MainMenuData entity)
        {
            MainMenuDto dto = new MainMenuDto();
            dto.Id = entity.Id;
            if (entity.Id != null)
            {
                dto.StringId = entity.Id.ToString();
            }
            dto.Display = entity.Name;
            dto.Name = entity.Name;
            dto.MenuText = entity.MenuText;
            dto.Tooltip = entity.Tooltip;
            dto.NavigateUrl = entity.NavigateUrl;
            dto.Sort = entity.Sort;
            dto.ParentId = entity.ParentId;
            dto.IsPublished = entity.IsPublished;

            if (entity.MainMenuLanguages != null)
            {
                dto.MainMenuLanguagesDic = new Dictionary<object, MainMenuLanguageDto>();
                foreach (MainMenuLanguageData item in entity.MainMenuLanguages)
                {
                    MainMenuLanguageDto newItem = new MainMenuLanguageDto
                    {
                        LanguageId = item.LanguageId,
                        MenuText = item.MenuText
                    };
                    dto.MainMenuLanguagesDic.Add(newItem.LanguageId, newItem);
                }
            }

            return dto;
        }
    }
}
