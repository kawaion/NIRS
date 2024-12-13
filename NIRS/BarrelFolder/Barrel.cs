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
        private readonly List<Point2D> _dots;
        private readonly Point2D _endChamber;
        private int _dotsCount;


        public Barrel(List<Point2D> dots, Point2D endChamber)
        {
            _dots = dots;
            _dotsCount = dots.Count;
            _endChamber = endChamber;
        }
        private 
        public double S(double x) => Math.Pow(GetR(x), 2) * Math.PI;

        private double GetR(double x)
        {
            int i = _dotsCount - 2;
            while (_dots[i].X > x)
                i--;
        }
    }
}
