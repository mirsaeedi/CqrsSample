using System;
using System.Diagnostics.Contracts;
using CqrsSample.Business.Fine.Domain.Events;
using CqrsSample.Core.Data.Models;

namespace CqrsSample.Business.Fine.Data.Models
{
    public class Fine:Entity
    {
        private Fine()
        {
            
        }

        [ContractInvariantMethod]
        private void Invariants()
        {
            Contract.Invariant(MinCost>0 && MaxCost>0 && DefaultCost>0);
            Contract.Invariant(string.IsNullOrEmpty(Name));
        }

        public Fine (string name, int minCost, int maxCost, int defaultCost)
        {
            Name = name;
            MaxCost = maxCost;
            MinCost = minCost;
            DefaultCost = defaultCost;

            Events.Add(new FineDefined(this));
        }

        public string Name { get; private set; }

        public int MinCost { get; private set; }

        public int MaxCost { get; private set; }

        public int DefaultCost { get; private set; }

        public void SetName(string name)
        {
            Name = name;
        }

        public void ChangeDefaultCost(int cost)
        {
            var oldDefaultCost = DefaultCost;
            DefaultCost = cost;
            Events.Add(new FineDefaultCostChanged(this,cost, oldDefaultCost));
        }

        public void ChangeMinCost(int cost)
        {
            MinCost = cost;
        }

        public void ChangeMaxCost(int cost)
        {
            MaxCost = cost;
        }

    }
}