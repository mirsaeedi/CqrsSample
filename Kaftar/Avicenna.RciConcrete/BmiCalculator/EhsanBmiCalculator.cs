using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avicenna.RciContracts;

namespace Avicenna.RciConcrete
{
    public class EhsanBmiCalculator:BmiCalculator
    {
        public EhsanBmiCalculator(int weight, int height) : base(weight, height)
        {

        }

        public override int ClinicId => 5;

        public override double Execute()
        {
            var bmi =  Weight + Height;
            return bmi;
        }
    }
}
