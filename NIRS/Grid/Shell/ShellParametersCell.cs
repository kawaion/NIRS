using NIRS.Grid.Cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Grid.Shell
{
    class ShellParametersCell : ParametersCell
    {
        private GridType gridType;
        public ShellParametersCell(GridType gridType)
        {

        }
        private double dynamic_mValue;
        private double MValue;
        private double mValue;
        private double vValue;
        private double wValue;
        private double rValue;
        private double eValue;
        private double epsValue;
        private double psiValue;
        private double zValue;
        private double aValue;
        private double pValue;
        private double roValue;

        public double xValue;


        public override double dynamic_m 
        { 
            get 
            {
                if (gridType == GridType.dynamic) return dynamic_mValue;
                else throw new Exception("обращение к не динамическому параметру");
            }
            set
            {
                if (gridType == GridType.dynamic) dynamic_mValue=value;
                else throw new Exception("обращение к не динамическому параметру");
            }
        }
        public override double M
        {
            get
            {
                if (gridType == GridType.dynamic) return MValue;
                else throw new Exception("обращение к не динамическому параметру");
            }
            set
            {
                if (gridType == GridType.dynamic) MValue = value;
                else throw new Exception("обращение к не динамическому параметру");
            }
        }
        public override double m
        {
            get
            {
                if (gridType == GridType.dynamic) return mValue;
                else throw new Exception("обращение к не динамическому параметру");
            }
            set
            {
                if (gridType == GridType.dynamic) mValue = value;
                else throw new Exception("обращение к не динамическому параметру");
            }
        }
        public override double v
        {
            get
            {
                if (gridType == GridType.dynamic) return vValue;
                else throw new Exception("обращение к не динамическому параметру");
            }
            set
            {
                if (gridType == GridType.dynamic) vValue = value;
                else throw new Exception("обращение к не динамическому параметру");
            }
        }
        public override double w
        {
            get
            {
                if (gridType == GridType.dynamic) return wValue;
                else throw new Exception("обращение к не динамическому параметру");
            }
            set
            {
                if (gridType == GridType.dynamic) wValue = value;
                else throw new Exception("обращение к не динамическому параметру");
            }
        }
        public override double r
        {
            get
            {
                if (gridType == GridType.mixtureState) return rValue;
                else throw new Exception("обращение к не параметру состояния смеси");
            }
            set
            {
                if (gridType == GridType.mixtureState) rValue = value;
                else throw new Exception("обращение к не параметру состояния смеси");
            }
        }
        public override double e         
        {
            get
            {
                if (gridType == GridType.mixtureState) return eValue;
                else throw new Exception("обращение к не параметру состояния смеси");
            }
            set
            {
                if (gridType == GridType.mixtureState) eValue = value;
                else throw new Exception("обращение к не параметру состояния смеси");
            }
        }
        public override double eps
        {
            get
            {
                if (gridType == GridType.mixtureState) return epsValue;
                else throw new Exception("обращение к не параметру состояния смеси");
            }
            set
            {
                if (gridType == GridType.mixtureState) epsValue = value;
                else throw new Exception("обращение к не параметру состояния смеси");
            }
        }
        public override double psi
        {
            get
            {
                if (gridType == GridType.mixtureState) return psiValue;
                else throw new Exception("обращение к не параметру состояния смеси");
            }
            set
            {
                if (gridType == GridType.mixtureState) psiValue = value;
                else throw new Exception("обращение к не параметру состояния смеси");
            }
        }
        public override double z
        {
            get
            {
                if (gridType == GridType.mixtureState) return zValue;
                else throw new Exception("обращение к не параметру состояния смеси");
            }
            set
            {
                if (gridType == GridType.mixtureState) zValue = value;
                else throw new Exception("обращение к не параметру состояния смеси");
            }
        }
        public override double a
        {
            get
            {
                if (gridType == GridType.mixtureState) return aValue;
                else throw new Exception("обращение к не параметру состояния смеси");
            }
            set
            {
                if (gridType == GridType.mixtureState) aValue = value;
                else throw new Exception("обращение к не параметру состояния смеси");
            }
        }
        public override double p
        {
            get
            {
                if (gridType == GridType.mixtureState) return pValue;
                else throw new Exception("обращение к не параметру состояния смеси");
            }
            set
            {
                if (gridType == GridType.mixtureState) pValue = value;
                else throw new Exception("обращение к не параметру состояния смеси");
            }
        }
        public override double ro
        {
            get
            {
                if (gridType == GridType.mixtureState) return roValue;
                else throw new Exception("обращение к не параметру состояния смеси");
            }
            set
            {
                if (gridType == GridType.mixtureState) roValue = value;
                else throw new Exception("обращение к не параметру состояния смеси");
            }
        }

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
