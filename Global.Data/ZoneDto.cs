using Framework.Core;

namespace Global.Data
{
    public class ZoneDto : BaseDto
    {
        public int TemplateId { get; set; }
        public string Label { get; set; }
        public bool ShowLabel { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public BlockDto Block { get; set; }
    }
}
