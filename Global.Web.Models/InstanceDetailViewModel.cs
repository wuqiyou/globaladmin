using Framework.Core;
using Microsoft.Practices.ServiceLocation;
using Global.Core;
using Global.Data;
using Global.Service.Contract;
using Global.Web.Common;
using Global.Web.Common.Models;
using System.Collections.Generic;

namespace Global.Web.Models
{
    public class InstanceDetailViewModel : AdminBaseViewModel
    {
        public SubjectDto Subject { get; set; }
        public virtual BaseDto Instance { get; set; }
        public List<UIAction> Actions { get; set; }
        public List<InstanceChildListViewModel> ChildLists { get; set; }

        public InstanceDetailViewModel(InstanceTypes instanceType, BaseDto instance)
        {
            InitilizeSubject(instanceType);
            Instance = instance;
            Actions = new List<UIAction>();
            ChildLists = new List<InstanceChildListViewModel>();
            PageTitle = string.Format("{0}: {1}", Subject.SubjectLabel, Instance.Display);
        }

        public void AddAction(UIAction action)
        {
            Actions.Add(action);
        }

        private void InitilizeSubject(InstanceTypes instanceType)
        {
            Subject = WebContext.Current.SubjectDicByType[instanceType.ToString()];
            ISubjectService service = ServiceLocator.Current.GetInstance<ISubjectService>();
            service.AttachProperties(Subject);
        }
    }
}