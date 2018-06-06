using Framework.Component;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.Service.Contract
{
    public interface ISubsiteService : IBaseService
    {
        IEnumerable<SubsiteBriefDto> GetSubsites(bool isPublished = false);
        SubsiteInfoDto GetSubsiteInfo(object instanceId);
        IFacadeUpdateResult<FolderData> SaveSubsiteWhole(FolderTreeData folderTree, SubsiteDto subsite);
        IFacadeUpdateResult<SubsiteData> SaveSubsite(SubsiteInfoDto instance);
        IEnumerable<ReferenceBriefDto> GetReferences(int folderId);
    }
}
