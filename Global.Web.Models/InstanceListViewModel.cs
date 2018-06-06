using Framework.Core;
using Microsoft.Practices.ServiceLocation;
using Global.Core;
using Global.Data;
using Global.Service.Contract;
using Global.Web.Common;
using System.Collections.Generic;

namespace Global.Web.Models
{
    public class InstanceListViewModel
    {
        public SubjectDto Subject { get; private set; }
        public IEnumerable<BaseDto> Instances { get; set; }
        public string Title { get; set; }
        public bool AllowListAdd { get; set; }

        public InstanceListViewModel(InstanceTypes instanceType)
        {
            InitilizeSubject(instanceType);
            Title = string.Format("{0} List", Subject.SubjectLabel);
            AllowListAdd = Subject.AllowListAdd;
        }

        private void InitilizeSubject(InstanceTypes instanceType)
        {
            Subject = WebContext.Current.SubjectDicByType[instanceType.ToString()];
            ISubjectService service = ServiceLocator.Current.GetInstance<ISubjectService>();
            service.AttachProperties(Subject);
        }
    }
}