using System.Collections;
using System.Collections.Generic;

namespace Kaftar.RuntimePolicyInjection.Core
{
    public class PolicyResultSet<TResult> :  IReadOnlyCollection<PolicyResult<TResult>>
    {
        private readonly ICollection<PolicyResult<TResult>> _results=new List<PolicyResult<TResult>>();
        internal void Add(PolicyResult<TResult> policyResult)
        {
            _results.Add(policyResult);
        }

        public int Count => _results.Count;

        public IEnumerator<PolicyResult<TResult>> GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _results.GetEnumerator();
        }
    }
}
