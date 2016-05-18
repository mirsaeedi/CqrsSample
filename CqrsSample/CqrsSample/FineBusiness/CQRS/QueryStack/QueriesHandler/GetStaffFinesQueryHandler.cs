using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CqrsSample.CQRS.QueryStack.QueryHandler;
using CqrsSample.Data.DataContext;
using CqrsSample.Data.Models;
using CqrsSample.FineBusiness.CQRS.QueryStack.Queries;
using CqrsSample.QueryStack;
using CqrsSample.QueryStack.QueryHandler;

namespace CqrsSample.FineBusiness.CQRS.QueryStack.QueriesHandler
{
    public class GetStaffFinesQueryHandler:QueryHandler<GetStaffFinesCqrsQuery,List<StaffFine>>
    {
        public GetStaffFinesQueryHandler(IReadOnlyDataContext dataContext) : base(dataContext)
        {

        }

        internal override CqrsQueryResult<List<StaffFine>> PreExecutionValidation(GetStaffFinesCqrsQuery cqrsQuery)
        {
            return OkResult(cqrsQuery);
        }

        internal override async Task<List<StaffFine>> GetResult(GetStaffFinesCqrsQuery cqrsQuery, int userId)
        {
            return await DataContext.Set<StaffFine>()
                .Where(q => q.DateTime >= cqrsQuery.FromDateTime && q.DateTime < cqrsQuery.ToDateTime
                && (!cqrsQuery.StaffId.HasValue || (cqrsQuery.StaffId == q.StaffId)))
                .ToListAsync();
        }
    }
}