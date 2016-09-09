using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using TravelBlogs.BLL.Services;
using TravelBlogs.BLL.Interfaces;

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
        }
    }
}