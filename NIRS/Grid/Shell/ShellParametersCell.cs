using NIRS.Cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Grid.Shell
{
    class ShellParametersCell : ParametersCell
    {
        public override double dynamic_m { get; set; }
        public override double M { get; set; }
        public override double m { get; set; }
        public override double v { get; set; }
        public override double w { get; set; }
        public override double r { get; set; }
        public override double e { get; set; }
        public override double eps { get; set; }
        public override double psi { get; set; }
        public override double z { get; set; }
        public override double a { get; set; }
        public override double p { get; set; }
        public override double ro { get; set; }

        public double x { get; set; }

        public override double GetValueByString(string param)
        {
            switch (param)
            {
                case "dynamic_m": return dynamic_m;
                case "M": return M;
                case "v": return v;
                case "w": return w;
                case "r": return r;
                case "e": return e;
                case "eps": return eps;
                case "psi": return psi;
                case "z": return z;
                case "a": return a;
                case "m": return m;
                case "p": return p;
                case "ro": return ro;
                case "x": return x;

                default: throw new Exception($"неизвестное значение {param}");
            }
        }
    }
}
