using System;
using System.Configuration;

namespace Global.Web.Common
{
    public static class SiteConfig
    {

        public static int PageSize
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
            }
        }

        public static string ImageServeRoot
        {
            get
            {
                return ConfigurationManager.AppSettings["ImageServeRoot"];
            }
        }
    }
}