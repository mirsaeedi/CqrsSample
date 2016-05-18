﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CqrsSample.Core.Data.DataContext;
using CqrsSample.FineBusiness.Data;
using Module = Autofac.Module;

namespace CqrsSample.Business.Fine
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assmeblyName = Assembly.GetExecutingAssembly().GetName();

            builder
                .Register((c) => {
                    var dbContext = new FineBusinessContext();
                    return dbContext;
                })
                .As<DbContextBase>()
                .InstancePerRequest()
                .WithMetadata("assembly_name", assmeblyName);
        }
    }
}
