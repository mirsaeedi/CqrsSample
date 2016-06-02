using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaftar.Core
{
    public interface ICqrsModuleMetaData
    {
        string ModuleName { get; }
    }
}
