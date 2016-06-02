using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsSample.BusinessRuleEngine.Data
{
    internal class RuleEntity
    {
        public int Id { get; set; }
        public bool IsEnable { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public string Tag { get; set; }
        public RuleType RuleType { get; set; }
    }
}
