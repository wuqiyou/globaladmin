using Framework.Core;

namespace Global.Data
{
    public class ApplicationSettingDto : BaseDto
    {
        public string SettingKey { get; set; }
        public string SettingValue { get; set; }
    }
}
