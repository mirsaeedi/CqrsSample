namespace CqrsSample.Core.Domain.AggregateRoots
{
    public abstract class Entity
    {
        public long Id { get; set; }

        public EntityState EntityState { get; set; }
    }
}