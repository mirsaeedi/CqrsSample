using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using CqrsSample.Core.CQRS.CommandStack;
using CqrsSample.Core.CQRS.QueryStack;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(CqrsSample.Startup))]

namespace CqrsSample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
