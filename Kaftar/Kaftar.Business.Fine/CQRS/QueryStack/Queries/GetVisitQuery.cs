using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaftar.Core.CQRS.QueryStack.Queries;

namespace Avicenna.Domain.CQRS.QueryStack.Queries
{
    public class GetVisitQuery: CqrsQuery
    {
        public Guid VisitGuid { get; set; }
    }
}
