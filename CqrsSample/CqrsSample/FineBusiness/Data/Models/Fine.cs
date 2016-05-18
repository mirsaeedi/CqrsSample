using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using CqrsSample.Domain.Events;

namespace CqrsSample.Data.Models
{
    public class Fine:Entity
    {
        private Fine()
        {
            
        }

        public Fine (string name, int minCost, int maxCost, int defaultCost)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("");

            if (minCost < 0 || maxCost < 0 || defaultCost < 0)
                throw new Exception("");

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