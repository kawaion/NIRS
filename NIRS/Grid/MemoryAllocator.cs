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
        public static void AllocateMemoryForDynamic(this List<List<DynamicCharacteristicsFlowCell>> dynamicGrid,int n, int k) 
        {
            while (dynamicGrid.Count <= n)
            {
                dynamicGrid.Add(new List<DynamicCharacteristicsFlowCell>());
            }
            while(dynamicGrid[n].Count <= k)
            {
                dynamicGrid[n].Add(new DynamicCharacteristicsFlowCell());
            }
        }
        public static void AllocateMemoryForMixture(this List<List<MixtureStateParametersCell>> mixtureGrid, int n, int k)
        {
            while (mixtureGrid.Count <= n)
            {
                mixtureGrid.Add(new List<MixtureStateParametersCell>());
            }
            while (mixtureGrid[n].Count <= k)
            {
                mixtureGrid[n].Add(new MixtureStateParametersCell());
            }
        }
    }
}
