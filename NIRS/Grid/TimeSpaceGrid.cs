using NIRS.Grid.Cell;
using NIRS.Grid.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Grid
{
    class TimeSpaceGrid
    {

        private List<SpaceGrid> spaceGrid;
        public TimeSpaceGrid()
        {
        }
        public SpaceGrid this[double n]
        {
            get
            {
                int index = NToIndex(n);
                return spaceGrid[index];
            }
            set
            {
                int index = NToIndex(n);
                spaceGrid[index]=value;
            }
        }
        private int NToIndex(double n) => (int)(n * 2);
    }
}
