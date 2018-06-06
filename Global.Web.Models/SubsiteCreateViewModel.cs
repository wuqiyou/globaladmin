using Global.Data;
using System.Collections.Generic;
using Global.Web.Common;
using Global.Core;

namespace Global.Web.Models
{
    public class SubsiteCreateViewModel : InstanceEditViewModel
    {
        public IEnumerable<LanguageDto> AvailableLanguages { get; set; }

        public SubsiteCreateViewModel(SubsiteCreateDto instance)
            : base(InstanceTypes.SubsiteCreate, instance)
        {
            PageTitle = string.Format("Create New {0}:", Subject.SubjectLabel);
            IsEditing = true;
        }
    }
}