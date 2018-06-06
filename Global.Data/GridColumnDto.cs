using Framework.Core;
using SubjectEngine.Core;

namespace Global.Data
{
    public class GridColumnDto : BaseDto
    {
        public string ColumnName { get; set; }
        public int ColumnWidth { get; set; }
        public DucTypes ColumnType { get; set; }
        public bool IsHidden { get; set; }
    }
}
