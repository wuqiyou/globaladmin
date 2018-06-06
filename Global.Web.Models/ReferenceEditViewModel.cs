using Global.Data;
using System.Collections.Generic;

namespace Global.Web.Models
{
    public class ReferenceEditViewModel : ReferenceViewModel
    {
        public IEnumerable<LocationDto> AvailableLocations { get; set; }

        public ReferenceEditViewModel(ReferenceInfoDto reference)
            : base(reference)
        {
            IsEditing = true;
        }
    }
}