using System;
using System.Collections.Generic;
using System.Linq;
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
