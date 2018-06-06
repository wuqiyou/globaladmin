using Framework.Core;
using Framework.UoW;
using Global.Data;
using Global.DataConverter;
using Global.Registry;
using Global.Service.Contract;
using SubjectEngine.Component;
using SubjectEngine.Core;
using System;
using System.Collections.Generic;
using Global.Core;

namespace Global.Service
{
    public class SubjectService : BaseService, ISubjectService
    {
        public IEnumerable<SubjectDto> GetSubjects()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                SubjectFacade facade = new SubjectFacade(uow);
                IList<SubjectDto> result = facade.RetrieveAllSubject(new SubjectConverter());
                return result;
            }
        }

        public void AttachProperties(SubjectDto subjectDto)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                foreach (SubjectFieldDto field in subjectDto.SubjectFields)
                {
                    // Retrieve Pickup type ListDataSource
                    if (field.FieldDataType == DucTypes.Pickup && field.PickupEntityId != null)
                    {
                        // TODO: implement this later
                        field.ListDataSource = new List<BindingListItem>();
                        //DEntityFacade facade = new DEntityFacade(UnitOfWork);
                        //field.ListDataSource = facade.GetEntityItemList(field.PickupEntityId);
                    }
                    // Retrieve Lookup type ListDataSource
                    else if (field.FieldDataType == DucTypes.Lookup && field.LookupSubjectId != null)
                    {
                        field.ListDataSource = GetBindingList(field.LookupSubjectType, uow);
                    }
                }
            }
        }

        private IList<BindingListItem> GetBindingList(string subjectType, IUnitOfWork unitOfWork)
        {
            IList<BindingListItem> dataSource = null;

            switch ((InstanceTypes)Enum.Parse(typeof(InstanceTypes), subjectType))
            {
                case InstanceTypes.Language:
                    LanguageFacade languageFacade = new LanguageFacade(unitOfWork);
                    dataSource = languageFacade.GetBindingList();
                    break;
                case InstanceTypes.Location:
                    LocationFacade locationFacade = new LocationFacade(unitOfWork);
                    dataSource = locationFacade.GetBindingList();
                    break;
                case InstanceTypes.Folder:
                    FolderFacade folderFacade = new FolderFacade(unitOfWork);
                    dataSource = folderFacade.GetBindingList();
                    break;
                case InstanceTypes.Reference:
                    ReferenceFacade referenceFacade = new ReferenceFacade(unitOfWork);
                    dataSource = referenceFacade.GetBindingList();
                    break;
            }

            return dataSource;
        }
    }
}
