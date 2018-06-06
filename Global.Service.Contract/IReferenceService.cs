using Framework.Component;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.Service.Contract
{
    public interface IReferenceService : IBaseService
    {
        ReferenceInfoDto GetReference(object refId, object languageId);
        ReferenceInfoDto GetReference(string alias, object languageId);
        IFacadeUpdateResult<ReferenceData> SaveReference(ReferenceDto reference);
        IFacadeUpdateResult<ReferenceData> SaveReferenceBasic(ReferenceInfoDto reference);
        IFacadeUpdateResult<ReferenceData> SaveReferenceBasic(ReferenceInfoDto reference, object languageId);
        IFacadeUpdateResult<ReferenceData> SaveReferenceValues(object referenceId, Dictionary<object, DucValueDto> values);
        IFacadeUpdateResult<ReferenceData> SaveReferenceValues(Dictionary<object, DucValueDto> values, object languageId);
        IFacadeUpdateResult<ReferenceData> SaveReferenceCategorys(ReferenceInfoDto reference);
        IFacadeUpdateResult<ReferenceData> SaveReferenceCategorysInBatch(IList<ReferenceInfoDto> references);
        IFacadeUpdateResult<GridRowData> SaveGridRow(GridRowDto row);
        bool SetPublish(object refId, bool status);
        bool DeleteGridRow(int rowId);
        IEnumerable<SubjectInfoDto> GetAttachedSubjects(object refId, int subitemId, int pageIndex, int pageSize, object languageId);
        IEnumerable<SubjectInfoDto> GetSubjectsByCategory(object categoryId, int templateId, int pageIndex, int pageSize, object languageId);
        IEnumerable<SubjectInfoDto> GetSubjectsByKeyword(object keywordId, int templateId, int pageIndex, int pageSize, object languageId);
        IEnumerable<SubjectInfoDto> GetSubjectsBySearch(string term, string subjectType, int pageIndex, int pageSize, object languageId);
    }
}
