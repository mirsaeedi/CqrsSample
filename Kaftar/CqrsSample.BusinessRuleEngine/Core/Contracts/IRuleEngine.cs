using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace CqrsSample.BusinessRuleEngine.Core.Contracts
{
    interface IRuleEngine
    {
        IRuleSession CreateSession();

    }
}
