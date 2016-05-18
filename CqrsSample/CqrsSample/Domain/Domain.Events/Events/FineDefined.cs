﻿using CqrsSample.Domain.Events;

namespace CqrsSample.Data.Models
{
    public class FineDefined : DomainEvent
    {
        public Fine Fine { get; set; }

        public FineDefined(Fine fine)
        {
            Fine = fine;
        }
    }
}