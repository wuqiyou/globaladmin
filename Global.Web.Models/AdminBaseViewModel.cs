using Global.Data;

namespace Global.Web.Models
{
    public class AdminBaseViewModel
    {
        public string PageTitle { get; set; }
        public LanguageDto CurrentLanguage { get; set; }
        public bool IsEditing { get; set; }
        public FolderTreeViewModel FolderTree { get; set; }
    }
}