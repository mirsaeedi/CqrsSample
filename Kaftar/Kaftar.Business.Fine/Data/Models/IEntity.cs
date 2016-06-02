using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Avicenna.Domain.Data.Models
{
    public interface IEntity
    {
        [Index(IsClustered = true, IsUnique = false)]
        long Id { get; set; }

        [Key]
        Guid Guid { get; set; }
    }
}
