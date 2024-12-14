using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.ConstParams
{
    class Viscosity
    {
        public Viscosity(double mu0)
        {
            Viscosity.mu0 = mu0;
        }
        public static double mu0 { get; private set; }
    }
}
