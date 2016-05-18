using CqrsSample.Core.Domain.Domain.Events.Base;

namespace CqrsSample.Business.Fine.Domain.Events
{
    public class FineDefaultCostChanged:DomainEvent
    {
        private int cost;
        private Data.Models.Fine fine;
        private int oldDefaultCost;

        public FineDefaultCostChanged(Data.Models.Fine fine, int cost, int oldDefaultCost)
        {
            this.fine = fine;
            this.cost = cost;
            this.oldDefaultCost = oldDefaultCost;
        }
    }
}