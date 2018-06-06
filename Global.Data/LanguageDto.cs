using System.Collections.Generic;
using Framework.Core;

namespace Global.Data
{
    public class LanguageDto : BaseDto
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Culture { get; set; }
        public bool IsPublished { get; set; }
    }
}
