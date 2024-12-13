using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NIRS.Helper;

namespace NIRS.BarrelFolder
{
    internal class Barrel
    {
        private readonly List<Point2D> _points;
        private readonly Point2D _endChamber;
        private FinderPointsBetweenCurrent _pointsBetween;
        private Dictionary<Point2D, double> _VFromBottomBoreToPoint;
        public Barrel(List<Point2D> points, Point2D endChamber)
        {
            _points = points;
            _endChamber = endChamber;
            (_points, _endChamber) = MoverBottomBoreToZero.Move(_points, _endChamber);
            _pointsBetween = new FinderPointsBetweenCurrent(_points);
            _VFromBottomBoreToPoint = _points.CalcVBarrelPairs();
        }
        public double S(double x) => Math.Pow(R(x), 2) * Math.PI;
        public double V(double x)
        {
            (Point2D p1, Point2D p2) = _pointsBetween.Find(x);
            EquationOfLineFromTwoPoints equationOfLine = new EquationOfLineFromTwoPoints(p1, p2);
            double y = equationOfLine.Y(x);
            double VSegment = VBarrelParts.CalcVBarrelSegment(p1, new Point2D(x, y));
            return _VFromBottomBoreToPoint[p1] + VSegment;
        }
        public double V(double x1, double x2) => Math.Abs(V(x1) - V(x2));
        private double R(double x)
        {
            (Point2D p1, Point2D p2) = _pointsBetween.Find(x);
            EquationOfLineFromTwoPoints equationOfLine = new EquationOfLineFromTwoPoints(p1, p2);
            return equationOfLine.Y(x);
        }
    }
}
