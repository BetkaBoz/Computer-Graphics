using Accessibility;
using ComputerGraphics.MVVM.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ComputerGraphics.HelperScripts
{
    public static class LineRasterization
    {
        public static List<Point> newPoints = new();
        public static string? output;
        public static List<string> outputStrings = new();

        public static async void BaseLine(List<Point> pointsList)
        {
            newPoints.Clear();
            outputStrings.Clear();

            int x1 = (int)pointsList[0].X;
            int x2 = (int)pointsList[1].X;
            int y1 = (int)pointsList[0].Y;
            int y2 = (int)pointsList[1].Y;

            int pointX = x2 - x1;
            int pointY = y2 - y1;
            int decison = 2 * pointY - pointX;
            int y = y1;

            for (int x = x1 + 1; x <= x2; x++)
            {
                // E -> east is chosen
                if (decison > 0)
                {
                    y++;
                    newPoints.Add(new Point(x, y));
                    decison += 2 * (pointY - pointX);
                }
                // NE -> north east is chosen
                else
                {
                    newPoints.Add(new Point(x, y));
                    decison += 2 * pointY;
                }
                output = $"  X: {x}, Y: {y}";
                outputStrings.Add(output);
            }
            await FindPoint();
        }

        public static async void DDALine(List<Point> pointsList)
        {
            newPoints.Clear();
            outputStrings.Clear();

            double pointX = pointsList[1].X - pointsList[0].X;
            double pointY = pointsList[1].Y - pointsList[0].Y;

            // calculate the step size for x and y
            double steps = Math.Max(Math.Abs(pointX), Math.Abs(pointY));
            double stepX = pointX / steps;
            double stepY = pointY / steps;

            // starting coordinates
            double x = pointsList[0].X;
            double y = pointsList[0].Y;

            // draw the line
            for (int i = 0; i < steps; i++)
            {
                x += stepX;
                y += stepY * (pointY / pointX);

                newPoints.Add(new Point(x, y));
                output = $"  X: {x}, Y: {y}";
                outputStrings.Add(output);
            }
            await FindPoint();
        }

        public static async void BersenhamLine(List<Point> pointsList, int pointX, int pointY, int decide)
        {
            newPoints.Clear();
            outputStrings.Clear();

            int x1 = (int)pointsList[0].X;
            int x2 = (int)pointsList[1].X;
            int y1 = (int)pointsList[0].Y;
            int y2 = (int)pointsList[1].Y;

            // delta
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);

            int sx = x1 < x2 ? 1 : -1;
            int sy = y1 < y2 ? 1 : -1;

            int err = dx - dy;

            while (x1 != x2 || y1 != y2)
            {
                newPoints.Add(new Point(x1, y1));
                output = $"  X: {x1}, Y: {y1}";
                outputStrings.Add(output);

                int e2 = 2 * err;

                if (e2 > -dy)
                {
                    err -= dy;
                    x1 += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y1 += sy;
                }
            }

            await FindPoint();
        }

        public static async Task FindPoint()
        {
            await Task.Delay(150);

            Point point;
            Rectangle rectangle;

            for(int i = 0; i < newPoints.Count; i++)
            {
                point = newPoints[i];

                foreach (var rec in LectureFourView._rects)
                {
                    int indexOfRect = LectureFourView._rects.IndexOf(rec);

                     if (rec.Contains(point))
                     {
                        Application.Current.Dispatcher.Invoke(() => { }, DispatcherPriority.Background);

                        rectangle = LectureFourView._rectangles[indexOfRect];
                        rectangle.Fill = new SolidColorBrush(Colors.DarkGray);
                     }
                }
            }
        }
    }
}
