using Framework.Core;
using System;

namespace Global.Data
{
    public class ReferenceDto : BaseDto
    {
        public object FolderId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public object TemplateId { get; set; }
        public object LocationId { get; set; }
        public object CreatedById { get; set; }
        public bool IsPublished { get; set; }
        public bool IsMaster { get; set; }
        public bool EnableAds { get; set; }
        public bool EnableTopAd { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
