using NIRS.ConstParams;
using NIRS.NablaFunctions;
using System;

namespace NIRS.Grid
{
    static class PseudoViscosityMechanism
    {
        public static double q(this TimeSpaceGrid grid, WaypointCalculator waypoint, double n, double k)
        {
            double NablaV = waypoint.Nabla("v", n, k);
            if (NablaV < 0)
            {
                return Math.Pow(Viscosity.mu0, 2) * Math.Pow(Step.h, 2) * grid[n + 0.5, k].ro * Math.Pow(NablaV, 2);
            }
            else
                return 0;
        }
    }
}
