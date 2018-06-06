using Framework.Core;

namespace Global.Data
{
    public class KeywordDto : BaseDto
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public object TemplateId { get; set; }
    }
}
