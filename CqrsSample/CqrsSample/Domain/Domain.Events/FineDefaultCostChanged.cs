using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CqrsSample.Data.Models;

namespace CqrsSample.Domain.Events
{
    public class FineDefaultCostChanged:DomainEvent
    {
        private int cost;
        private Fine fine;
        private int oldDefaultCost;

        public FineDefaultCostChanged(Fine fine, int cost, int oldDefaultCost)
        {
            this.fine = fine;
            this.cost = cost;
            this.oldDefaultCost = oldDefaultCost;
        }
    }
}