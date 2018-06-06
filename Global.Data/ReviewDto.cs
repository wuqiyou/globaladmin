using Framework.Core;
using System;

namespace Global.Data
{
    public class ReviewDto : BaseDto
    {
        public object ReferenceId { get; set; }
        public decimal? Rating { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string IssuedBy { get; set; }
        public string IssuedByEmail { get; set; }
        public DateTime IssuedTime { get; set; }
        public bool IsPublished { get; set; }
    }
}
