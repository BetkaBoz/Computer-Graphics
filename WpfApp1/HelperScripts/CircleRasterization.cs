using ComputerGraphics.MVVM.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ComputerGraphics.HelperScripts
{
    public static class CircleRasterization
    {
        public static List<Point> pointsList = new();

        public static void KartezianCoordinates(Point center, int radius)
        {
            for (int x = 0; x < radius; x++)
            {
                double y = Math.Round(Math.Sqrt(Math.Sqrt(radius) - Math.Sqrt(center.X)));
                FindPoint(center.X, center.Y, (double)x, y);
            }
        }

        public static void PolarCoordinates(Point center, int radius)
        {
            int step, counter = 0;
            double x, y;

            step = 1 / radius;
            do
            {
                x = Math.Round(radius * Math.Cos(counter));
                y = Math.Round(radius * Math.Sin(counter));

                FindPoint(center.X, center.Y, x, y);

                counter += step;
            }
            while (x == y);

            Debug.WriteLine($"{center.X}, {center.Y}, {x} , {y}");
        }

        public static void BersenhamCircle(Point center, int radius)
        {
            var x = 0;
            var y = radius;
            var deltaX = 3;
            var deltaY = 2 * radius - 2;
            int p = 1 - radius;

            do
            {
                FindPoint(center.X, center.Y, x, y);

                if (p >= 0)
                {
                    p -= deltaY;
                    deltaY -= 2;
                    y -= 1;
                }
                p += deltaX;
                deltaX += 2;
                x += 1;
            }
            while (x > y);

            Debug.WriteLine($"{center.X}, {center.Y}, {x} , {y}"); 
        }

        public static void FindPoint(double xCenter, double yCenter, double x, double y)
        {
            Point point;
            Rectangle rectangle;

            pointsList.Clear();

            point = new(xCenter + x, yCenter + y);
            pointsList.Add(point);

            point = new(xCenter - x, yCenter + y);
            pointsList.Add(point);

            point = new(xCenter + x, yCenter - y);
            pointsList.Add(point);

            point = new(xCenter - x, yCenter - y);
            pointsList.Add(point);

            point = new(xCenter + y, yCenter + x);
            pointsList.Add(point);

            point = new(xCenter - y, yCenter + x);
            pointsList.Add(point);

            point = new(xCenter + y, yCenter - x);
            pointsList.Add(point);

            point = new(xCenter - y, yCenter + x);
            pointsList.Add(point);

            for (int i = 0; i < pointsList.Count; i++)
            {
                point = pointsList[i];

                foreach (var rec in LectureFiveView._rects)
                {
                    int indexOfRect = LectureFiveView._rects.IndexOf(rec);

                    if (rec.Contains(point))
                    {
                        rectangle = LectureFiveView._rectangles[indexOfRect];
                        rectangle.Fill = new SolidColorBrush(Colors.DarkGray);
                    }
                }
            }
        }
    }
}
