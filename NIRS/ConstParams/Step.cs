using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.ConstParams
{
    class Step
    {
        public Step(double h, double tau)
        {
            Step.h = h;
            Step.tau = tau;
        }
        public static double h { get; private set; }
        public static double tau { get; private set; }
    }
}
