using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsSample.BusinessRuleEngine.Core.Contracts;

namespace CqrsSample.BusinessRuleEngine.Core.Implementations
{
    public class RuleTagCollection:IRuleTagCollection
    {
        List<RuleTag> _internalList= new List<RuleTag>();
        public RuleTagCollection ()
        {
            
        }

        public RuleTagCollection Add(RuleTag ruleTag)
        {
            if (_internalList.Any(q => q.Value == ruleTag.Value))
                return this;

            _internalList.Add(ruleTag);
            return this;
        }

        public RuleTagCollection Remove(RuleTag ruleTag)
        {
            if (_internalList.Any(q => q.Value != ruleTag.Value))
                return this;

            _internalList.Remove(ruleTag);
            return this;
        }
    }
}
