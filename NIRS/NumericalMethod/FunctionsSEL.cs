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
    class FunctionsSEL
    {
        private readonly TimeSpaceGrid _grid;
        private readonly Cannon _cannon;

        private WaypointCalculator wc;
        private MoreConvenientNotation mcn;
        public FunctionsSEL(TimeSpaceGrid grid, Cannon cannon)
        {
            _grid = grid;
            _cannon = cannon;
            wc = new WaypointCalculator(grid, cannon);
            mcn = new MoreConvenientNotation(grid, cannon);
        }
        public double Calc_dynamic_m(double n, double k)
        {
            (n, k) = OffsetNK.Appoint(n, k).Offset(n+0.5, k);
            return _grid[n - 0.5, k].dynamic_m - Step.tau *
                (
                    wc.Nabla("dynamic_m", "v", n - 0.5, k)
                   + (_grid[n, k - 0.5].m * _cannon.Barrel.S((k - 0.5) * Step.h) + _grid[n, k + 0.5].m * _cannon.Barrel.S((k + 0.5) * Step.h))/2*wc.dDivdx("pStroke",n,k)
                   - mcn.H1(n,k)
                );        
        }
        public double Calc_v(double n, double k)
        {
            (n, k) = OffsetNK.Appoint(n, k).Offset(n + 0.5, k);
            return 2 * _grid[n + 0.5, k].dynamic_m / (_grid[n, k - 0.5].r + _grid[n, k + 0.5].r);
        }
        public double Calc_M(double n, double k)
        {
            (n, k) = OffsetNK.Appoint(n, k).Offset(n + 0.5, k);
            return _grid[n - 0.5, k].M - Step.tau *
                (
                    wc.Nabla("M", "w", n - 0.5, k)
                   + ((1-_grid[n, k - 0.5].m) * _cannon.Barrel.S((k - 0.5) * Step.h) + (1-_grid[n, k + 0.5].m) * _cannon.Barrel.S((k + 0.5) * Step.h)) / 2 * wc.dDivdx("pStroke", n, k)
                   - mcn.H2(n, k)
                );
        }
        public double Calc_w(double n, double k)
        {
            (n, k) = OffsetNK.Appoint(n, k).Offset(n + 0.5, k);
            return 2 * _grid[n + 0.5, k].M / (_grid[n, k - 0.5].delta + _grid[n, k + 0.5].delta);
        }
        public double Calc_r(double n, double k)
        {
            (n, k) = OffsetNK.Appoint(n, k).Offset(n + 1, k-0.5);
            return _grid[n, k-0.5].M - Step.tau *
                (
                    wc.Nabla("r", "v", n + 0.5, k - 0.5)
                   - mcn.H3(n+0.5, k-0.5)
                );
        }
        public double Calc_e(double n, double k)
        {
            (n, k) = OffsetNK.Appoint(n, k).Offset(n + 1, k - 0.5);
            return _grid[n, k - 0.5].e - Step.tau *
                (
                    wc.Nabla("e", "v", n + 0.5, k - 0.5)
                   + (_grid[n+0.5,k-0.5].p+_grid.q(wc,n+0.5,k-0.5))*(wc.Nabla("mS","w",n+0.5,k-0.5)+ wc.Nabla("(1-m)S", "w", n + 0.5, k - 0.5))
                   - mcn.H4(n + 0.5, k - 0.5)
                );
        }
        public double Calc_psi(double n, double k)
        {
            (n, k) = OffsetNK.Appoint(n, k).Offset(n + 1, k - 0.5);
            return _grid[n, k - 0.5].psi - Step.tau *
                (
                    wc.Nabla("psi", "w", n + 0.5, k - 0.5)
                   - _grid[n + 0.5, k - 0.5].psi * wc.Nabla("w", n + 0.5, k - 0.5)
                   - mcn.H5(n + 0.5, k - 0.5)
                );
        }
        public double Calc_a(double n, double k)
        {
            (n, k) = OffsetNK.Appoint(n, k).Offset(n + 1, k - 0.5);
            return _grid[n, k - 0.5].a - Step.tau *
                (
                    wc.Nabla("aS", "w", n + 0.5, k - 0.5)/_cannon.Barrel.S((k-0.5)*Step.h)
                );
        }
        public double Calc_p(double n, double k)
        {
            (n, k) = OffsetNK.Appoint(n, k).Offset(n + 1, k - 0.5);
            return ConstPowder.teta * _grid[n + 1, k - 0.5].e /
                (_grid[n + 1, k - 0.5].m * _cannon.Barrel.S((k - 0.5) * Step.h) - ConstPowder.alpha * _grid[n + 1, k - 0.5].r);
        }
    }
}
