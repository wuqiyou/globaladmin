using Framework.UoW;
using Global.Data;
using Global.DataConverter;
using Global.Registry;
using Global.Service.Contract;
using SubjectEngine.Component;
using SubjectEngine.Core;
using SubjectEngine.Data;
using System.Collections.Generic;
using System.Linq;

namespace Global.Service
{
    public class GeneralService : BaseService, IGeneralService
    {
        public IEnumerable<LanguageDto> GetLanguages()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                LanguageFacade languageFacade = new LanguageFacade(uow);
                IEnumerable<LanguageDto> result = languageFacade.RetrieveAllLanguage(new LanguageConverter());
                return result;
            }
        }

        public IEnumerable<LocationDto> GetPublishedLocations()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                LocationFacade facade = new LocationFacade(uow);
                List<LocationDto> items = facade.GetPublishedLocations(new LocationConverter());
                return items;
            }
        }

        public IEnumerable<ApplicationSettingDto> GetAppSettings()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ApplicationSettingFacade facade = new ApplicationSettingFacade(uow);
                IEnumerable<ApplicationSettingDto> result = facade.RetrieveAllApplicationSetting(new ApplicationSettingConverter());
                return result;
            }
        }

        public IEnumerable<MetadataDto> GetMetadata()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                MetadataFacade facade = new MetadataFacade(uow);
                IEnumerable<MetadataDto> result = facade.RetrieveAll(new MetadataConverter());
                return result.Where(x => !string.IsNullOrEmpty(x.MetaContent));
            }
        }

        public ApplicationOption GetApplicationOption()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                ApplicationSettingFacade settingFacade = new ApplicationSettingFacade(uow);
                ApplicationOption result = settingFacade.GetApplicationOption();
                return result;
            }
        }

        public IEnumerable<MainMenuDto> GetMainMenus()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                MainMenuFacade facade = new MainMenuFacade(uow);
                List<MainMenuDto> items = facade.RetrieveAllMainMenu(new MainMenuConverter());

                return BuildMenuTrees(items);
            }
        }

        private IEnumerable<MainMenuDto> BuildMenuTrees(IEnumerable<MainMenuDto> items)
        {
            IEnumerable<MainMenuDto> topItems = items.Where(o => o.ParentId == null).OrderBy(o => o.Sort);
            IEnumerable<MainMenuDto> Subitems = items.Where(o => o.ParentId != null);
            // Loop to get sub menus
            foreach (MainMenuDto item in topItems)
            {
                item.SubMenus = Subitems.Where(o => object.Equals(o.ParentId, item.Id)).OrderBy(o => o.Sort);
            }

            return topItems;
        }

        public IEnumerable<MainMenuDto> GetPublishedMenus()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                MainMenuFacade facade = new MainMenuFacade(uow);
                List<MainMenuDto> items = facade.GetPublishedMenus(new MainMenuConverter());

                return BuildMenuTrees(items);
            }
        }

        public IEnumerable<AliasInfoDto> GetAllAliases()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                AliasInfoFacade facade = new AliasInfoFacade(uow);
                return facade.GetAllAliases(new AliasInfoConverter());
            }
        }

        public UserIdentity Authenticate(string email, string encryptedPassword)
        {
            UserIdentity authenticatedUser = null;
            using (IUnitOfWork uow = UnitOfWorkFactory.Instance.Start(DataStoreResolver.CMSDataStoreKey))
            {
                AuthenticateFacade facade = new AuthenticateFacade(uow);
                authenticatedUser = facade.Authenticate(email, encryptedPassword);
            }

            return authenticatedUser;
        }
    }
}
