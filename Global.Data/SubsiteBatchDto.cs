using Framework.Core;
using System;
using System.Collections.Generic;

namespace Global.Data
{
    public class SubsiteBatchDto : BaseDto
    {
        public string NameStem { get; set; }
        public int Total { get; set; }
        public int? DefaultLanguageId { get; set; }
        public int? DefaultLocationId { get; set; }
    }
}
