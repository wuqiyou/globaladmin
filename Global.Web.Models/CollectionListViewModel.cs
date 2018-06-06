using Global.Core;

namespace Global.Web.Models
{
    public class CollectionListViewModel : AdminBaseViewModel
    {
        public InstanceListViewModel InstanceListViewModel { get; set; }

        public CollectionListViewModel()
        {
            InstanceListViewModel = new InstanceListViewModel(InstanceTypes.Collection);
            PageTitle = InstanceListViewModel.Title;
        }
    }
}