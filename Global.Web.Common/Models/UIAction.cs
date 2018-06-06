using System.Collections.Generic;
using System.Web.Routing;

namespace Global.Web.Common.Models
{
    public class UIAction
    {
        public string LinkText { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public RouteValueDictionary Parameters { get; set; }
        public string Target { get; set; }

        public UIAction(string text, string controller, string action)
        {
            LinkText = text;
            Action = action;
            Controller = controller;
            Parameters = new RouteValueDictionary();
        }

        public void AddParameter(string key, string value)
        {
            Parameters.Add(key, value);
        }
    }
}