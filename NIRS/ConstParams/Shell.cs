using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.ConstParams
{
    class Shell
    {
        public Shell(double q)
        {
            Shell.q = q;
        }

        public static double q { get; private set; }
    }

}
