using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using CqrsSample.Core;

namespace CqrsSample
{
    public class CompositionRoot
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();

            //var config = new HttpConfiguration();

            builder
                .RegisterApiControllers(Assembly.GetExecutingAssembly())
                .PropertiesAutowired();

            builder.RegisterModule(new Core.AutofacModule());
            builder.RegisterModule(new Business.Fine.AutofacModule());

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            /*
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
            });*/
        }
    }
}