using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab2.Ex
{
    public static class PointEx
    {
        public static Point Rotate(this Point point, Point centerPoint, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            return new Point
            {
                X =
                    (cosTheta * (point.X - centerPoint.X) -
                    sinTheta * (point.Y - centerPoint.Y) + centerPoint.X),
                Y =
                    (sinTheta * (point.X - centerPoint.X) +
                    cosTheta * (point.Y - centerPoint.Y) + centerPoint.Y)
            };
        }
    }
}
