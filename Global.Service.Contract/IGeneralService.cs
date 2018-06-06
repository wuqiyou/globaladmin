using Global.Data;
using SubjectEngine.Core;
using SubjectEngine.Data;
using System.Collections.Generic;

namespace Global.Service.Contract
{
    public interface IGeneralService : IBaseService
    {
        IEnumerable<LanguageDto> GetLanguages();
        IEnumerable<LocationDto> GetPublishedLocations();
        IEnumerable<ApplicationSettingDto> GetAppSettings();
        IEnumerable<MetadataDto> GetMetadata();
        ApplicationOption GetApplicationOption();
        IEnumerable<MainMenuDto> GetMainMenus();
        IEnumerable<MainMenuDto> GetPublishedMenus();
        IEnumerable<AliasInfoDto> GetAllAliases();
        UserIdentity Authenticate(string email, string encryptedPassword);
    }
}
