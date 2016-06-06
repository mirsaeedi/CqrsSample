using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kaftar.RuntimePolicyInjection.Core;

namespace Avicenna.RciContracts
{
    public abstract class BmiCalculator : Policy<double>
    {
        public abstract int ClinicId { get; }
        protected int Weight { get; private set; }
        protected int Height { get; private set; }

        public BmiCalculator(int weight,int height)
        {
            Weight = weight;
            Height = height;
        }
    }
}
