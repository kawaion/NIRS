using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.ConstParams
{
    class ConstPowder
    {
        public ConstPowder(double u1, double Q, double e1)
        {
            ConstPowder.u1=u1;
            ConstPowder.Q = Q;
            ConstPowder.e1 = e1;
        }
        public static double u1 { get; private set; }
        public static double Q { get; private set; }
        public static double e1 { get; private set; }
    }
}
