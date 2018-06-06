using Framework.Core;
using SubjectEngine.Core;

namespace Global.Data
{
    public class FolderDto : BaseDto
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public object ParentId { get; set; }
        public FolderType FolderType { get; set; }
        public int Sort { get; set; }
        public bool IsSubsiteRoot { get; set; }
        public bool IsPublished { get; set; }
    }
}
