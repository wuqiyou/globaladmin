using Framework.Component;
using Framework.UoW;
using Global.Data;
using Global.DataConverter;
using Global.Registry;
using Global.Service.Contract;
using SubjectEngine.Component;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.Service
{
    public class SubsiteService : BaseService, ISubsiteService
    {
        public IEnumerable<SubsiteBriefDto> GetSubsites(bool isPublished = false)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                SubsiteFacade facade = new SubsiteFacade(uow);
                List<SubsiteBriefDto> result = facade.GetSubsites(new SubsiteBriefConverter(), isPublished);
                return result;
            }
        }

        public SubsiteInfoDto GetSubsiteInfo(object instanceId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                SubsiteFacade facade = new SubsiteFacade(uow);
                SubsiteInfoDto result = facade.GetSubsiteInfo(instanceId, new SubsiteInfoConverter());
                return result;
            }
        }

        public IFacadeUpdateResult<FolderData> SaveSubsiteWhole(FolderTreeData folderTree, SubsiteDto subsite)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                SubsiteBatchFacade facade = new SubsiteBatchFacade(uow);
                return facade.SaveSubsiteBatch(folderTree, SubsiteConverter.ConvertToData(subsite));
            }
        }

        public IFacadeUpdateResult<SubsiteData> SaveSubsite(SubsiteInfoDto instance)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                SubsiteFacade facade = new SubsiteFacade(uow);
                IFacadeUpdateResult<SubsiteData> result = facade.SaveSubsite(SubsiteInfoConverter.ConvertToData(instance));
                return result;
            }
        }

        public IEnumerable<ReferenceBriefDto> GetReferences(int folderId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceInfoFacade facade = new ReferenceInfoFacade(uow);
                List<ReferenceBriefDto> folderList = facade.GetList(folderId, 1, 10, new ReferenceBriefConverter());
                return folderList;
            }
        }
    }
}
