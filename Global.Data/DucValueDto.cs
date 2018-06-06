using System;
using Framework.Core;
using System.Collections.Generic;

namespace Global.Data
{
    public class DucValueDto : BaseDto
    {
        public object DucId { get; set; }
        public string ValueText { get; set; }
        public string ValueHtml { get; set; }
        public int? ValueInt { get; set; }
        public DateTime? ValueDate { get; set; }
        public string ValueUrl { get; set; }
        public IList<SubjectInfoDto> AttachedSubjects { get; set; }
    }
}
