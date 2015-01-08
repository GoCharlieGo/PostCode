
using System.Data.Entity;

using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PostCode.Models;
namespace PostCode
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<ApplicationDbContext>(new AppDbInitilizer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
