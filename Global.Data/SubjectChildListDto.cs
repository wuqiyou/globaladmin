using Framework.Core;

namespace Global.Data
{
    public class SubjectChildListDto : BaseDto
    {
        public object ChildListSubjectId { get; set; }
        public string Title { get; set; }
        public bool AllowAdd { get; set; }
        public bool AllowEdit { get; set; }
        public bool AllowDelete { get; set; }
        public int Sort { get; set; }

        public SubjectDto ChildListSubject { get; set; }
    }
}
