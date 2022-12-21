using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Printing;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComputerGraphics.HelperScripts
{
    public static class Transformations
    {
        // ref reprezentuje referenciu na value type (int, double, float, struct(Point)), čiže všetko čo nie je objekt a spraví si kopiu daného poinu v nasom pripade
        public static void CalculateMove(ref Point point, int vectorX, int vectorY)
        {
            point.X += vectorX;
            point.Y -= vectorY;
        }

        public static void CalculateRotation(ref Point point, double rotation)
        {
            double x = point.X;
            double y = point.Y;

            point.X = (x * Math.Cos(rotation)) - (y * Math.Sin(rotation));
            point.Y = (x * Math.Sin(rotation)) + (y * Math.Cos(rotation));
        }

        public static void CalculateScale(ref Point point, double scale)
        {
            point.X *= scale;
            point.Y *= scale;
        }

        public static void CalculateSkew(ref Point point, double skewX, double skewY)
        {
            double x = point.X;
            double y = point.Y;

            point.X = x + (skewX * y);
            point.Y = y + (skewY * x);
        }
    }
}
