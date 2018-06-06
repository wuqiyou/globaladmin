using System;
using System.Collections.Generic;

namespace Global.Data
{
    public class BlockInfoDto
    {
        public object BlockId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsBuiltIn { get; set; }
        public string WidgetName { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public IEnumerable<SubitemInfoDto> Subitems { get; set; }
    }
}
