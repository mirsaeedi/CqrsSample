using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaftar.Core.CQRS.CommandStack.Commands;

namespace Avicenna.Domain.CQRS.CommandStack.Commands
{
    public class CreateVisitCommand:CqrsCommand
    {
        public Guid PatientGuid { get; set; }

        public string Comments { get; set; }

        public DrugPrescription[] DrugPrescriptions { get; set; }
    }

    public class DrugPrescription
    {
        public string Description { get; set; }
        public Guid DrugGuid { get; set; }
        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

    }
}
