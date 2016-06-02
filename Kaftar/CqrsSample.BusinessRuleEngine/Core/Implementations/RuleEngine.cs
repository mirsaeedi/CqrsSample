using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsSample.BusinessRuleEngine.Core.Contracts;

namespace CqrsSample.BusinessRuleEngine.Core.Implementations
{
    public class RuleEngine : IRuleEngine
    {
        private ICollection<Type> _ruleTypes;
        public static RuleEngine Instance { get; set; }
        private RuleEngine(ICollection<Type> ruleTypes)
        {
            _ruleTypes = ruleTypes;
        }

        internal static void CreateSigletonInstance(ICollection<Type> ruleTypes)
        {
            var instance = new RuleEngine(ruleTypes);
            Instance = instance;
        }

        public IRuleSession CreateSession()
        {
            return new RuleSession();
        }

        public void Rules(ICollection<Type> facts,RuleTagCollection tags)
        {
            foreach (var ruleTypes in _ruleTypes)
            {
                var properties = ruleTypes.GetProperties();

                foreach (var property in properties)
                {
                    var attribute = property.GetCustomAttributes(typeof(RuleFact), true).FirstOrDefault() as RuleFact;
                }
            }
        }
    }

    internal class RuleDiscoveryNode
    {
        private Dictionary<Type, RuleDiscoveryNode> _children;

        public RuleDiscoveryNode(Type factType,ICollection<Type> ruleTypes)
        {
            FactType = factType;
            RuleTypes = ruleTypes;

            _children=new Dictionary<Type, RuleDiscoveryNode>();
        }

        public void AddChild(Type factType, ICollection<Type> ruleTypes)
        {
            
        }

        public Type FactType { get; private set; }
        public ICollection<Type> RuleTypes { get; private set; }
    }

    internal class RuleDiscoveryTree
    {
        public RuleDiscoveryTree()
        {
            
        }

        public void AddRuleType(Type ruleType)
        {
            var properties = ruleType.GetProperties();

            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttributes(typeof(RuleFact), true).FirstOrDefault() as RuleFact;

                if (attribute != null)
                {
                    
                }

            }
        }

        public Type[] GetRules(ICollection<Type> factTypes)
        {
            return null;
        }
    }
}
