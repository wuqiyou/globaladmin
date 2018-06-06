using System.Collections.Generic;
using SubjectEngine.Core;

namespace Global.Data
{
    public class FolderInfoDto
    {
        public int FolderId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string FullName { get; set; }
        public string FullSlug { get; set; }
        public int? ParentId { get; set; }
        public FolderType FolderType { get; set; }
        public int Sort { get; set; }
        public bool IsSubsiteRoot { get; set; }
        public bool IsPublished { get; set; }
    }
}
