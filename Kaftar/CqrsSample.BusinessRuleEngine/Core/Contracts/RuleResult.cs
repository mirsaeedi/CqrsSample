namespace CqrsSample.BusinessRuleEngine.Core.Contracts
{
    public class RuleResult
    {
        internal RuleResult()
        {
            
        }

        public bool ConditionMeeted { get; internal set; }

        public double ExecutionDuration { get; internal set; }

        public string RuleName { get; internal set; }

        public object ReturnedValue { get; internal set; }
    }
}
