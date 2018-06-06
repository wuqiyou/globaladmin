using Global.Data;
using System.Collections.Generic;

namespace Global.Web.Models
{
    public class BlockListViewModel : AdminBaseViewModel
    {
        public IEnumerable<BlockInfoDto> Instances { get; set; }
    }
}