using Framework.Component;
using Framework.UoW;
using Global.Data;
using Global.DataConverter;
using Global.Registry;
using Global.Service.Contract;
using SubjectEngine.Component;
using SubjectEngine.Core;
using SubjectEngine.Data;
using System.Collections.Generic;
using System.Linq;

namespace Global.Service
{
    public class FolderService : BaseService, IFolderService
    {
        public IEnumerable<FolderInfoDto> GetFolders(FolderType folderType)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                FolderFacade facade = new FolderFacade(uow);
                List<FolderInfoDto> folderList = facade.GetFolders(folderType, new FolderInfoConverter());
                return folderList.OrderBy(o => o.Sort);
            }
        }

        public IEnumerable<ReferenceBriefDto> GetReferences(int folderId, int pageIndex, int pageSize)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceInfoFacade facade = new ReferenceInfoFacade(uow);
                List<ReferenceBriefDto> dtoList = facade.GetList(folderId, pageIndex, pageSize, new ReferenceBriefConverter());
                return dtoList;
            }
        }

        public IEnumerable<FolderInfoDto> GetSubsiteRootFolders(FolderType folderType)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                FolderFacade facade = new FolderFacade(uow);
                List<FolderInfoDto> folderList = facade.GetSubsiteRootFolders(new FolderInfoConverter());
                return folderList;
            }
        }

        public FolderDto GetFolder(int id, object languageId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                FolderFacade facade = new FolderFacade(uow);
                return facade.RetrieveOrNewFolder(id, new FolderConverter(languageId));
            }
        }

        public IFacadeUpdateResult<FolderData> SaveFolder(FolderDto instance)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                FolderFacade facade = new FolderFacade(uow);
                IFacadeUpdateResult<FolderData> result = facade.SaveFolder(FolderConverter.ConvertToData(instance));
                return result;
            }
        }

        public IFacadeUpdateResult<FolderData> SaveFolder(FolderDto instance, object languageId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                FolderFacade facade = new FolderFacade(uow);
                IFacadeUpdateResult<FolderData> result = facade.SaveFolderLanguage(FolderConverter.ConvertToData(instance), languageId);
                return result;
            }
        }
    }
}
