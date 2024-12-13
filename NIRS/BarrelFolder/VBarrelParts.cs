using NIRS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.BarrelFolder
{
    static class VBarrelParts
    {
        public static Dictionary<Point2D, double> CalcVBarrelPairs(this List<Point2D> points)
        {
            Dictionary<Point2D, double> VParts = new Dictionary<Point2D, double>();
            double V = 0;
            for(int i = 1; i < points.Count; i++)
            {
                V += CalcVBarrelSegment(points[i - 1], points[i]);
                VParts.Add(points[i], V);
            }
            return VParts;
        }
        public static double CalcVBarrelSegment(Point2D p1 ,Point2D p2)
        {
            double h = Math.Abs(p2.X - p1.X);
            double r1 = p1.Y;
            double r2 = p2.Y;
            return 1.0 / 3 * Math.PI * h * (Math.Pow(r1, 2) + Math.Pow(r2, 2) + r1 * r2);
        }
    }
}
