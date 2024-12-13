﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIRS.Helper
{
    class Point2D
    {
        public Point2D(double x,double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; private set; }
        public double Y { get; }

        public void ChangeX(double x) => X = x;
    }
}
