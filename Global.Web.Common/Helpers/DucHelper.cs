
namespace Global.Web.Common.Helpers
{
    public static class DucHelper
    {
        public static string GetClientId(object id)
        {
            return string.Format("duc{0}", id);
        }
    }
}
