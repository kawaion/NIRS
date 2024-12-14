using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Cell
{
    class MixtureStateParametersCell : ParametersCell
    {
        public MixtureStateParametersCell()
        {

        }
        public MixtureStateParametersCell(double r, double e, double eps, double psi, double a, double m, double p, double ro, double delta_m)
        {
            this.r = r;
            this.e = e;
            this.eps = eps;
            this.psi = psi;
            this.a = a;
            this.m = m;
            this.p = p;
            this.ro = ro;
            this.delta_m = delta_m;
        }
        public override double GetValueByString(string param)
        {
            switch (param)
            {
                case "r": return r;
                case "e": return e;
                case "eps": return eps;
                case "psi": return psi;
                case "a": return a;
                case "m": return m;
                case "p": return p;
                case "ro": return ro;
                case "delta_m": return delta_m;
                default: throw new Exception($"неизвестное значение {param}");
            }
        }
        public override double r { get; set; }
        public override double e { get; set; }
        public override double eps { get; set; }
        public override double psi { get; set; }
        public override double a { get; set; }
        public override double m { get; set; }
        public override double p { get; set; }
        public override double ro { get; set; }
        public override double delta_m { get; set; }




        public override double M
        {
            get { throw new Exception("это значение не содержится в этой клетке"); }
            set { throw new Exception("это значение не содержится в этой клетке"); }
        }
        public override double v
        {
            get { throw new Exception("это значение не содержится в этой клетке"); }
            set { throw new Exception("это значение не содержится в этой клетке"); }
        }
        public override double w
        {
            get { throw new Exception("это значение не содержится в этой клетке"); }
            set { throw new Exception("это значение не содержится в этой клетке"); }
        }
        public override double dynamic_m
        {
            get { throw new Exception("это значение не содержится в этой клетке"); }
            set { throw new Exception("это значение не содержится в этой клетке"); }
        }


    }
}
