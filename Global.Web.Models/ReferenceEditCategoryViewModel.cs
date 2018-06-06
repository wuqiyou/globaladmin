using Global.Data;
using System.Collections.Generic;

namespace Global.Web.Models
{
    public class ReferenceEditCategoryViewModel : ReferenceViewModel
    {
        public List<CategoryViewModel> AvailableCategorys { get; set; }

        public ReferenceEditCategoryViewModel()
        {
            IsEditing = true;
        }
    }
}