using System;

namespace Kaftar.RuntimePolicyInjection.Core.Contracts
{
    public interface IPolicyProvider
    {
        PolicyResultSet<TResult> All<TContract, TResult>(Predicate<TContract> condition, params object[] args)
            where TContract : Policy<TResult>;

        PolicyResult<TResult> Single<TContract, TResult>(Predicate<TContract> condition, params object[] args)
    where TContract : Policy<TResult>;

        PolicyResult<TResult> SingleOrDefault<TContract, TResult>(Predicate<TContract> condition, params object[] args)
    where TContract : Policy<TResult>;
    }
}
