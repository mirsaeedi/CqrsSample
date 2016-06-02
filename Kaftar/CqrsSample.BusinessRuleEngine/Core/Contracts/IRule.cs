using System;
using System.Collections.Generic;

namespace CqrsSample.BusinessRuleEngine.Core.Contracts
{
    internal interface IRule<in T> : IRule
    {
        bool Condition (T t);
        object ThenAction(T t);
        object ElseAction(T t);
    }

    internal interface IRule
    {

        bool IsEnable { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int Priority { get; set; }
        ICollection<string> Tag { get; set; }
        bool Condition();
        object ThenAction();
        object ElseAction();
    }
}
