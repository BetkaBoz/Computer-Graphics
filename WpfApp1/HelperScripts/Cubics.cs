using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ComputerGraphics.HelperScripts
{
    public static class Cubics
    {
        public static PathFigure pathFigure = new();
        public static void Ferguson(Canvas canvas, List<Point> pointsList)
        {
            BezierSegment curve = new BezierSegment(pointsList[1], pointsList[3], pointsList[2], true);

            // Set up the Path to insert the segments
            PathGeometry path = new(); 

            pathFigure.StartPoint = pointsList[0];
            pathFigure.IsClosed = false;
            pathFigure.Segments.Add(curve);
            path.Figures.Add(pathFigure);

            Path arcPath = new();
            arcPath.Stroke = Brushes.Purple;
            arcPath.StrokeThickness = 1;
            arcPath.Data = path;

            canvas.Children.Add(arcPath);
        }

        public static void Bezier(Canvas canvas, List<Point> pointsList)
        {
            pathFigure.StartPoint = pointsList[0];

            QuadraticBezierSegment qbzSeg = new();
            qbzSeg.Point1 = new Point((pointsList[1].X + pointsList[1].Y) / 2, (pointsList[2].X + pointsList[2].Y) / 2);
            qbzSeg.Point2 = pointsList[3];

            PathSegmentCollection myPathSegmentCollection = new();
            myPathSegmentCollection.Add(qbzSeg);

            pathFigure.Segments = myPathSegmentCollection;

            PathFigureCollection pthFigureCollection = new();
            pthFigureCollection.Add(pathFigure);

            PathGeometry pthGeometry = new PathGeometry();
            pthGeometry.Figures = pthFigureCollection;

            Path arcPath = new();
            arcPath.Stroke = Brushes.Purple;
            arcPath.StrokeThickness = 1;
            arcPath.Data = pthGeometry;

            canvas.Children.Add(arcPath);
        }

        public static void Coons(Canvas canvas, List<Point> pointsList)
        {
            pathFigure.StartPoint = pointsList[0];

            QuadraticBezierSegment qbzSeg = new();
            qbzSeg.Point1 = new Point((pointsList[1].X + pointsList[1].Y) / 2, (pointsList[2].X + pointsList[2].Y) / 2);
            qbzSeg.Point2 = pointsList[3];

            PathSegmentCollection myPathSegmentCollection = new();
            myPathSegmentCollection.Add(qbzSeg);

            pathFigure.Segments = myPathSegmentCollection;

            PathFigureCollection pthFigureCollection = new();
            pthFigureCollection.Add(pathFigure);

            PathGeometry pthGeometry = new PathGeometry();
            pthGeometry.Figures = pthFigureCollection;

            Path arcPath = new();
            arcPath.Stroke = Brushes.Purple;
            arcPath.StrokeThickness = 1;
            arcPath.Data = pthGeometry;

            canvas.Children.Add(arcPath);
        }
    }
}
