using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Cell
{
    class DynamicCharacteristicsFlowCell:ParametersCell
    {
        public DynamicCharacteristicsFlowCell()
        {

        }
        public DynamicCharacteristicsFlowCell(double m,double M,double v,double w)
        {
            this.m = m;
            this.M = M;
            this.v = v;
            this.w = w;
        }
        double m { get; set; }
        double M { get; set; }
        double v { get; set; }
        double w { get; set; }

        double r1 => throw new Exception("это значение не содержится в этой клетке");
        double r2 => throw new Exception("это значение не содержится в этой клетке");
        double e => throw new Exception("это значение не содержится в этой клетке");
        double psi => throw new Exception("это значение не содержится в этой клетке");
        double a => throw new Exception("это значение не содержится в этой клетке");
    }
}
