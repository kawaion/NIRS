using NIRS.Grid;
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

        public FunctionsSEL(TimeSpaceGrid grid)
        {
            _grid = grid;
        }
        public double GetNextDynamic_m()
        {
            return _grid[n-0.5,k].dynamic_m-
        }
    }
}
