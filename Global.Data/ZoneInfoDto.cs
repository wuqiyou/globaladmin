using System.Collections.Generic;

namespace Global.Data
{
    public class ZoneInfoDto
    {
        public object ZoneId { get; set; }
        public string Label { get; set; }
        public bool ShowLabel { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public string Style { get; set; }
        public BlockInfoDto Block { get; set; }
    }
}
