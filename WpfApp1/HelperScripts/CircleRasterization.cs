﻿using ComputerGraphics.MVVM.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Point = System.Windows.Point;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace ComputerGraphics.HelperScripts
{
    public static class CircleRasterization
    {
        public static List<Point> pointsList = new();
        public static string? output;
        public static List<string> outputStrings = new();

        public static void KartezianCoordinates(Point center, Canvas canvas, int radius)
        {
            int x, y;
            for (x = (int)center.X - radius; x <= center.X + radius; x++)
            {
                int _y = (int)center.Y + (int)Math.Round(Math.Sqrt(radius * radius - (x - center.X) * (x - center.X)));

                output = $"  y = {(int)center.Y} + ({radius * radius} - {x - center.X} * {x - center.X})^2";
                outputStrings.Add(output);

                SetPoint(x, _y);

                _y = (int)center.Y - (int)Math.Round(Math.Sqrt(radius * radius - (x - center.X) * (x - center.X)));

                output = $"  y = {(int)center.Y} - ({radius * radius} - {x - center.X} * {x - center.X})^2";
                outputStrings.Add(output);

                SetPoint(x, _y);
            }
            for (y = (int)center.Y - radius; y <= center.Y + radius; y++)
            {
                int _x = (int)center.X + (int)Math.Round(Math.Sqrt(radius * radius - (y - center.Y) * (y - center.Y)));

                output = $"  x = {(int)center.X} + ({radius * radius} - {y - center.Y} * {y - center.Y})^2";
                outputStrings.Add(output);

                SetPoint(_x, y);

                _x = (int)center.X - (int)Math.Round(Math.Sqrt(radius * radius - (y - center.Y) * (y - center.Y)));

                output = $"  x = {(int)center.X} - ({radius * radius} - {y - center.Y} * {y - center.Y})^2";
                outputStrings.Add(output);

                SetPoint(x, y);
            }
            SetPixel(canvas);
        }

        public static void PolarCoordinates(Point center, Canvas canvas, int radius)
        {
            for (int i = 0; i < 360; i++)
            {
                double radians = i * Math.PI / 180.0;
                int x = (int)(center.X + (radius * Math.Cos(radians)));
                int y = (int)(center.Y + (radius * Math.Sin(radians)));

                output = $"  X: {x}, Y: {y}";
                outputStrings.Add(output);

                SetPoint(x, y);
            }
            SetPixel(canvas);
        }

        public static void BersenhamCircle(Point center, Canvas canvas, int radius)
        {
            var x = 0;
            var y = radius;
            int d = 3 - 2 * radius;

            while (x <= y)
            {
                SetPoint(x + center.X, y + center.Y);
                SetPoint(y + center.X, x + center.Y);
                SetPoint(-x + center.X, y + center.Y);
                SetPoint(-y + center.X, x + center.Y);
                SetPoint(-x + center.X, -y + center.Y);
                SetPoint(-y + center.X, -x + center.Y);
                SetPoint(x + center.X, -y + center.Y);
                SetPoint(y + center.X, -x + center.Y);

                output = $"  Stredový bod: ({center.X}, {center.Y}), X: {x} , Y: {y}";
                outputStrings.Add(output);

                if (d < 0) d = d + 4 * (x - y) + 6;
                else
                {
                    d = d + 4 * (x - y) + 10;
                    y--;
                    
                }
                x++;
            }
            SetPixel(canvas);
        }

        private static void SetPixel(Canvas canvas)
        {
            Point point;
            Rectangle rectangle;

            for (int i = 0; i < pointsList.Count; i++)
            {
                point = pointsList[i];

                foreach (var rec in LectureFiveView._rects)
                {
                    int indexOfRect = LectureFiveView._rects.IndexOf(rec);

                    if (rec.Contains(point) && point.X >= 0 && point.X <= canvas.Width && point.Y >= 0 && point.Y <= canvas.Height)
                    {
                        rectangle = LectureFiveView._rectangles[indexOfRect];
                        rectangle.Fill = new SolidColorBrush(Colors.DarkGray);
                    }
                }
            }
        }

        public static void SetPoint(double pixelX, double pixelY)
        {
            Point point = new(pixelX, pixelY);
            pointsList.Add(point);
        }
    }
}
