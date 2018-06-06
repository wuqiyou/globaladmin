using Global.Data;
using Global.Web.Common;
using Global.Web.Common.Helpers;
using System.Collections.Generic;
using System.Text;

namespace System.Web.Mvc
{
    public static class HtmlHelperExtension
    {
        public static string FullImageUrl(this HtmlHelper htmlHelper, string url)
        {
            url = string.Format("{0}/{1}/{2}", WebContext.Current.SiteOption.Name, WebContext.Current.SiteOption.ImageServeRoot, url.TrimStart('/'));
            return url;
        }

        public static string LocalizeHrefFromAdmin(this HtmlHelper htmlHelper, string href)
        {
            if (WebContext.Current.SiteOption.IsMultiLanguageSupported)
            {
                return string.Format("{0}/{1}/{2}", WebContext.Current.SiteOption.Name, WebContext.Current.DefaultLanguage.Culture, href);
            }
            else
            {
                return string.Format("{0}/{1}", WebContext.Current.SiteOption.Name, href);
            }
        }

        public static string LocalizeAdminHref(this HtmlHelper htmlHelper, string href)
        {
            return string.Format("/{0}", href);
        }

        public static string GetClientId(this HtmlHelper htmlHelper, object id)
        {
            return DucHelper.GetClientId(id);
        }

        public static string ComposeStringCategoryText(this HtmlHelper htmlHelper, IEnumerable<CategoryDto> categorys)
        {
            StringBuilder CategorysText = new StringBuilder();
            categorys.ForAll(o => CategorysText.AppendFormat("{0},", o.CategoryText));
            return CategorysText.ToString();
        }

        public static string ComposeStringCategoryId(this HtmlHelper htmlHelper, IEnumerable<CategoryDto> categorys)
        {
            StringBuilder CategorysText = new StringBuilder();
            categorys.ForAll(o => CategorysText.AppendFormat("{0},", o.Id));
            return CategorysText.ToString();
        }

        public static string ComposeStringKeywordText(this HtmlHelper htmlHelper, IEnumerable<ReferenceKeywordInfoDto> keywords)
        {
            StringBuilder text = new StringBuilder();
            keywords.ForAll(o => text.AppendFormat("{0},", o.KeywordName));
            return text.ToString();
        }
    }
}