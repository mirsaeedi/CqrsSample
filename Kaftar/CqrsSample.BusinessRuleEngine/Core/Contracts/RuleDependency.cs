using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsSample.BusinessRuleEngine.Core.Contracts
{
    internal class RuleDependency<T>
    {
        public RuleDependency(T dependency)
        {
            Dependency = dependency;
        }
        public T Dependency { get; private set; }
    }
}
