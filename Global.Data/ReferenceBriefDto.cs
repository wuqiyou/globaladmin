using System;
namespace Global.Data
{
    public class ReferenceBriefDto
    {
        public object ReferenceId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string UrlAlias { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int? CreatedById { get; set; }
        public string Template { get; set; }
        public string LocationName { get; set; }
        public int TotalCount { get; set; }
    }
}
