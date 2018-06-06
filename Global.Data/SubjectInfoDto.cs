using System;
using System.Collections.Generic;

namespace Global.Data
{
    public class SubjectInfoDto
    {
        public object ReferenceId { get; set; }
        public string UrlAlias { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public object MasterSubjectId { get; set; }
        public string MasterSubjectTitle { get; set; }
        public string MasterSubjectUrlAlias { get; set; }
        public int TotalCount { get; set; }
        public string SubjectType { get; set; }
    }
}
