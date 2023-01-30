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

                // E teda vychodne (east) je vybrane
                if (decision < 0) decision +=  pointY;

                // NE alebo severovychodne (north east) je vybrane
                else
                {
                    decision += (pointY - pointX);
                    y++;
                }
                Debug.WriteLine($"x {x} and y {y}");

                newPoints.Add(new Point(x, y));
            }
            FindPoint();
        }

        public static void DDALine(List<Point> pointsList)
        {
            newPoints.Clear();
            int step, xf, yf;

            int pointX = (int)(pointsList[1].X - pointsList[0].X);
            int pointY = (int)(pointsList[1].Y - pointsList[0].Y);


            if (Math.Abs(pointX) > Math.Abs(pointY)) step = Math.Abs(pointX);
            else step = Math.Abs(pointY);

            float increaseX = pointX / (float)step;
            float increaseY = pointY / (float)step;

            float x = (float)pointsList[0].X;
            float y = (float)pointsList[0].Y;

            
                for (int i = 0; i < step; i++)
                {
                    x += increaseX;
                    xf = (int)x;
                    y += increaseY;
                    yf = (int)y;

                    newPoints.Add(new Point(xf, yf));
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
