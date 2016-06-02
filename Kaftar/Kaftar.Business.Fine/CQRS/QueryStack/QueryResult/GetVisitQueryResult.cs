using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avicenna.Domain.Data.Models;

namespace Avicenna.Domain.CQRS.QueryStack.QueryResult
{
    public class GetVisitQueryResult
    {
        public Guid Guid { get; set; }
        public DateTime DateTime { get; set; }
        public Guid PatientGuid { get; set; }
        public string PatientName { get; set; }
        public string Comments { get; set; }
    }
}
