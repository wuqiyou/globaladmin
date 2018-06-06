using Global.Data;
using SubjectEngine.Core;
using System.Collections.Generic;

namespace Global.Web.Models
{
    public class FolderNode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public bool IsSubsiteRoot { get; set; }
        public bool IsSelected { get; set; }
        public List<FolderNode> SubNodes { get; set; }

        public FolderNode(FolderInfoDto folderInfo, int? selectedFolderId)
        {
            Id = folderInfo.FolderId;
            Name = folderInfo.Name;
            FullName = folderInfo.FullName;
            IsSubsiteRoot = folderInfo.IsSubsiteRoot;
            if (selectedFolderId.HasValue && selectedFolderId.Value == Id)
            {
                IsSelected = true;
            }

            switch (folderInfo.FolderType)
            {
                case FolderType.Content:
                    Controller = "Folder";
                    Action = "Explorer";
                    break;
                case FolderType.Document:
                    Controller = "Document";
                    Action = "Explorer";
                    break;
                case FolderType.Setting:
                    Controller = "Setting";
                    Action = folderInfo.Name;
                    break;
            }

            SubNodes = new List<FolderNode>();
        }
    }
}