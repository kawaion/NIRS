using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Cell
{
    abstract class ParametersCell
    {
        double m { get; set; }
        double M { get; set; }
        double v { get; set; }
        double w { get; set; }

        double r1 { get; set; }
        double r2 { get; set; }
        double e { get; set; }
        double psi { get; set; }
        double a { get; set; }


    }
}
