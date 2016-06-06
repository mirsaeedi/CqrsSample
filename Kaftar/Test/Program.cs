using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avicenna.RciContracts;
using System.Data;
using CqrsSample.BusinessRuleEngine.Sample;
using Kaftar.RuntimePolicyInjection.Core;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            PolicyInjectionBootstrapper.DiscoverPolicies();

            int height = 0;
            int weigth = 0;

            Console.ReadLine();

            var ruleResult = PolicyProvider.Instance
                .Single<BmiCalculator,double>
                ((contract) => contract.ClinicId == 7
                , weigth, height);
        }
    }
}
