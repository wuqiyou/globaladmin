using System.Web;

namespace Global.Web.Common.Helpers
{
    public static class CookieHelper
    {
        public static void WriteCookie(string key, string value)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(key);
            if (cookie == null)
            {
                cookie = new HttpCookie(key);
                HttpContext.Current.Response.Cookies.Remove(key);
            }
            cookie.Value = value;
            HttpContext.Current.Response.Cookies.Set(cookie);
        }

        public static string ReadCookie(string key)
        {
            var httpCookie = HttpContext.Current.Request.Cookies.Get(key);
            string value = httpCookie != null ? httpCookie.Value : null;
            return value;
        }
    }
}