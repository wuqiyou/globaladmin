using Framework.Component;
using Global.Data;
using SubjectEngine.Core;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.Service.Contract
{
    public interface IFolderService : IBaseService
    {
        IEnumerable<FolderInfoDto> GetFolders(FolderType folderType);
        IEnumerable<ReferenceBriefDto> GetReferences(int folderId, int pageIndex, int pageSize, object languageId);
        FolderDto GetFolder(int id, object languageId);
        IFacadeUpdateResult<FolderData> SaveFolder(FolderDto instance);
        IFacadeUpdateResult<FolderData> SaveFolder(FolderDto instance, object languageId);
    }
}
