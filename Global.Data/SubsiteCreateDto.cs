using Framework.Core;

namespace Global.Data
{
    public class SubsiteCreateDto : BaseDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public int? DefaultLanguageId { get; set; }
        public int? DefaultLocationId { get; set; }
        public string ServiceLandingName { get; set; }
        public string ServiceLandingSlug { get; set; }
        public string EventLandingName { get; set; }
        public string EventLandingSlug { get; set; }
        public bool IsPublished { get; set; }
    }
}
