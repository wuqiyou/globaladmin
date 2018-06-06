using Framework.Core;
using System;
using System.Collections.Generic;

namespace Global.Data
{
    public class TemplateDto : BaseDto
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public bool HideTitle { get; set; }
        public bool EnableReview { get; set; }
        public bool EnableCategory { get; set; }
        public bool EnableLocation { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int RelatedContentNo { get; set; }

        public IEnumerable<ZoneDto> Zones { get; set; }
    }
}
