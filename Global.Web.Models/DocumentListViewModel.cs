using Global.Data;
using System.Collections.Generic;

namespace Global.Web.Models
{
    public class DocumentListViewModel : BaseDocumentViewModel
    {
        public IEnumerable<DocumentDto> Instances { get; set; }
    }
}