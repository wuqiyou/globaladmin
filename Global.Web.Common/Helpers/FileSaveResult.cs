using System;

namespace Global.Web.Common.Helpers
{
    public class FileSaveResult
    {
        public string Title { get; set; }
        public string FileUri { get; set; }
        public bool IsSuccessful { get; set; }
    }
}