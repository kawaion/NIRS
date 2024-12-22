using NIRS.CannonFolder;
using NIRS.ConstParams;
using NIRS.Grid;
using NIRS.Helper;
using NIRS.NablaFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.NumericalMethod
{
    class FunctionsShell
    {
        private TimeSpaceGrid _grid;
        private Cannon _cannon;
        private WaypointCalculatorForShell wcs;
        private MoreConvenientNotation mcn;

        public FunctionsShell(TimeSpaceGrid grid, Cannon cannon)
        {
            _grid = grid;
            _cannon = cannon;
            wcs = new WaypointCalculatorForShell(grid, cannon);
            mcn = new MoreConvenientNotation(grid, cannon);
        }
        public double Calc_v(double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 0.5, 0);
            return _grid.sn[n - 0.5].v + Step.tau 
                   / Shell.q * _grid.sn[n].p * _cannon.Barrel.S(_grid.sn[n].x);
        }
        public double Calc_x(double n)
        {
            if (n - (int)n == 0.5)
            {
                (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 0.5, 0);
                return _grid.sn[n - 0.5].x + Step.tau
                   * (_grid.sn[n-0.5].v + _grid.sn[n + 0.5].v)/2;
            }
            if (n - (int)n == 0)
            {
                (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 0.5, 0);
                return _grid.sn[n].x + Step.tau
                       *  _grid.sn[n + 0.5].v;
            }
            throw new Exception($"недопустимое время {n}");
        }
        public double Calc_r(double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 1, 0);
            return _grid.sn[n].r - Step.tau
                   / (_grid.sn[n].r*DiffVsnVk(n+0.5)-mcn.H3(n+0.5));
        }
        public double Calc_z(double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 1, 0);
            return _grid.sn[n].z + Step.tau * mcn.H5(n+0.5);
        }
        public double Calc_psi(double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 1, 0);
            return _grid.sn[n].psi + Step.tau * mcn.H5(n + 0.5);
        }
        public double Calc_a(double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 1, 0);
            return _grid.sn[n].a * _cannon.Barrel.S(_grid.sn[n].x) / _cannon.Barrel.S(_grid.sn[n+1].x)
                   * (1 - Step.tau * DiffVsnVk(n+0.5));
        }
        public double Calc_m(double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 1, 0);
            return 1 - _grid.sn[n+1].a * _cannon.Powder.LAMDA0 * (1- _grid.sn[n + 1].psi);
        }
        public double Calc_ro(double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 1, 0);
            return _grid.sn[n + 1].r 
                   /(_grid.sn[n + 1].m * _cannon.Barrel.S(_grid.sn[n + 1].x));
        }
        public double Calc_e(double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 1, 0);
            return _grid.sn[n].e - Step.tau 
                   * (_grid.sn[n].e*DiffVsnVk(n+0.5) +_grid.sn[n].p*(wcs.Nabla("mS","v",n+0.5) + wcs.Nabla("(1-m)S","w",n+0.5)) - mcn.H4(n+0.5));
        }
        public double Calc_p(double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 1, 0);
            return ConstPowder.teta * _grid.sn[n+1].e 
                  / (_grid.sn[n + 1].m * _cannon.Barrel.S(_grid.sn[n + 1].x)- ConstPowder.alpha * _grid.sn[n+1].r);
        }
        private double DiffVsnVk(double n)
        {
            return (_grid.sn[n].v - _grid[n, GetKPlusOne(n)].v)
                 / (_grid.sn[n].x - GetKPlusOne(n) * Step.h);
        }
        private double GetKPlusOne(double n)
        {
            return (int)(_grid.sn[n].x / (0.5*Step.h)) + 1;
        }
    }
}
