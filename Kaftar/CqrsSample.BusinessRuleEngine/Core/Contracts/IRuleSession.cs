using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsSample.BusinessRuleEngine.Core.Implementations;

namespace CqrsSample.BusinessRuleEngine.Core.Contracts
{
    public interface IRuleSession
    {
        void AddFact<T>(T fact) where T : class;
        void RemoveFact<T>(T fact) where T : class;
        RuleResultSet ExecuteRules(IRuleTagCollection tags=null);
    }
}
