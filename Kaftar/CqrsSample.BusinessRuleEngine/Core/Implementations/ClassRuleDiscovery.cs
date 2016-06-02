using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CqrsSample.BusinessRuleEngine.Core.Contracts;

namespace CqrsSample.BusinessRuleEngine.Core.Implementations
{
    internal class ClassRuleDiscoverer : IRuleDiscoverer
    {
        public ICollection<Type> Discover()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var rules = new List<Type>();

            foreach (var assembly in assemblies)
            {
                rules.AddRange(Discover(assembly));
            }

            return rules;
        }

        public ICollection<Type> Discover(Assembly assembly)
        {
            var rules = new List<Type>();

            var types = assembly.GetTypes();
            rules.AddRange(from type in types where typeof(IRule).IsAssignableFrom(type) && type.IsClass select type);

            return rules;
        }
    }
}
