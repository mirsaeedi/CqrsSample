using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avicenna.RciContracts;

namespace Avicenna.RciConcrete
{
    public class MehdiBmiCalculator:BmiCalculator
    {
        public MehdiBmiCalculator(int weight, int height) : base(weight, height)
        {

        }

        public override int ClinicId => 6;

        public override double Execute()
        {
            var bmi =  Weight + Height*Height;
            return bmi;
        }
    }
}
