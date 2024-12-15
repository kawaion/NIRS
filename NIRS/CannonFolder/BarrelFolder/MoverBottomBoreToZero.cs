using NIRS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.BarrelFolder
{
    static class MoverBottomBoreToZero
    {
        public static (List<Point2D> points, Point2D endChamber) Move(List<Point2D> points, Point2D endChamber)
        {
            double bottomBore = points[0].X;
            if (bottomBore != 0)
            {
                endChamber.ChangeX(endChamber.X - bottomBore);
                foreach (var point in points)
                    point.ChangeX(point.X - bottomBore);
            }
            return (points, endChamber);
        }
    }
}
