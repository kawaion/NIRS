using NIRS.Cell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Grid
{
    static class MemoryAllocator
    {
        public static void AllocateMemory(this List<List<DynamicCharacteristicsFlowCell>> grid,int n, int k) 
        {
            while (grid.Count <= n)
                grid.Add(new List<DynamicCharacteristicsFlowCell>());

            while (grid[n].Count <= k)
                grid[n].Add(new DynamicCharacteristicsFlowCell());
        }
        public static void AllocateMemory(this List<List<MixtureStateParametersCell>> grid, int n, int k)
        {
            while (grid.Count <= n)
                grid.Add(new List<MixtureStateParametersCell>());

            while (grid[n].Count <= k)
                grid[n].Add(new MixtureStateParametersCell());
        }
    }
}
