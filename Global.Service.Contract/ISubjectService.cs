using System.Collections.Generic;
using Global.Data;

namespace Global.Service.Contract
{
    public interface ISubjectService : IBaseService
    {
        IEnumerable<SubjectDto> GetSubjects();
        void AttachProperties(SubjectDto subjectDto);
    }
}
