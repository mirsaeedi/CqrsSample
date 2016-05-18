using CqrsSample.Domain.Events;

namespace CqrsSample.Data.Models
{
    internal class FineDefined : DomainEvent
    {
        public Fine Fine { get; set; }

        public FineDefined(Fine fine)
        {
            Fine = fine;
        }
    }
}