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
            return _grid[n - 0.5].sn.v + Step.tau 
                   / Shell.q * _grid[n].sn.p * _cannon.Barrel.S(_grid[n].sn.x);
        }
        public double Calc_x(double n)
        {
            if (n - (int)n == 0.5)
            {
                (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 0.5, 0);
                return _grid[n - 0.5].sn.x + Step.tau
                   * (_grid[n-0.5].sn.v + _grid[n + 0.5].sn.v)/2;
            }
            if (n - (int)n == 0)
            {
                (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 0.5, 0);
                return _grid[n].sn.x + Step.tau
                       *  _grid[n + 0.5].sn.v;
            }
            throw new Exception($"недопустимое время {n}");
        }
        public double Calc_r(double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 1, 0);
            return _grid[n].sn.r - Step.tau
                   / (_grid[n].sn.r*DiffVsnVk(n+0.5)-mcn.H3(n+0.5));
        }
        public double Calc_z(double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 1, 0);
            return _grid[n].sn.z + Step.tau * mcn.H5(n+0.5);
        }
        public double Calc_psi(double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 1, 0);
            return _grid[n].sn.psi + Step.tau * mcn.H5(n + 0.5);
        }
        public double Calc_a(double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 1, 0);
            return _grid[n].sn.a * _cannon.Barrel.S(_grid[n].sn.x) / _cannon.Barrel.S(_grid[n+1].sn.x)
                   * (1 - Step.tau * DiffVsnVk(n+0.5));
        }
        public double Calc_m(double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 1, 0);
            return 1 - _grid[n+1].sn.a * _cannon.Powder.LAMDA0 * (1- _grid[n + 1].sn.psi);
        }
        public double Calc_ro(double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 1, 0);
            return _grid[n + 1].sn.r 
                   /(_grid[n + 1].sn.m * _cannon.Barrel.S(_grid[n + 1].sn.x));
        }
        public double Calc_e(double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 1, 0);
            return _grid[n].sn.e - Step.tau 
                   * (_grid[n].sn.e*DiffVsnVk(n+0.5) +_grid[n].sn.p*(wcs.Nabla("mS","v",n+0.5) + wcs.Nabla("(1-m)S","w",n+0.5)) - mcn.H4(n+0.5));
        }
        public double Calc_p(double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 1, 0);
            return ConstPowder.teta * _grid[n+1].sn.e 
                  / (_grid[n + 1].sn.m * _cannon.Barrel.S(_grid[n + 1].sn.x)- ConstPowder.alpha * _grid[n+1].sn.r);
        }
        private double DiffVsnVk(double n)
        {
            return (_grid[n].sn.v - _grid[n][GetKPlusOne(n)].v)
                 / (_grid[n].sn.x - GetKPlusOne(n) * Step.h);
        }
        private double GetKPlusOne(double n)
        {
            return (int)(_grid[n].sn.x / (0.5*Step.h)) + 1;
        }
    }
}
