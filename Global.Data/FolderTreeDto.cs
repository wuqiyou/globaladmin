using Framework.Core;
using SubjectEngine.Core;
using System.Collections.Generic;

namespace Global.Data
{
    public class FolderTreeDto : BaseDto
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public object ParentId { get; set; }
        public FolderType FolderType { get; set; }
        public int Sort { get; set; }
        public bool IsSubsiteRoot { get; set; }
        public bool IsPublished { get; set; }

        public IList<ReferenceDto> References { get; set; }
        public IList<FolderTreeDto> SubFolders { get; set; }
        public IList<FolderLanguageDto> FolderLanguages { get; set; }
    }
}
