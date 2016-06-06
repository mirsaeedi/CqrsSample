using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using Avicenna.RciContracts;

namespace Test
{
    public class TestPolicy : BmiCalculator
    {
        public override int ClinicId => 7;


        public TestPolicy(int w,int h):base(w,h)
        {

        }

        public override double Execute()
        {
            return Weight + Height + 10;
        }
    }
}
