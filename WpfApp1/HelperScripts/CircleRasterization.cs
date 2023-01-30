using ComputerGraphics.MVVM.View;
using System;
using System.Collections.Generic;
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
        public static List<Point> newPoints = new();

        public static void KartezianCoordinates(List<Point> pointsList)
        {
            newPoints.Clear();

            FindPoint();
        }

        public static void PolarCoordinates(List<Point> pointsList)
        {
            newPoints.Clear();

            FindPoint();
        }

        public static void BersenhamCircle(List<Point> pointsList, int pointX, int pointY, int decide)
        {
            newPoints.Clear();

            FindPoint();
        }

        public static void FindPoint()
        {
            Point point;
            Rectangle rectangle;

            for (int i = 0; i < newPoints.Count; i++)
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
