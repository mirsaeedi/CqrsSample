using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsSample.BusinessRuleEngine.Core.Contracts;

namespace CqrsSample.BusinessRuleEngine.Core.Implementations
{
    public class RuleSession : IRuleSession
    {
        readonly List<Tuple<Type,object>> facts=new List<Tuple<Type, object>>(); 
        internal RuleSession()
        {
            
        } 
        public void AddFact<T>(T fact) where T : class
        {
            facts.Add(new Tuple<Type, object>(typeof(T),fact));
        }

        public RuleResultSet ExecuteRules(IRuleTagCollection tags=null)
        {
            var rules = new List<IRule>();

            foreach (var rule in rules)
            {
                
            }

            return null;
        }

        public void RemoveFact<T>(T fact) where T : class
        {
            var oldFact = facts.SingleOrDefault(q=>q.Item2==fact);

            if (oldFact!=null)
            {
                facts.Remove(oldFact);
            }
        }
    }
}
