using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsSample.BusinessRuleEngine.Core.Implementations;

namespace CqrsSample.BusinessRuleEngine.Core.Contracts
{
    public interface IRuleTagCollection
    {
        RuleTagCollection Add(RuleTag ruleTag);

        RuleTagCollection Remove(RuleTag ruleTag);
    }
}
