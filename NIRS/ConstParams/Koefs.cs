using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.ConstParams
{
    class Koefs
    {
        public Koefs(double lamda0)
        {
            Koefs.lamda0 = lamda0;
        }

        public static double lamda0 { get; private set; }
    }
}
