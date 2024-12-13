using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Cell
{
    class MixtureStateParametersCell:ParametersCell
    {
        public MixtureStateParametersCell(double r1,double r2,double e,double psi,double a, double m)
        {
            this.r1 = r1;
            this.r2 = r2;
            this.e = e;
            this.psi = psi;
            this.a = a;
            this.m = m;
        }
        double r1 { get; set; }
        double r2 { get; set; }
        double e { get; set; }
        double psi { get; set; }
        double a { get; set; }
        double m { get; set; }

        double M => throw new Exception("это значение не содержится в этой клетке");
        double v => throw new Exception("это значение не содержится в этой клетке");
        double w => throw new Exception("это значение не содержится в этой клетке");
    }
}
