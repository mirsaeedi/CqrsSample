using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsSample.BusinessRuleEngine.Core.Contracts
{
    [System.AttributeUsage(System.AttributeTargets.Property,
                       AllowMultiple =false)]
    public class RuleFact:Attribute
    {
        public RuleFact(int order=1)
        {
            Order = order;
        }
        public int Order { get; private set; }
    }
}
