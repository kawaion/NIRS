using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.NablaFunctions
{
    interface INabla
    {
        double Nabla(string param1, string v, double n, double k);
        double Nabla(string v, double n, double k);
        double dDivdx(string param, double n, double k);
    }
}
