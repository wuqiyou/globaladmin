using Framework.Core;
using System;
using System.Collections.Generic;

namespace Global.Data
{
    public class BlockDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsBuiltIn { get; set; }
        public string WidgetName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public IList<SubitemDto> Subitems { get; set; }
    }
}
