using System.Collections.Generic;
using Framework.Core;

namespace Global.Data
{
    public class LocationDto : BaseDto
    {
        public string Name { get; set; }
        public string LocationSlug { get; set; }
        public bool IsPublished { get; set; }
        public Dictionary<object, LocationLanguageDto> LocationLanguagesDic { get; set; }
    }
}
