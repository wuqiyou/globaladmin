using Global.Service.Contract;

namespace Global.Service
{
    public abstract class BaseService : IBaseService
    {
        public object LanguageId { get; set; }
    }
}
