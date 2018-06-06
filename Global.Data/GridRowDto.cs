using System.Collections.Generic;
using Framework.Core;

namespace Global.Data
{
    public class GridRowDto : BaseDto
    {
        public object ReferenceId { get; set; }
        public object GridId { get; set; }
        public int? Sort { get; set; }
        public IEnumerable<DucValueDto> Cells { get; set; }
    }
}
