using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.ConstParams
{
    class ConstPowder
    {
        public ConstPowder(double u1, double Q, double e1, double teta, double alpha, double omega_v, double f, double omega, double delta)
        {
            ConstPowder.u1=u1;
            ConstPowder.Q = Q;
            ConstPowder.e1 = e1;
            ConstPowder.teta = teta;
            ConstPowder.alpha = alpha;
            ConstPowder.omega_v = omega_v;
            ConstPowder.f = f;
            ConstPowder.omega = omega;
            ConstPowder.delta = delta;
        }
        public static double u1 { get; private set; }
        public static double Q { get; private set; }
        public static double e1 { get; private set; }
        public static double teta { get; private set; }
        public static double alpha { get; private set; }
        public static double omega_v { get; private set; }
        public static double f { get; private set; }
        public static double omega { get; private set; }
        public static double delta { get; private set; }
        


    }
}
