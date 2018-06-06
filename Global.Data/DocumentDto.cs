using System;
using Framework.Core;

namespace Global.Data
{
    public class DocumentDto : BaseDto
    {
        public string Title { get; set; }
        public string ContentUri { get; set; }
        public string OriginFile { get; set; }
        public string OriginSource { get; set; }
        public int DocTypeId { get; set; }
        public object IssuedById { get; set; }
        public DateTime IssuedDate { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public int ContentLength { get; set; }
    }
}
