using Global.Data;
using SubjectEngine.Core;
using SubjectEngine.Data;
using System;
using System.Globalization;

namespace Global.Web.Common
{
    public class UserContext
    {
        public UserIdentity User { get; set; }
        public LanguageDto CurrentLanguage { get; set; }
        public CultureInfo CurrentCultureInfo { get; set; }

        public UserContext(UserIdentity user)
        {
            Initilize(user);
        }

        public void Initilize(UserIdentity user)
        {
            User = user;
            SetCurrentLanguage(user.LanguageId);
        }

        public void SetCurrentLanguage(object languageId)
        {
            if (languageId != null)
            {
                if (WebContext.Current.LanguageDic.ContainsKey(languageId))
                {
                    CurrentLanguage = WebContext.Current.LanguageDic[languageId];
                }
            }
            else
            {
                CurrentLanguage = WebContext.Current.LanguageDic[WebContext.Current.SiteOption.DefaultLanguageId];
            }
            CurrentCultureInfo = new CultureInfo(CurrentLanguage.Culture);
        }

        public void SetCurrentLanguage(string cultureName)
        {
            if (WebContext.Current.LanguageDicByCulture.ContainsKey(cultureName))
            {
                CurrentLanguage = WebContext.Current.LanguageDicByCulture[cultureName];
            }
            CurrentCultureInfo = new CultureInfo(CurrentLanguage.Culture);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool IsAnonymous
        {
            get { return User.DomainId == (int)UserDomains.Anonymous; }
        }

        public bool IsMember
        {
            get { return User.DomainId == (int)UserDomains.Member; }
        }

        public bool IsSuperAdmin
        {
            get { return User.DomainId == (int)UserDomains.SuperAdmin; }
        }

        public bool IsAdmin
        {
            get { return User.DomainId == (int)UserDomains.SysAdmin || User.DomainId == (int)UserDomains.SuperAdmin; }
        }

        public bool IsCustomer
        {
            get { return User.DomainId == (int)UserDomains.Customer; }
        }

        public bool IsEmployee
        {
            get { return User.DomainId == (int)UserDomains.Employee; }
        }

        public bool IsSupplierAdmin
        {
            get { return User.DomainId == (int)UserDomains.SupplierAdmin; }
        }

        public bool IsSupplier
        {
            get { return User.DomainId == (int)UserDomains.Supplier || IsSupplierAdmin; }
        }
    }
}