using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(CqrsSample.Startup))]

namespace CqrsSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            var config = new HttpConfiguration();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly())
                 .PropertiesAutowired();

           
            builder.RegisterModule(new Core.AutofacModule());
            builder.RegisterModule(new Business.Fine.AutofacModule());

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/login"),
                SlidingExpiration = true,
                ExpireTimeSpan = TimeSpan.FromDays(7),
                CookieHttpOnly = true,
                CookiePath = "/"
            });
        }
    }
}
