using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsSample.Core;

namespace CqrsSample.Business.Fine
{
    public class FineModuleMetaData : ICqrsModuleMetaData
    {
        public string ModuleName => "Fine";
    }
}
