using ComputerGraphics.MVVM.View;
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

        public static void KartezianCoordinates(Point center, Canvas canvas, int radius)
        {
            for (int x = (int)center.X - radius; x <= center.X + radius; x++)
            {
                int y = (int)center.Y + (int)Math.Round(Math.Sqrt(radius * radius - (x - center.X) * (x - center.X)));
                SetPoint(x, y);
                SetPixel(canvas, x, (int)y);

                y = (int)center.Y - (int)Math.Round(Math.Sqrt(radius * radius - (x - center.X) * (x - center.X)));
                SetPoint(x, y);
                SetPixel(canvas, x, y);
                Debug.WriteLine($"{x} , {y}");
            }
            for (int y = (int)center.Y - radius; y <= center.Y + radius; y++)
            {
                int x = (int)center.X + (int)Math.Round(Math.Sqrt(radius * radius - (y - center.Y) * (y - center.Y)));
                SetPoint(x, y);
                SetPixel(canvas, x, y);

                x = (int)center.X - (int)Math.Round(Math.Sqrt(radius * radius - (y - center.Y) * (y - center.Y)));
                SetPoint(x, y);
                SetPixel(canvas, x, y);
                Debug.WriteLine($"{x} , {y}");
            }
        }

        public static void PolarCoordinates(Point center, Canvas canvas, int radius)
        {
            for (int i = 0; i < 360; i++)
            {
                double radians = i * Math.PI / 180.0;
                var x = center.X + (radius * Math.Cos(radians));
                var y = center.Y + (radius * Math.Sin(radians));

                Debug.WriteLine($"{x} , {y}");

                SetPoint(x, y);

                SetPixel(canvas, (int)x, (int)y);
            }
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

                SetPixel(canvas, x, y);

                Debug.WriteLine($"{center.X}, {center.Y}, {x} , {y}");

                if (d < 0)  d = d + 4 * x + 6;
                else
                {
                    d = d + 4 * (x - y) + 10;
                    y--;
                }
                x++;
            }
        }

        private static void SetPixel(Canvas canvas, int x, int y)
        {
            Point point;
            Rectangle rectangle;

            for (int i = 0; i < pointsList.Count; i++)
            {
                point = pointsList[i];

                foreach (var rec in LectureFiveView._rects)
                {
                    int indexOfRect = LectureFiveView._rects.IndexOf(rec);

                    if (rec.Contains(point) && x >= 0 && x < canvas.Width && y >= 0 && y < canvas.Height)
                    {
                        rectangle = LectureFiveView._rectangles[indexOfRect];
                        rectangle.Fill = new SolidColorBrush(Colors.DarkGray);
                    }
                }
            }
        }

        public static void SetPoint(double pixelX, double pixelY)
        {
            Point point;

            point = new(pixelX, pixelY);
            pointsList.Add(point);
        }
    }
}
