﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TinySpline;
using System.Windows.Shapes;

namespace ComputerGraphics.HelperScripts
{
    public static class Cubics
    {
        public static Path path = new();
        public static PathFigure pathFigure = new();
        public static PathGeometry pathGeometry = new();
        public static PathSegmentCollection pathSegmentCollection = new();
        public static PathFigureCollection pthFigureCollection = new();

        public static void Ferguson(Canvas canvas, List<Point> pointsList)
        {
            pathFigure.Segments.Clear();
            path.Data = pathGeometry;

            path.Stroke = Brushes.DeepSkyBlue;
            path.StrokeThickness = 2;

            FergusonCubicCurve fergusonCubic = new(pointsList);

            pathFigure.StartPoint = new Point(fergusonCubic._outputPoints[0].X, fergusonCubic._outputPoints[0].Y);

            BezierSegment bezierSegment = new BezierSegment();
            bezierSegment.Point1 = new Point(fergusonCubic._outputPoints[1].X, fergusonCubic._outputPoints[1].Y);
            bezierSegment.Point2 = new Point(fergusonCubic._outputPoints[2].X, fergusonCubic._outputPoints[2].Y);
            bezierSegment.Point3 = new Point(fergusonCubic._outputPoints[3].X, fergusonCubic._outputPoints[3].Y);

            pathFigure.Segments.Add(bezierSegment);
            pathGeometry.Figures.Add(pathFigure);
            path.Data = pathGeometry;

            canvas.Children.Add(path);
        }

        public static void Bezier(Canvas canvas, List<Point> pointsList)
        {
            pathFigure.Segments.Clear();
            path.Data = pathGeometry;

            path.Stroke = Brushes.DeepSkyBlue;
            path.StrokeThickness = 2;

            pathFigure.StartPoint = pointsList[0];

            QuadraticBezierSegment qbezierSegment = new();
            qbezierSegment.Point1 = new Point((pointsList[1].X + pointsList[1].Y) / 2, (pointsList[2].X + pointsList[2].Y) / 2);
            qbezierSegment.Point2 = pointsList[3];

            pathFigure.Segments.Add(qbezierSegment);
            pathGeometry.Figures.Add(pathFigure);
            path.Data = pathGeometry;

            canvas.Children.Add(path);
        }

        public static void GeneralBezier(Canvas canvas, List<Point> pointsList)
        {
            pathFigure.Segments.Clear();
            path.Data = pathGeometry;

            path.Stroke = Brushes.DeepSkyBlue;
            path.StrokeThickness = 2;

            pathFigure.StartPoint = pointsList[0];

            PointCollection points = new();
            for (int i = 1; i <= 9; i++)
            {
                points.Add(pointsList[i]);
            }

            PolyBezierSegment polyBezier = new();
            polyBezier.Points = points;

            pathFigure.Segments.Add(polyBezier);
            pathGeometry.Figures.Add(pathFigure);
            path.Data = pathGeometry;
            canvas.Children.Add(path);
        }

        public static void Coons(Canvas canvas, List<Point> pointsList)
        {
            pathFigure.Segments.Clear();
            path.Data = pathGeometry;

            path.Stroke = Brushes.DeepSkyBlue;
            path.StrokeThickness = 2;

            pathFigure.StartPoint = pointsList[0];

            // loop through each pair of adjacent control points, except for the first and last
            for (int i = 0; i < pointsList.Count - 1; i++)
            {
                // calculate the intermediate control points
                Point p0 = pointsList[i];
                Point p3 = pointsList[i + 1];

                Point p1, p2;

                // calculate p1 for the first curve
                if (i == 0) p1 = new Point(p0.X + (p3.X - p0.X) / 3, p0.Y + (p3.Y - p0.Y) / 3);
                // calculate p1 for the middle curves
                else
                {
                    Point p0prev = pointsList[i - 1];
                    p1 = new Point(p0.X + (p3.X - p0prev.X) / 3, p0.Y + (p3.Y - p0prev.Y) / 3);
                }
                // calculate p2 for the last curve
                if (i == pointsList.Count - 2) p2 = new Point(p3.X - (p3.X - p0.X) / 3, p3.Y - (p3.Y - p0.Y) / 3);
                // calculate p2 for the middle curves
                else
                {
                    Point p3next = pointsList[i + 2];
                    p2 = new Point(p3.X - (p3next.X - p0.X) / 3, p3.Y - (p3next.Y - p0.Y) / 3);
                }
                BezierSegment bezierSegment = new BezierSegment(p1, p2, p3, true);
                pathFigure.Segments.Add(bezierSegment);
            }
            pathGeometry.Figures.Add(pathFigure);
            path.Data = pathGeometry;
            canvas.Children.Add(path);
        }
    }
}
