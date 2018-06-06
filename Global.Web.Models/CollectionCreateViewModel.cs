using Global.Core;
using Global.Data;

namespace Global.Web.Models
{
    public class CollectionCreateViewModel : InstanceEditViewModel
    {
        public CollectionCreateViewModel(CollectionDto instance)
            : base(InstanceTypes.Collection, instance)
        {
            PageTitle = string.Format("Create New {0}:", Subject.SubjectLabel);
            IsEditing = true;
        }
    }
}