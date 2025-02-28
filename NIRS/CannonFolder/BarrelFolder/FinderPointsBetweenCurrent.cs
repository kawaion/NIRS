﻿using NIRS.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.BarrelFolder
{
    class FinderPointsBetweenCurrent
    {
        private readonly List<Point2D> _points;
        private int _iPenultimatePoint;

        public FinderPointsBetweenCurrent(List<Point2D> points)
        {
            _points = points;
            _iPenultimatePoint = points.Count-2;
    }
        public (Point2D, Point2D) Find(double x)
        {
            int i = _iPenultimatePoint;
            while (_points[i].X > x)
                i--;
            return (_points[i], _points[i + 1]);
        }
    }
}
