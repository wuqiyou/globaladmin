using SubjectEngine.Core;
using System.Collections.Generic;
using Framework.Core;

namespace Global.Data
{
    public class GridDto : BaseDto
    {
        public string Name { get; set; }
        public ViewMode ViewMode { get; set; }
        public IEnumerable<GridColumnDto> Columns { get; set; }
    }
}
