using System.Collections.Generic;
using Framework.Core;
using SubjectEngine.Core;

namespace Global.Data
{
    public class SubjectFieldDto : BaseDto
    {
        public string FieldKey { get; set; }
        public string FieldLabel { get; set; }
        public string HelpText { get; set; }
        public DucTypes FieldDataType { get; set; }
        public int? PickupEntityId { get; set; }
        public int? LookupSubjectId { get; set; }
        public bool IsRequired { get; set; }
        public bool IsReadonly { get; set; }
        public bool IsShowInGrid { get; set; }
        public bool IsLinkInGrid { get; set; }
        public int Sort { get; set; }
        public int RowIndex { get; set; }
        public int ColIndex { get; set; }
        public int? MaxLength { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        public string NavigateUrlFormatString { get; set; }
        public IEnumerable<BindingListItem> ListDataSource { get; set; }
        public string LookupSubjectManageUrlFormatString { get; set; }
        public string LookupSubjectType { get; set; }
    }
}
