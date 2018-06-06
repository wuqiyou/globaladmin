using Global.Data;

namespace Global.Web.Models
{
    public class ReferenceViewModel : AdminBaseViewModel
    {
        public ReferenceInfoDto Instance { get; set; }

        public ReferenceViewModel()
        {
        }

        public ReferenceViewModel(ReferenceInfoDto reference)
        {
            Instance = reference;
        }
    }
}