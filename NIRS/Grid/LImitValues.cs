using NIRS.CannonFolder;
using NIRS.ConstParams;
using NIRS.Grid.Cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Grid
{
    class LImitValues
    {
        private TimeSpaceGrid _grid;
        private readonly Cannon _cannon;

        public LImitValues(TimeSpaceGrid grid, Cannon cannon)
        {
            _grid = grid;
            _cannon = cannon;
        }
        public void InitializeZeroTimeSpace(double x)
        {
            int Kstroke = (int)(x / Step.h + 1);//разобраться с K
            double p = (0.3 * ConstPowder.omega_v * ConstPowder.f)
                         / (_cannon.Barrel.Wkm - ConstPowder.omega / ConstPowder.delta - ConstPowder.alpha * ConstPowder.omega_v);
            double ro = p / (ConstPowder.alpha * p + ConstPowder.f);
            double eps = ConstPowder.f / ConstPowder.teta;
            double z = 0;
            double psi = 0;
            double DELTA = ConstPowder.omega / _cannon.Barrel.Wkm;
            double m = 1 - DELTA / ConstPowder.delta;
            double a = ConstPowder.omega / (_cannon.Powder.LAMDA0);
            for(int k = 1; k <= Kstroke; k++)
            {
                double r = ro * m * _cannon.Barrel.S((k - 0.5) * Step.h);
                double e = ro * m * _cannon.Barrel.S((k - 0.5) * Step.h) * eps;
                MixtureStateParametersCell cell = new MixtureStateParametersCell(r, e, eps, psi, z, a, m, p, ro);
                _grid[0][k - 0.5] = cell;
            }
        }
        public void InitializeLimitSpace(double n, double x)
        {
            int Kstroke = (int)(x / Step.h);
            _grid[n][0] = DynamicCharacteristicsFlowCell.GetZeroCell();
            _grid[n][Kstroke] = DynamicCharacteristicsFlowCell.GetZeroCell();
        }
    }
}
