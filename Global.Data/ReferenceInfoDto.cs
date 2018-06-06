using System;
using System.Collections.Generic;

namespace Global.Data
{
    public class ReferenceInfoDto
    {
        public int ReferenceId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public bool IsPublished { get; set; }
        public bool HideTitle { get; set; }
        public bool EnableReview { get; set; }
        public bool EnableCategory { get; set; }
        public bool EnableLocation { get; set; }
        public bool EnableAds { get; set; }
        public bool EnableTopAd { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int FolderId { get; set; }
        public string Folder { get; set; }
        public int? SubsiteId { get; set; }
        public int? LocationId { get; set; }
        public string LocationName { get; set; }
        public TemplateInfoDto Template { get; set; }
        public Dictionary<object, DucValueDto> ValuesDic { get; set; }
        public IEnumerable<GridRowDto> GridRows { get; set; }
        public IEnumerable<CategoryDto> ReferenceCategorys { get; set; }
        public IEnumerable<ReferenceKeywordInfoDto> ReferenceKeywords { get; set; }
        public IEnumerable<ReviewDto> Reviews { get; set; }
        public IEnumerable<SubjectInfoDto> RelatedSubjects { get; set; }
    }
}
