using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CqrsSample.QueryStack.Queries;

namespace CqrsSample.FineBusiness.CQRS.QueryStack.Queries
{
    public class GetStaffFinesCqrsQuery:CqrsQuery
    {
        public DateTime FromDateTime { get; set; }

        public DateTime ToDateTime { get; set; }

        public int? StaffId { get; set; }
    }
}