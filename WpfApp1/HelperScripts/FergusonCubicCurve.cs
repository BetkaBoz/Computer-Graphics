using System.Collections.Generic;
using System.Windows;

namespace ComputerGraphics.HelperScripts
{
    public class FergusonCubicCurve
    {
        public List<Point> _controlPoints;
        public List<Point> _outputPoints = new();

        public FergusonCubicCurve(List<Point> controlPoints)
        {
            _controlPoints = controlPoints;
            GenerateFergusonCubic(controlPoints);
        }

        public void GenerateFergusonCubic(List<Point> outputPoints)
        {
            double tStep = 1.0 / (outputPoints.Count - 1);

            for (int i = 0; i < outputPoints.Count; i++)
            {
                double t = tStep * i;
                double omt = 1.0 - t;

                Point p1 = _controlPoints[0];
                Point p2 = _controlPoints[1];
                Point p3 = _controlPoints[2];
                Point p4 = _controlPoints[3];

                double a1 = omt * omt * omt;
                double a2 = 3 * t * omt * omt;
                double a3 = 3 * t * t * omt;
                double a4 = t * t * t;

                double x = a1 * p1.X + a2 * p2.X + a3 * p3.X + a4 * p4.X;
                double y = a1 * p1.Y + a2 * p2.Y + a3 * p3.Y + a4 * p4.Y;

                Point outputPointsList = new(x, y);
                _outputPoints.Add(outputPointsList);
            }
        }
    }
}