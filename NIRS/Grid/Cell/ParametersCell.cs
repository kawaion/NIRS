using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Cell
{
    abstract class ParametersCell
    {
        public abstract double GetValueByString(string param);

        public abstract double dynamic_m { get; set; }
        public abstract double M { get; set; }
        public abstract double v { get; set; }
        public abstract double w { get; set; }
        public abstract double r { get; set; }
        public abstract double e { get; set; }
        public abstract double eps { get; set; }
        public abstract double psi { get; set; }
        public abstract double z { get; set; }
        public abstract double a { get; set; }
        public abstract double m { get; set; }
        public abstract double p { get; set; }
        public abstract double ro { get; set; }
        public abstract double delta { get; set; }
    }
}
