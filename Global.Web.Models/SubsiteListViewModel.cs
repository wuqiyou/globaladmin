using Global.Core;

namespace Global.Web.Models
{
    public class SubsiteListViewModel : AdminBaseViewModel
    {
        public InstanceListViewModel InstanceListViewModel { get; set; }

        public SubsiteListViewModel()
        {
            InstanceListViewModel = new InstanceListViewModel(InstanceTypes.Subsite);
            PageTitle = InstanceListViewModel.Title;
        }
    }
}