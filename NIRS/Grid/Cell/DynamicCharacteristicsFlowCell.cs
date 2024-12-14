using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Cell
{
    class DynamicCharacteristicsFlowCell : ParametersCell
    {
        public DynamicCharacteristicsFlowCell()
        {

        }
        public DynamicCharacteristicsFlowCell(double dynamic_m, double M, double v, double w)
        {
            this.dynamic_m = dynamic_m;
            this.M = M;
            this.v = v;
            this.w = w;
        }

        public override double GetValueByString(string param)
        {
            switch (param)
            {
                case "dynamic_m": return dynamic_m;
                case "M": return M;
                case "v": return v;
                case "w": return w;
                default: throw new Exception($"неизвестное значение {param}");
            }
        }

        public override double dynamic_m { get; set; }
        public override double M { get; set; }
        public override double v { get; set; }
        public override double w { get; set; }

        public override double r
        {
            get { throw new Exception("это значение не содержится в этой клетке"); }
            set { throw new Exception("это значение не содержится в этой клетке"); }
        }
        public override double e
        {
            get { throw new Exception("это значение не содержится в этой клетке"); }
            set { throw new Exception("это значение не содержится в этой клетке"); }
        }
        public override double psi
        {
            get { throw new Exception("это значение не содержится в этой клетке"); }
            set { throw new Exception("это значение не содержится в этой клетке"); }
        }
        public override double a
        {
            get { throw new Exception("это значение не содержится в этой клетке"); }
            set { throw new Exception("это значение не содержится в этой клетке"); }
        }
        public override double m
        {
            get { throw new Exception("это значение не содержится в этой клетке"); }
            set { throw new Exception("это значение не содержится в этой клетке"); }
        }
        public override double p
        {
            get { throw new Exception("это значение не содержится в этой клетке"); }
            set { throw new Exception("это значение не содержится в этой клетке"); }
        }
        public override double ro
        {
            get { throw new Exception("это значение не содержится в этой клетке"); }
            set { throw new Exception("это значение не содержится в этой клетке"); }
        }

        public override double eps
        {
            get { throw new Exception("это значение не содержится в этой клетке"); }
            set { throw new Exception("это значение не содержится в этой клетке"); }
        }
        public override double delta_m
        {
            get { throw new Exception("это значение не содержится в этой клетке"); }
            set { throw new Exception("это значение не содержится в этой клетке"); }
        }
    }
}
