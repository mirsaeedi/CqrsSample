using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CqrsSample.Data.Models;
using CqrsSample.Domain.Events;

namespace CqrsSample.FineBusiness.Domain.Events
{
    public class StaffRegistred:DomainEvent
    {
        public StaffRegistred(Staff staff)
        {
            Staff = staff;
        }

        public Staff Staff { get;private set; }
    }
}