using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CqrsSample.Core;
using CqrsSample.Core.Data.DataContext;

namespace CqrsSample.FineBusiness.Data
{
    [ModuleDiscovery()]
    public class FineBusinessContext : DbContextBase
    {

    }
}