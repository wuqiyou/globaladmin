using Global.Data;
using Global.Web.Common.Models;
using System.Collections.Generic;

namespace Global.Web.Models
{
    public class FolderInfoViewModel : AdminBaseViewModel
    {
        public FolderInfoDto Instance { get; set; }
        public IEnumerable<ReferenceBriefDto> References { get; set; }
        public PaginationViewModel Pagination { get; set; }
    }
}