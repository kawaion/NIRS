using NIRS.CannonFolder;
using NIRS.ConstParams;
using NIRS.Grid;
using NIRS.Grid.Shell;
using NIRS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.NablaFunctions
{
    class WaypointCalculatorForShell
    {
        private readonly WaypointCalculator _standartWaypointCalculator;
        private readonly TimeSpaceGrid _grid;
        private readonly Cannon _cannon;
        public WaypointCalculatorForShell(TimeSpaceGrid grid, Cannon cannon, WaypointCalculator standartWaypointCalculator)
        {
            _grid = grid;
            _cannon = cannon;
            _standartWaypointCalculator = standartWaypointCalculator;
        }

        public double Nabla(string param1, string v, double n)
        {
            return (paramAverageSn(param1, v, n) - paramAverageK(param1, v, n)) / Step.h;
        }
        private double paramAverageSn(string param1, string v, double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 0.5, 0);
            return GetParamCell(v, n + 0.5) * GetParamCell(param1, n);
        }
        private double paramAverageK(string param1, string v, double n)
        {
            (n, _) = OffsetNK.Appoint(n, 0).Offset(n + 0.5, 0);
            return GetParamCell(v, n + 0.5) * GetParamCell(param1, n);
        }

        public double Nabla(string v, double n)
        {
            throw new NotImplementedException();
        }
        private double GetParamCell(string param, double n)
        {
            if (param == "(1-m)")
                return 1 - _grid.sn[n].m;
            if (param.Last() == 'S')
                return GetParamCell(param.Substring(0, param.Length - 1), n) * _cannon.Barrel.S(_grid.sn[n].x);

            return _grid.sn[n].GetValueByString(param);

            throw new Exception($"неизвестное значение {param}");
        }
    }
}
