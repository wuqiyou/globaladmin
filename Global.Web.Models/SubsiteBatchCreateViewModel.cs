using Global.Data;
using System.Collections.Generic;
using Global.Web.Common;
using Global.Core;

namespace Global.Web.Models
{
    public class SubsiteBatchCreateViewModel : InstanceEditViewModel
    {
        public SubsiteBatchCreateViewModel(SubsiteBatchDto instance)
            : base(InstanceTypes.SubsiteBatch, instance)
        {
            PageTitle = string.Format("Create New {0}:", Subject.SubjectLabel);
            IsEditing = true;
        }
    }
}