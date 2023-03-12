using Accessibility;
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
    public static class LineRasterization
    {
        public static List<Point> newPoints = new();

        public static void BaseLine(List<Point> pointsList)
        {
            newPoints.Clear();

            //int pointX = (int)(pointsList[1].X - pointsList[0].X);
            //int pointY = (int)(pointsList[1].Y - pointsList[0].Y);

            //int decision = pointY - (pointX / 2);

            //int x = (int)pointsList[0].X;
            //int y = (int)pointsList[0].Y;

            //while (x < (int)pointsList[1].X)
            //{
            //    x++;
            //    // E > east is chosen
            //    if (decision < 0) decision += pointY;

            //    // NE > north east is chosen
            //    else
            //    {
            //        decision += (pointY - pointX);
            //        y++;
            //    }

            //    newPoints.Add(new Point(x, y));
            //}

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
            }

            FindPoint();
        }

        public static void DDALine(List<Point> pointsList)
        {
            newPoints.Clear();

            double pointX = pointsList[1].X - pointsList[0].X;
            double pointY = pointsList[1].Y - pointsList[0].Y;

            // determine the number of steps required to draw the line
            double steps = Math.Max(Math.Abs(pointX), Math.Abs(pointY));

            // calculate the increment values for x and y
            int xIncrement = (int)(pointX / steps);
            int yIncrement = (int)(pointY / steps);

            // set the starting coordinates
            int x = (int)pointsList[0].X;
            int y = (int)pointsList[0].Y;

            // draw the points line
            for (int i = 0; i < steps; i++)
            {
                x += xIncrement;
                y += yIncrement;

                newPoints.Add(new Point(x, y));
            }
            FindPoint();
        }

        public static void BersenhamLine(List<Point> pointsList, int pointX, int pointY, int decide)
        {
            newPoints.Clear();

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

            FindPoint();
        }

        public static void FindPoint()
        {
            Point point;
            Rectangle rectangle;

            for(int i = 0; i < newPoints.Count; i++)
            {
                point = newPoints[i];

                foreach (var rec in LectureFourView._rects)
                {
                    int indexOfRect = LectureFourView._rects.LastIndexOf(rec);

                     if (rec.Contains(point))
                     {
                        rectangle = LectureFourView._rectangles[indexOfRect];
                        rectangle.Fill = new SolidColorBrush(Colors.DarkGray);
                     }
                }
            }
        }
    }
}
