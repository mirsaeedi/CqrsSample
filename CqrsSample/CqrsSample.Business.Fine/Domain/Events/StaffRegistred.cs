using CqrsSample.Business.Fine.Data.Models;
using CqrsSample.Core.Domain.Domain.Events.Base;

namespace CqrsSample.Business.Fine.Domain.Events
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