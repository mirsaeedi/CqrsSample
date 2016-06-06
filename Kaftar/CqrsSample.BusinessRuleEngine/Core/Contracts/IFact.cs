using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsSample.BusinessRuleEngine.Core.Contracts
{
    public interface IFact<T>
    {
        T Value { get; set; }

        string Name { get; set; }
    }
}
