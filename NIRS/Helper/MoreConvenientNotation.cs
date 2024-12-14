using NIRS.BarrelFolder;
using NIRS.ConstParams;
using NIRS.Grid;
using System;

namespace NIRS.Helper
{
    class MoreConvenientNotation
    {
        private readonly TimeSpaceGrid _grid;
        private readonly Barrel _barrel;

        public MoreConvenientNotation(TimeSpaceGrid grid, Barrel barrel )
        {
            _grid = grid;
            _barrel = barrel;
        }
        public double r(double n, double k) => _grid[n, k].ro * _grid[n, k].m * _barrel.S(k * Step.h);
        public double dynamic_m(double n, double k) => _grid[n, k].ro * _grid[n, k].m * _barrel.S(k * Step.h) * _grid[n, k].v;
        public double e(double n, double k) => _grid[n, k].ro * _grid[n, k].m * _barrel.S(k * Step.h) * _grid[n, k].eps;
        public double delta(double n, double k) => _grid[n, k].delta_m * (1-_grid[n, k].m) * _barrel.S(k * Step.h);
        public double M(double n, double k) => _grid[n, k].delta_m * (1 - _grid[n, k].m) * _barrel.S(k * Step.h) * _grid[n,k].w;


        public double H1(double n, double k) => -_barrel.S(k * Step.h) * tauW(n, k) + _barrel.S(k * Step.h) * G(n, k) * _grid[n - 0.5, k].w;
        private double tauW(double n, double k)
        {
            double diff_v_w = _grid[n - 0.5, k].v - _grid[n - 0.5, k].w;
            return Koefs.lamda0*(_grid[n,k-0.5].ro*diff_v_w * Math.Abs(diff_v_w))/2 * _grid[n, k - 0.5].a*//доделать после создания класса пороха
        }

    }
}
