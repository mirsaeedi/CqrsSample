using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Kaftar.RuntimePolicyInjection.Core.Contracts;

namespace Kaftar.RuntimePolicyInjection.Core
{
    internal class ClassPolicyLocator : IPolicyLocator
    {
        internal Dictionary<Type, ICollection<Type>> Policies { get; private set; }

        public void Locate()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var result = new Dictionary<Type, ICollection<Type>>();

            foreach (var assembly in assemblies)
            {
                var policies = Discover(assembly);
                result = result.Concat(policies.Where(x=>!result.ContainsKey(x.Key)))
                    .ToDictionary(key => key.Key, value => value.Value);
            }

            Policies =  result;
        }

        internal Dictionary<Type, ICollection<Type>> Discover(Assembly assembly)
        {
            var policies = new Dictionary<Type, ICollection<Type>>();

            var types = assembly.GetTypes();

            foreach (
                var type in
                    types
                    .Where(type => IsDerivedOfGenericType(type, typeof(Policy<>)))
                    .Where(type => !type.IsAbstract))
            {
                if (!policies.ContainsKey(type.BaseType))
                {
                    policies[type.BaseType] = new List<Type>();
                }

                policies[type.BaseType].Add(type);
            }

            return policies;
        }

        static bool IsDerivedOfGenericType(Type type, Type genericType)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == genericType)
                return true;
            if (type.BaseType != null)
            {
                return IsDerivedOfGenericType(type.BaseType, genericType);
            }
            return false;
        }
    }
}
