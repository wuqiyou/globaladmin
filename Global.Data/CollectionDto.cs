using System.Collections.Generic;
using Framework.Core;
using System;

namespace Global.Data
{
    public class CollectionDto : BaseDto
    {
        public string Name { get; set; }
        public object CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public IEnumerable<CollectionItemDto> CollectionItems { get; set; }
    }
}
