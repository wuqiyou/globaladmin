using System.Collections.Generic;
using Framework.Core;

namespace Global.Data
{
    public class MainMenuDto : BaseDto
    {
        public string Name { get; set; }
        public string MenuText { get; set; }
        public string Tooltip { get; set; }
        public string NavigateUrl { get; set; }
        public int Sort { get; set; }
        public object ParentId { get; set; }
        public bool IsPublished { get; set; }
        public IEnumerable<MainMenuDto> SubMenus { get; set; }
        public Dictionary<object, MainMenuLanguageDto> MainMenuLanguagesDic { get; set; }
    }
}
