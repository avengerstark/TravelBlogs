using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using TravelBlogs.WEB.Infrastructure;

[assembly: OwinStartup(typeof(TravelBlogs.WEB.App_Start.Startup))]
namespace TravelBlogs.WEB.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });

            //Конфигурация перенесена из Global.asax
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MapperInitialize.Configure();
            
        }
    }
}