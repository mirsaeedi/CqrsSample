using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsSample.BusinessRuleEngine.Sample
{
    public class Employee
    {
        public string Name { get; set; }

        public int Age { get; set; }
        public bool HasAuthority { get; internal set; }
    }
}
