using System.Collections.Generic;

namespace Global.Data
{
    public class SearchResultDto
    {
        public int RecordsPerPage { get; set; }
        public int TotalRecords { get; set; }
        public IList<SubjectInfoDto> Records { get; set; }
    }
}
