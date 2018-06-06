using Global.Data;
using Global.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Global.Web.Helpers
{
    public class FolderTreeBuilder
    {
        public FolderNode TreeRoot { get; set; }
        private IEnumerable<FolderInfoDto> NodeList { get; set; }
        private int? SelectedFolderId { get; set; }

        public FolderTreeBuilder(IEnumerable<FolderInfoDto> nodes, int? selectedFolderId)
        {
            NodeList = nodes;
            SelectedFolderId = selectedFolderId;
            BuildTree();
        }

        private void BuildTree()
        {
            if (NodeList != null)
            {
                FolderInfoDto rootNode = NodeList.FirstOrDefault(o => o.ParentId == null);
                if (rootNode != null)
                {
                    TreeRoot = new FolderNode(rootNode, SelectedFolderId);
                    // add first level nodes
                    foreach (FolderInfoDto item in NodeList.Where(o => object.Equals(o.ParentId, rootNode.FolderId)).OrderBy(o => o.Sort))
                    {
                        // add node
                        FolderNode node = new FolderNode(item, SelectedFolderId);
                        TreeRoot.SubNodes.Add(node);
                        // explorer next level
                        BuildSubTree(node, 1);
                    }
                }
            }
        }

        private void BuildSubTree(FolderNode node, int level)
        {
            IEnumerable<FolderInfoDto> childCats = NodeList.Where(o => object.Equals(o.ParentId, node.Id));
            if (childCats.Count<FolderInfoDto>() > 0)
            {
                foreach (FolderInfoDto item in childCats.OrderBy(o => o.Sort))
                {
                    // add node
                    FolderNode childNode = new FolderNode(item, SelectedFolderId);
                    node.SubNodes.Add(childNode);
                    // explorer next level
                    BuildSubTree(childNode, level + 1);
                }
            }
        }
    }
}