using System;
using System.Collections.Generic;

namespace CqrsSample.BusinessRuleEngine.Core.Contracts
{
    public interface IRule
    {
        bool IsEnable { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int Priority { get; set; }
        ICollection<string> Tag { get; set; }
        bool Condition();
        object Action();
    }
}
