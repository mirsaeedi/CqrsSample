using System;
using System.Collections.Generic;

namespace CqrsSample.BusinessRuleEngine.Core.Contracts
{
    interface IRuleFactory
    {
        /*
        IRule<,,> Create<T>(string name,int priority,ICollection<string> tags, Predicate<T> condition, Func<T, RuleResult> thenAction, Func<T,RuleResult> elseAction);

        IRule<,,> Create<T>(string name, ICollection<string> tags, Predicate<T> condition, Func<T, RuleResult> thenAction, Func<T, RuleResult> elseAction);

        IRule<,,> Create<T>(string name, Predicate<T> condition, Func<T, RuleResult> thenAction, Func<T, RuleResult> elseAction);

        IRule<,,> Create<T>(Predicate<T> condition, Func<T, RuleResult> thenAction, Func<T, RuleResult> elseAction);

        */
    }
}
