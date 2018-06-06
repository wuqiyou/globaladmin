using Framework.Component;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.Service.Contract
{
    public interface IDocumentService : IBaseService
    {
        IEnumerable<DocumentDto> GetList(int folderId);
        DocumentDto GetDocument(int id);
        IFacadeUpdateResult<DocumentData> SaveDocument(DocumentDto document);
    }
}
