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
        public static void Ferguson(PaintEventArgs e)
        {

        }

        public static void Bezier(Canvas canvas, List<Point> pointsList)
        {
            PathFigure pthFigure = new PathFigure();
            pthFigure.StartPoint = pointsList[0];

            QuadraticBezierSegment qbzSeg = new QuadraticBezierSegment();
            qbzSeg.Point1 = new Point((pointsList[1].X + pointsList[1].Y) / 2, (pointsList[2].X + pointsList[2].Y) / 2);
            qbzSeg.Point2 = pointsList[3];

            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
            myPathSegmentCollection.Add(qbzSeg);

            pthFigure.Segments = myPathSegmentCollection;

            PathFigureCollection pthFigureCollection = new PathFigureCollection();
            pthFigureCollection.Add(pthFigure);

            PathGeometry pthGeometry = new PathGeometry();
            pthGeometry.Figures = pthFigureCollection;

            Path arcPath = new Path();
            arcPath.Stroke = new SolidColorBrush(Colors.Purple);
            arcPath.StrokeThickness = 1;
            arcPath.Data = pthGeometry;

            canvas.Children.Add(arcPath);
        }

        public static void Coons()
        {

        }
    }
}
