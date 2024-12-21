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
            _VFromBottomBoreToPoint = _points.CalcWBarrelPairs();
            Skn = S(_points[0].X);
            Wkm = W(_endChamber.X);
        }
        public double Skn;
        public double Wkm;
        public double S(double x) => Math.Pow(R(x), 2) * Math.PI;
        public double W(double x)
        {
            (Point2D p1, Point2D p2) = _pointsBetween.Find(x);
            EquationOfLineFromTwoPoints equationOfLine = new EquationOfLineFromTwoPoints(p1, p2);
            double y = equationOfLine.Y(x);
            double VSegment = WBarrelParts.CalcWBarrelSegment(p1, new Point2D(x, y));
            return _VFromBottomBoreToPoint[p1] + VSegment;
        }
        public double W(double x1, double x2) => Math.Abs(W(x1) - W(x2));
        public double D(double x) => 2 * R(x);
        private double R(double x)
        {
            (Point2D p1, Point2D p2) = _pointsBetween.Find(x);
            EquationOfLineFromTwoPoints equationOfLine = new EquationOfLineFromTwoPoints(p1, p2);
            return equationOfLine.Y(x);
        }
    }
}
