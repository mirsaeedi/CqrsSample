using CqrsSample.Core.Domain.Domain.Events.Base;

namespace CqrsSample.Business.Fine.Domain.Events
{
    public class FineDefined : DomainEvent
    {
        public Data.Models.Fine Fine { get; set; }

        public FineDefined(Data.Models.Fine fine)
        {
            Fine = fine;
        }
    }
}