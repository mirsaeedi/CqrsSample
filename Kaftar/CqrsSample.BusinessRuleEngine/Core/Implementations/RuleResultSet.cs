using System.Collections;
using System.Collections.Generic;
using CqrsSample.BusinessRuleEngine.Core.Contracts;

namespace CqrsSample.BusinessRuleEngine.Core.Implementations
{
    public class RuleResultSet :  IReadOnlyCollection<RuleResult>
    {
        private readonly ICollection<RuleResult> _results=new List<RuleResult>();
        internal void Add(RuleResult ruleResult)
        {
            _results.Add(ruleResult);
        }

        public int Count => _results.Count;

        public IEnumerator<RuleResult> GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _results.GetEnumerator();
        }
    }
}
