using Framework.Component;
using Global.Data;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.Service.Contract
{
    public interface ITemplateService : IBaseService
    {
        IEnumerable<TemplateInfoDto> GetTemplates();
        TemplateInfoDto GetTemplate(object templateId);
        IFacadeUpdateResult<TemplateData> SaveTemplateCategorys(TemplateInfoDto template);
    }
}
