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
        public static Path path = new();
        public static PathFigure pathFigure = new();
        public static PathGeometry pathGeometry = new();
        public static PathSegmentCollection myPathSegmentCollection = new();
        public static PathFigureCollection pthFigureCollection = new();

        public static void Ferguson(Canvas canvas, List<Point> pointsList)
        {   
            path.Stroke = Brushes.Black;
            path.StrokeThickness = 2;

            FergusonCubicCurve fergusonCubic = new(pointsList);

            pathFigure.StartPoint = new Point(fergusonCubic._outputPoints[0], fergusonCubic.outputPoints[0, 1]);

            BezierSegment bezierSegment = new BezierSegment();
            bezierSegment.Point1 = new Point(fergusonCubic.outputPoints[1], fergusonCubic.outputPoints[1, 1]);
            bezierSegment.Point2 = new Point(fergusonCubic.outputPoints[2], fergusonCubic.outputPoints[2, 1]);
            bezierSegment.Point3 = new Point(fergusonCubic.outputPoints[3], fergusonCubic.outputPoints[3, 1]);

            pathFigure.Segments.Add(bezierSegment);
            pathGeometry.Figures.Add(pathFigure);
            path.Data = pathGeometry;

            canvas.Children.Add(path);

            //BezierSegment curve = new BezierSegment(pointsList[1], pointsList[3], pointsList[2], true);

            //// Set up the Path to insert the segments
            //PathGeometry path = new(); 

            //pathFigure.StartPoint = pointsList[0];
            //pathFigure.IsClosed = false;
            //pathFigure.Segments.Add(curve);
            //path.Figures.Add(pathFigure);

            //Path arcPath = new();
            //arcPath.Stroke = Brushes.Purple;
            //arcPath.StrokeThickness = 1;
            //arcPath.Data = path;

            //canvas.Children.Add(arcPath);
        }

        public static void Bezier(Canvas canvas, List<Point> pointsList)
        {
            pathFigure.StartPoint = pointsList[0];

            QuadraticBezierSegment qbzSeg = new();
            qbzSeg.Point1 = new Point((pointsList[1].X + pointsList[1].Y) / 2, (pointsList[2].X + pointsList[2].Y) / 2);
            qbzSeg.Point2 = pointsList[3];

            myPathSegmentCollection.Add(qbzSeg);

            pathFigure.Segments = myPathSegmentCollection;
            pthFigureCollection.Add(pathFigure);

            pathGeometry.Figures = pthFigureCollection;

            path.Stroke = Brushes.Purple;
            path.StrokeThickness = 1;
            path.Data = pathGeometry;

            canvas.Children.Add(path);
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
