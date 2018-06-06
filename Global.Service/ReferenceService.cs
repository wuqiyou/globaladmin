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
    public class ReferenceService : BaseService, IReferenceService
    {
        public IFacadeUpdateResult<ReferenceData> SaveReference(ReferenceDto reference)
        {
            ReferenceData data = ReferenceConverter.ConvertToData(reference);
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceFacade facade = new ReferenceFacade(uow);
                IFacadeUpdateResult<ReferenceData> result = facade.SaveReference(data);
                return result;
            }
        }

        public IFacadeUpdateResult<ReferenceData> SaveReferenceBasic(ReferenceInfoDto reference)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceFacade facade = new ReferenceFacade(uow);
                IFacadeUpdateResult<ReferenceData> result = facade.SaveReferenceBasic(ReferenceInfoConverter.ConvertToData(reference));
                return result;
            }
        }

        public IFacadeUpdateResult<ReferenceData> SaveReferenceBasic(ReferenceInfoDto reference, object languageId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceFacade facade = new ReferenceFacade(uow);
                IFacadeUpdateResult<ReferenceData> result = facade.SaveReferenceLanguageBasic(ReferenceInfoConverter.ConvertToData(reference), languageId);
                return result;
            }
        }

        public IFacadeUpdateResult<ReferenceData> SaveReferenceValues(object referenceId, Dictionary<object, DucValueDto> values)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceFacade facade = new ReferenceFacade(uow);
                IFacadeUpdateResult<ReferenceData> result = facade.SaveReferenceValues(referenceId, SubitemValueInfoConverter.ConvertToData(values));
                return result;
            }
        }

        public IFacadeUpdateResult<ReferenceData> SaveReferenceValues(Dictionary<object, DucValueDto> values, object languageId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceFacade facade = new ReferenceFacade(uow);
                IFacadeUpdateResult<ReferenceData> result = facade.SaveReferenceValueLanguages(SubitemValueInfoConverter.ConvertToData(values), languageId);
                return result;
            }
        }

        public IFacadeUpdateResult<ReferenceData> SaveReferenceCategorys(ReferenceInfoDto reference)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceFacade facade = new ReferenceFacade(uow);
                IFacadeUpdateResult<ReferenceData> result = facade.SaveReferenceCategorys(reference.ReferenceId, ReferenceCategoryInfoConverter.ConvertToData(reference.ReferenceCategorys));
                return result;
            }
        }

        public IFacadeUpdateResult<ReferenceData> SaveReferenceCategorysInBatch(IList<ReferenceInfoDto> references)
        {
            // Convert to data
            List<ReferenceData> instances = new List<ReferenceData>();
            foreach (ReferenceInfoDto item in references)
            {
                ReferenceData instance = new ReferenceData();
                instances.Add(instance);
                instance.Id = item.ReferenceId;
                instance.ReferenceCategorys = ReferenceCategoryInfoConverter.ConvertToData(item.ReferenceCategorys);
            }
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceFacade facade = new ReferenceFacade(uow);
                IFacadeUpdateResult<ReferenceData> result = facade.SaveReferenceCategorysInBatch(instances);
                return result;
            }
        }

        public IFacadeUpdateResult<GridRowData> SaveGridRow(GridRowDto row)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceFacade facade = new ReferenceFacade(uow);
                IFacadeUpdateResult<GridRowData> result = facade.SaveGridRow(GridRowConverter.ConvertToData(row));
                return result;
            }
        }

        public bool DeleteGridRow(int rowId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceFacade facade = new ReferenceFacade(uow);
            }
            return true;
        }

        public ReferenceInfoDto GetReference(object refId, object languageId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceInfoFacade facade = new ReferenceInfoFacade(uow);
                ReferenceInfoDto detail = facade.GetReferenceInfo(refId, new ReferenceInfoConverter(languageId));
                return detail;
            }
        }

        public ReferenceInfoDto GetReference(string alias, object languageId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceInfoFacade facade = new ReferenceInfoFacade(uow);
                ReferenceInfoDto detail = facade.GetReferenceInfo(alias, null, languageId, new ReferenceInfoConverter(languageId));
                return detail;
            }
        }

        public bool SetPublish(object refId, bool status)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceFacade facade = new ReferenceFacade(uow);
                return facade.SetPublish(refId, status);
            }
        }

        public IEnumerable<SubjectInfoDto> GetAttachedSubjects(object refId, int subitemId, int pageIndex, int pageSize, object languageId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceInfoFacade facade = new ReferenceInfoFacade(uow);
                List<SubjectInfoDto> dtoList = facade.GetAttachedSubjects(refId, subitemId, pageIndex, pageSize, null, languageId, new SubjectInfoConverter());
                return dtoList;
            }
        }

        public IEnumerable<SubjectInfoDto> GetSubjectsByCategory(object categoryId, int templateId, int pageIndex, int pageSize, object languageId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceInfoFacade facade = new ReferenceInfoFacade(uow);
                List<SubjectInfoDto> dtoList = facade.GetSubjectsByCategory(categoryId, templateId, pageIndex, pageSize, languageId, new SubjectInfoConverter());
                return dtoList;
            }
        }

        public IEnumerable<SubjectInfoDto> GetSubjectsByKeyword(object keywordId, int templateId, int pageIndex, int pageSize, object languageId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceInfoFacade facade = new ReferenceInfoFacade(uow);
                List<SubjectInfoDto> dtoList = facade.GetSubjectsByKeyword(keywordId, templateId, pageIndex, pageSize, languageId, new SubjectInfoConverter());
                return dtoList;
            }
        }

        public IEnumerable<SubjectInfoDto> GetSubjectsBySearch(string key, string subjectType, int pageIndex, int pageSize, object languageId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ReferenceInfoFacade facade = new ReferenceInfoFacade(uow);
                List<SubjectInfoDto> dtoList = new List<SubjectInfoDto>();
                return dtoList;
            }
        }
    }
}
