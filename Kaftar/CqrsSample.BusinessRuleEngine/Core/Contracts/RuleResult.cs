namespace CqrsSample.BusinessRuleEngine.Core.Contracts
{
    public class RuleResult
    {
        public bool Passed { get;  internal set; }

        public object ReturnedValue { get; internal set; }


    }
}
