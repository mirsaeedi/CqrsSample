using System;
using CqrsSample.Core.CQRS.QueryStack.Queries;

namespace CqrsSample.Business.Fine.CQRS.QueryStack.Queries
{
    public class GetStaffFinesCqrsQuery:CqrsQuery
    {
        public DateTime FromDateTime { get; set; }

        public DateTime ToDateTime { get; set; }

        public int? StaffId { get; set; }
    }
}