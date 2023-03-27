using System;
using System.Windows;
using System.Windows.Controls;

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

        public static void CalculateMirror(ref Point point, int axis, Canvas canvas)
        {
            switch (axis)
            {
                case 0:
                    if (point.X > 0 && point.X <= canvas.Width)
                    {
                        if (point.X < canvas.Width / 2) point.X += 150;
                        else point.X -= 150;
                    }
                    else return;
                    break;
                case 1:
                    if (point.Y >= 0 && point.Y <= canvas.Height)
                    {
                        if (point.Y < canvas.Height / 2) point.Y += 150;
                        else point.Y -= 150;
                    }
                    else return;
                    break;
                default: break;
            }
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
