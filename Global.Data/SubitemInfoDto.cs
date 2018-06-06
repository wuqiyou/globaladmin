using System;
using SubjectEngine.Core;

namespace Global.Data
{
    public class SubitemInfoDto
    {
        public object SubitemId { get; set; }
        public string ItemKey { get; set; }
        public string ItemLabel { get; set; }
        public string DefaultValue { get; set; }
        public bool IsMetaProvider { get; set; }
        public DucTypes DucType { get; set; }
        public GridDto Grid { get; set; }

        public string Label
        {
            get
            {
                string mark = IsMetaProvider ? "*" : string.Empty;
                string defaultValue = string.IsNullOrEmpty(DefaultValue) ? string.Empty : ",DV=" + DefaultValue;
                return string.Format("Subitem({0}): {1} ({2}){3}{4}", SubitemId, ItemLabel, DucType.ToString(), mark, defaultValue);
            }
        }
    }
}
