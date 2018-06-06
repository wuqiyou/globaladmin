using Global.Data;

namespace Global.Web.Models
{
    public class FolderTreeViewModel
    {
        public FolderNode TreeRoot { get; set; }
        public FolderInfoDto CurrentFolder { get; set; }
    }
}