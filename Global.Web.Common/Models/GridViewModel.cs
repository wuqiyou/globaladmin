using Global.Data;
using System.Collections.Generic;

namespace Global.Web.Common.Models
{
    public class GridViewModel
    {
        public object ReferenceId { get; set; }
        public LanguageDto CurrentLanguage { get; set; }
        public GridDto Grid { get; set; }
        public IEnumerable<GridRowDto> GridRows { get; set; }
    }
}