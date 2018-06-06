using System.Collections.Generic;
using Framework.Core;

namespace Global.Data
{
    public class SubsiteMenuDto : BaseDto
    {
        public string MenuText { get; set; }
        public string NavigateUrl { get; set; }
        public string Tooltip { get; set; }
        public int Sort { get; set; }
        public bool IsPublished { get; set; }
        public Dictionary<object, SubsiteMenuLanguageDto> SubsiteMenuLanguagesDic { get; set; }
    }
}
