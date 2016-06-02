using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avicenna.Domain.Data.Models
{
    public class Drug : IEntity
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }

        public string Name { get; set; }
    }
}
