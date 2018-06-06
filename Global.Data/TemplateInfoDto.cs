using System;
using System.Collections.Generic;

namespace Global.Data
{
    public class TemplateInfoDto
    {
        public object TemplateId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public bool HideTitle { get; set; }
        public bool EnableReview { get; set; }
        public bool EnableCategory { get; set; }
        public bool EnableLocation { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int RelatedContentNo { get; set; }
        public IEnumerable<ZoneInfoDto> Zones { get; set; }
        public IEnumerable<CategoryDto> Categorys { get; set; }
        public IEnumerable<KeywordDto> Keywords { get; set; }
    }
}
