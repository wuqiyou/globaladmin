using System;

namespace Global.Data
{
    public class DocumentInfoDto
    {
        public int DocumentId { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public string ContentUri { get; set; }
        public int DocTypeId { get; set; }
        public object IssuedById { get; set; }
        public DateTime IssuedDate { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public int ContentLength { get; set; }
    }
}
