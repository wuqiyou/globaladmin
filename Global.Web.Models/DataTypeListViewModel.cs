using Global.Data;
using System.Collections.Generic;

namespace Global.Web.Models
{
    public class DataTypeListViewModel : AdminBaseViewModel
    {
        public IEnumerable<DataTypeDto> Instances { get; set; }
    }
}