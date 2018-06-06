using Framework.Core;
using SubjectEngine.Core;

namespace Global.Data
{
    public class SubitemDto : BaseDto
    {
        public string ItemKey { get; set; }
        public string ItemLabel { get; set; }
        public string DefaultValue { get; set; }
        public bool IsMetaProvider { get; set; }
        public int DataTypeId { get; set; }
        public object GridId { get; set; }
    }
}
