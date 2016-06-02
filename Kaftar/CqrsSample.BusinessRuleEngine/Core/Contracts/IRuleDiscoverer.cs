using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsSample.BusinessRuleEngine.Core.Contracts
{
    internal interface IRuleDiscoverer
    {
        ICollection<Type> Discover();
    }
}
