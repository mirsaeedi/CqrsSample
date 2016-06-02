using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsSample.BusinessRuleEngine.Core.Implementations;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            BootStrapper bootStrapper=new BootStrapper();
            bootStrapper.Bootstrap(null);
        }
    }
}
