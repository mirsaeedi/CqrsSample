namespace Kaftar.RuntimePolicyInjection.Core
{
    public abstract class Policy<T>
    {
        public abstract T Execute();
    }
}
