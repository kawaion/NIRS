using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Grid
{
    static class SetterGridType
    {
        public static GridType SetGridType(this double n)
        {
            if (IsHalfInt(n)) return GridType.dynamic;
            if (IsInt(n)) return GridType.mixtureState;
            throw new Exception($"невозможное значение индекса {n}");
        }
        private static bool IsInt(double x) => x - (int)x == 0;
        private static bool IsHalfInt(double x) => x - (int)x == 0.5;
    }
    enum GridType
    {
        dynamic,
        mixtureState
    }
}
