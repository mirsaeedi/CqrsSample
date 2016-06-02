using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Kaftar.Core.CQRS.CommandStack;
using Kaftar.Core.CQRS.QueryStack;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Kaftar.Startup))]

namespace Kaftar
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
