using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsSample.BusinessRuleEngine.Core.Contracts;


namespace CqrsSample.BusinessRuleEngine.Sample
{
    public class SampleRule : IRule
    {
        [RuleFact(order:1)]
        public Employee Employee { get; set; }

        [RuleFact(order: 2)]
        public Employee Employer { get; set; }


        public SampleRule()
        {
            IsEnable = true;
            Name = "SampleTest";
            Description = "Description";
        }

        public bool IsEnable { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public ICollection<string> Tag { get; set; }
        public object ThenAction()
        {
            Employee.HasAuthority = true;
            return null;
        }

        public object ElseAction()
        {
            return "stop him";
        }

        public bool Condition()
        {
            return Employee.Age > 30;
        }
    }
}
