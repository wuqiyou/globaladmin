using Framework.Core;
using Global.Core;
using Global.Data;
using Global.Service.Contract;
using Global.Web.Common;
using Global.Web.Common.Models;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;

namespace Global.Web.Models
{
    public class InstanceEditViewModel : AdminBaseViewModel
    {
        public SubjectDto Subject { get; set; }
        public virtual BaseDto Instance { get; set; }
        public List<UIAction> Actions { get; set; }

        public InstanceEditViewModel(InstanceTypes instanceType, BaseDto instance)
        {
            IsEditing = true;
            Actions = new List<UIAction>();
            InitilizeSubject(instanceType);
            Instance = instance;
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