using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Avicenna.Domain.Data.Models
{
    public class Visit:IEntity
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime DateTime { get; set; }
        public Guid PatientGuid { get; set; }
        public Patient Patient { get; set; }
        public string Comments { get; set; }

    }
}
