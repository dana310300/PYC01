using System.Web;
using System.Web.Mvc;

namespace REP001.Comun.WebSparkViewEngine.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}