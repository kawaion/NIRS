using NIRS.BarrelFolder;
using NIRS.ConstParams;
using NIRS.Grid;
using NIRS.Cell;
using System;
using System.Linq;


namespace NIRS.NablaFunctions
{
    class WaypointCalculator
    {
        private readonly TimeSpaceGrid _grid;
        private readonly Barrel _barrel;

        /// <summary>
        /// для удобной работы с наблой необходимо передать ссылку на сетку с данными.
        /// </summary>
        public WaypointCalculator(TimeSpaceGrid grid, Cannon cannon)
        {
            _grid = grid;
            _barrel = cannon;
        }
        public double nabla(string param1, string v,double n, double k)
        {
            if (IsHalfInt(n) && IsInt(k))
                return (DynamicAverage(param1, v, n, k + 0.5) - DynamicAverage(param1, v, n, k - 0.5)) / Step.h;
            if (IsHalfInt(n) && IsHalfInt(k))
                return (OffsetAverage(param1, v, n, k + 0.5) - OffsetAverage(param1, v, n, k - 0.5)) / Step.h;

            throw new Exception($"неизвестные параметры {param1} и {v} на слое {n} {k}");
        }
        private double DynamicAverage(string mu, string v, double n, double k)
        {
            double sum_v = GetParamCell(v, n, k - 0.5) + GetParamCell(v, n, k + 0.5);
            if (sum_v >= 0)
                return sum_v / 2 * GetParamCell(mu, n, k - 0.5);
            else
                return sum_v / 2 * GetParamCell(mu, n, k + 0.5);
        }
        private double OffsetAverage(string fi, string V, double n, double k)
        {
            double v = GetParamCell(V, n, k);
            if (v >= 0)
                return GetParamCell(fi, n - 0.5, k - 0.5) * v;
            else
                return GetParamCell(fi, n - 0.5, k + 0.5) * v;
        }
        public double nabla(string v, double n, double k)
        {
            if (IsHalfInt(n) && IsHalfInt(k))
                return (GetParamCell(v, n, k + 0.5) - GetParamCell(v, n, k - 0.5)) / Step.h;
            throw new Exception($"неизвестный параметр {v} на слое {n} {k}");
        }
        public double dDivdx(string param, double n, double k)
        {
            if(IsInt(n) && IsInt(k))
                return (GetParamCell(param, n, k + 0.5) - GetParamCell(param, n, k - 0.5)) / Step.h;

            throw new Exception($"неизвестный параметр {param} на слое {n} {k}");
        }
        private double GetParamCell(string param,double n, double k)
        {
            if(_grid[n, k] is DynamicCharacteristicsFlowCell dynamicCell)
                return dynamicCell.GetValueByString(param);
            if (_grid[n, k] is OffsetStateParametersCell OffsetCell)
                return OffsetCell.GetValueByString(param);
            if (param.Last() == 'S')
                return GetParamCell(param.Substring(0,param.Length-1),n,k) * _barrel.S(k * Step.h);
            if (param == "pStroke")
                return GetParamCell("p", n, k) + GetParamCell("q", n - 0.5, k);
            if(param== "q")
                return _grid.q(this, n, k);
            if (param == "1-m")
                return 1-_grid[n, k].m;
            throw new Exception($"неизвестное значение {param}");
        }
        private bool IsInt(double d) => ((d - (int)d) % 2 == 0);
        private bool IsHalfInt(double d) => ((d - (int)d) % 2 == 0.5);
    }
}
