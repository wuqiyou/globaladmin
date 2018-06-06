using Framework.Core;

namespace Global.Data
{
    public class CollectionItemDto : BaseDto
    {
        public object ReferenceId { get; set; }
        public int Sort { get; set; }
    }
}
