using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avicenna.Domain.Data.Models;
using Kaftar.Core.Domain.Domain.Events.Base;

namespace Avicenna.Domain.Domain.Events
{
    public class VisitCreated:IDomainEvent
    {
        public VisitCreated(Visit visit)
        {
            Visit = visit;
        }

        public Visit Visit { get; set; }
    }
}
