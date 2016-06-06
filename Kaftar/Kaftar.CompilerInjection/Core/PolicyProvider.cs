using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Kaftar.RuntimePolicyInjection.Core.Contracts;

namespace Kaftar.RuntimePolicyInjection.Core
{
    public class PolicyProvider:IPolicyProvider
    {
        private Dictionary<Type, ICollection<Type>> _policyTypes;
        public static PolicyProvider Instance { get; set; }
        private PolicyProvider(Dictionary<Type, ICollection<Type>> policyTypes)
        {
            _policyTypes = policyTypes;
        }

        public PolicyResultSet<TResult> All<TContract,TResult>(Predicate<TContract> condition, params object[] args)
            where TContract : Policy<TResult> 
        {
            var concretes = _policyTypes[typeof(TContract)];

            var results = new PolicyResultSet<TResult>();

            foreach (var concrete in concretes)
            {
                var instance = Activator.CreateInstance(concrete, args) as TContract;

                if (condition(instance))
                {
                    results.Add(new PolicyResult<TResult>()
                    {
                        Value = instance.Execute(),
                        ConditionMeeted = true,
                        ExecutionDuration = 0,
                        policyName = instance.GetType().FullName
                    });
                }
            }

            return results;
        }

        public PolicyResult<TResult> Single<TContract, TResult>(Predicate<TContract> condition, params object[] args)
            where TContract : Policy<TResult>
        {

            return All<TContract, TResult>(condition, args).Single();
        }

        public PolicyResult<TResult> SingleOrDefault<TContract, TResult>(Predicate<TContract> condition, params object[] args)
            where TContract : Policy<TResult>
        {
            return All<TContract, TResult>(condition, args).SingleOrDefault();
        }

        internal static void CreateSigletonInstance(Dictionary<Type, ICollection<Type>> policyTypes)
        {
            var instance = new PolicyProvider(policyTypes);
            Instance = instance;
        }
    }
}
