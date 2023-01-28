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
            int pointX = (int)(pointsList[1].X - pointsList[0].X);
            int pointY = (int)(pointsList[1].Y - pointsList[0].Y);

            int decision = pointY - (pointX / 2);
            int x = (int)pointsList[0].X;
            int y = (int)pointsList[0].Y;

            while (x < (int)pointsList[1].X)
            {
                x++;

                // E or East is chosen
                if (decision < 0) decision +=  pointY;

                // NE or North East is chosen
                else
                {
                    decision += (pointY - pointX);
                    y++;
                }
                Debug.WriteLine($"x {x} and y {y}");
                // Plot intermediate points
                // putpixel(x,y) is used to print
                // pixel of line in graphics
                newPoints.Add(new Point(x, y));
            }
            FindPoint();
        }

        public static void DDALine(List<Point> pointsList)
        {
            newPoints.Clear();
            int step;

            int pointX = (int)(pointsList[1].X - pointsList[0].X);
            int pointY = (int)(pointsList[1].Y - pointsList[0].Y);

            if (Math.Abs(pointX) > Math.Abs(pointY)) step = Math.Abs(pointX);
            else step = Math.Abs(pointY);

            int increaseX = pointX / step;
            int increaseY = pointY / step;

            int x = (int)pointsList[0].X;
            int y = (int)pointsList[0].Y;

            for (int i = 0; i < step; i++)
            {
                x += increaseX;
                y += increaseY;
                newPoints.Add(new Point(x, y));
                Debug.WriteLine($"x {x} and y {y}");
            }
            FindPoint();
        }

        public static void BersenhamLine(List<Point> pointsList, int pointX, int pointY, int decide)
        {
            newPoints.Clear();
            int decisionParam = 2 * pointY - pointX;

            int x1 = (int)pointsList[0].X;
            int y1 = (int)pointsList[0].Y;

            for (int i = 0; i <= pointX; i++)
            {
                if (pointsList[0].X < pointsList[1].X) x1++;
                else x1--;

                if (decisionParam < 0)
                {
                    if (decide == 0) decisionParam = decisionParam + 2 * pointY;
                    else decisionParam = decisionParam + 2 * pointY;
                }
                else
                {
                    if (pointsList[0].Y < pointsList[1].Y) y1++;
                    else y1--;

                    decisionParam = decisionParam + 2 * pointY - 2 * pointX;
                }
                Debug.WriteLine($"x {x1} and y {y1}");
                newPoints.Add(new Point(x1, y1));
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
                    int indexOfRect = LectureFourView._rects.IndexOf(rec);

                     if (rec.Contains(point))
                     {
                        rectangle = LectureFourView._rectangles[indexOfRect];
                        rectangle.Fill = new SolidColorBrush(Colors.Red);
                     }
                }
            }
        }
    }
}
