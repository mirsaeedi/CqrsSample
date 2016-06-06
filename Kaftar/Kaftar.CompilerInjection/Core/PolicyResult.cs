namespace Kaftar.RuntimePolicyInjection.Core
{
    public class PolicyResult<TResult>
    {
        internal PolicyResult()
        {
            
        }

        public bool ConditionMeeted { get; internal set; }

        public double ExecutionDuration { get; internal set; }

        public string policyName { get; internal set; }

        public TResult Value { get; internal set; }
    }
}
