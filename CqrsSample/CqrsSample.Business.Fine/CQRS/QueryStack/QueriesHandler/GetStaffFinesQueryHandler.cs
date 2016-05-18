using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CqrsSample.Business.Fine.CQRS.QueryStack.Queries;
using CqrsSample.Business.Fine.Data.Models;
using CqrsSample.Core.CQRS.QueryStack.QueryHandler;
using CqrsSample.Core.CQRS.QueryStack.QueryResults;
using CqrsSample.Core.Data.DataContext;

namespace CqrsSample.Business.Fine.CQRS.QueryStack.QueriesHandler
{
    public class GetStaffFinesQueryHandler:QueryHandler<GetStaffFinesCqrsQuery,List<StaffFine>>
    {
        public GetStaffFinesQueryHandler(IReadOnlyDataContext dataContext) : base(dataContext)
        {

        }

        protected override CqrsQueryResult<List<StaffFine>> PreExecutionValidation(GetStaffFinesCqrsQuery cqrsQuery)
        {
            return OkResult(cqrsQuery);
        }

        protected override async Task<List<StaffFine>> GetResult(GetStaffFinesCqrsQuery cqrsQuery, int userId)
        {
            return await DataContext.Set<StaffFine>()
                .Where(q => q.DateTime >= cqrsQuery.FromDateTime && q.DateTime < cqrsQuery.ToDateTime
                && (!cqrsQuery.StaffId.HasValue || (cqrsQuery.StaffId == q.StaffId)))
                .ToListAsync();
        }
    }
}