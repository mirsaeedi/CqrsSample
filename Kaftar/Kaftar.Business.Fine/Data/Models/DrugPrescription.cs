using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Avicenna.Domain.Data.Models
{
    public class DrugPrescription:IEntity
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string Description { get; set; }
        public Guid PatientGuid { get; set; }
        public Patient Patient { get; set; }
        public Guid VisitGuid { get; set; }
        public Visit Visit { get; set; }
        public Guid DrugGuid { get; set; }
        public Drug Drug { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public bool IsActive { get; set; }

    }
}
