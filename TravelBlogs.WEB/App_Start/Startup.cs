using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using TravelBlogs.BLL.Services;
using TravelBlogs.BLL.Interfaces;
using TravelBlogs.BLL.Infrastructure;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

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
            AutoMapperBLLConfig.Configure();
            
        }
    }
}