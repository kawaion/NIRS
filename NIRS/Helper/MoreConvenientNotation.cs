using NIRS.CannonFolder;
using NIRS.ConstParams;
using NIRS.Grid;
using System;

namespace NIRS.Helper
{
    class MoreConvenientNotation
    {
        private readonly TimeSpaceGrid _grid;
        private readonly Cannon _cannon;

        public MoreConvenientNotation(TimeSpaceGrid grid, Cannon cannon )
        {
            _grid = grid;
            _cannon = cannon;
        }
        public double r(double n, double k) => _grid[n, k].ro * _grid[n, k].m * _cannon.Barrel.S(k * Step.h);
        public double dynamic_m(double n, double k) => _grid[n, k].ro * _grid[n, k].m * _cannon.Barrel.S(k * Step.h) * _grid[n, k].v;
        public double e(double n, double k) => _grid[n, k].ro * _grid[n, k].m * _cannon.Barrel.S(k * Step.h) * _grid[n, k].eps;
        public double DELTA(double n, double k) => _grid[n, k].delta * (1-_grid[n, k].m) * _cannon.Barrel.S(k * Step.h);
        public double M(double n, double k) => _grid[n, k].delta * (1 - _grid[n, k].m) * _cannon.Barrel.S(k * Step.h) * _grid[n,k].w;


        public double H1(double n, double k) => -_cannon.Barrel.S(k * Step.h) * tauW(n, k) + _cannon.Barrel.S(k * Step.h) * G(n, k) * _grid[n - 0.5, k].w;
        public double H2(double n, double k) => _cannon.Barrel.S(k * Step.h) * tauW(n, k) - _cannon.Barrel.S(k * Step.h) * G(n, k) * _grid[n - 0.5, k].w;
        public double H3(double n, double k) => _cannon.Barrel.S(k * Step.h) * G(n-0.5, k+0.5);
        public double H4(double n, double k) 
        {
            double diff_v_w = _grid[n, k + 0.5].v - _grid[n, k + 0.5].w;
            return _cannon.Barrel.S(k * Step.h) * G(n - 0.5, k + 0.5)*(ConstPowder.Q+Math.Pow(diff_v_w,2)/2)+ _cannon.Barrel.S(k * Step.h)*tauW(n+0.5,k+0.5)*diff_v_w; 
        }
        public double H5(double n, double k) => _cannon.Powder.KappaP / _cannon.Powder.e1 * _cannon.Powder.Sigma(_grid[n - 0.5, k].z, _grid[n - 0.5, k].psi) * _cannon.Powder.Uk(_grid[n - 0.5, k].p);
        private double tauW(double n, double k)
        {
            double diff_v_w = _grid[n - 0.5, k].v - _grid[n - 0.5, k].w;
            return Koefs.lamda0 * (_grid[n, k - 0.5].ro * diff_v_w * Math.Abs(diff_v_w)) / 2 
                   * _grid[n, k - 0.5].a * (_cannon.Powder.S0 * _cannon.Powder.Sigma(_grid[n, k - 0.5].z, _grid[n, k - 0.5].psi)) / 4;
        }
        private double G(double n, double k)
        {
            return _grid[n, k - 0.5].a * _cannon.Powder.S0 * _cannon.Powder.Sigma(_grid[n, k - 0.5].z, _grid[n, k - 0.5].psi)*_grid[n,k].delta*_cannon.Powder.Uk(_grid[n,k-0.5].p);
        }

    }
}
