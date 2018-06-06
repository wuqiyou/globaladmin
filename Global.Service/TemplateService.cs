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
    public class TemplateService : BaseService, ITemplateService
    {
        public IEnumerable<TemplateInfoDto> GetTemplates()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                uow.BeginTransaction();
                TemplateFacade facade = new TemplateFacade(uow);
                List<TemplateInfoDto> result = facade.GetTemplatesInfo(new TemplateInfoConverter());
                uow.CommitTransaction();
                return result;
            }
        }

        public TemplateInfoDto GetTemplate(object templateId)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                uow.BeginTransaction();
                TemplateFacade facade = new TemplateFacade(uow);
                TemplateInfoDto result = facade.GetTemplateInfo(templateId, new TemplateInfoConverter());
                return result;
            }
        }

        public IFacadeUpdateResult<TemplateData> SaveTemplateCategorys(TemplateInfoDto template)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                uow.BeginTransaction();
                TemplateFacade facade = new TemplateFacade(uow);
                // TODO: implement after cms
                IFacadeUpdateResult<TemplateData> result = new FacadeUpdateResult<TemplateData>();
                return result;
            }
        }
    }
}
