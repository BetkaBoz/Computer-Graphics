using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComputerGraphics.MVVM.View
{
    /// <summary>
    /// Interaction logic for LectureEightView.xaml
    /// </summary>
    public partial class LectureEightView : UserControl
    {
        int pointCount = 0;

        string? cubicsName;

        Point currentPoint;
        Point lastPoint;
        List<Point> pointsList = new();
        List<Point> pointsListNew = new();
        Queue<Point> pointsQueue = new();

        public LectureEightView()
        {
            InitializeComponent();
        }

        private void Transform(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            cubicsName = button.Name;

            Refresh();

            canvas.Visibility = Visibility.Visible;
            textAddNodes.Visibility = Visibility.Visible;
        }
        private (Ellipse ellipse, TextBlock text) DrawPoint(Point point)
        {
            Ellipse ellipse = new();

            SolidColorBrush mySolidColorBrush = new()
            {
                Color = Color.FromRgb(0, 0, 0)
            };

            ellipse.Fill = mySolidColorBrush;
            ellipse.Width = 6;
            ellipse.Height = 6;

            Canvas.SetLeft(ellipse, point.X - 3);
            Canvas.SetTop(ellipse, point.Y - 3);

            var text = new TextBlock()
            {
                Text = $"P{pointCount}",
            };

            Canvas.SetLeft(text, point.X);
            Canvas.SetTop(text, point.Y);

            return (ellipse, text);
        }

        private void AddNode(object sender, MouseButtonEventArgs e)
        {
            currentPoint = new Point();
            if (e.ButtonState == MouseButtonState.Pressed) currentPoint = e.GetPosition(canvas);

            var draw = DrawPoint(currentPoint);

            // nakleslenie bodu s textom na canvas
            if (lastPoint != currentPoint && pointCount < 4)
            {
                canvas.Children.Add(draw.ellipse);
                canvas.Children.Add(draw.text);

                pointsList.Add(currentPoint);

                pointCount++;
            }

            // skrytie/zobrazenie buttonov a textov
            if (pointCount == 1) refresh.Visibility = Visibility.Visible;
            if (pointCount > 2)
            {
                connect.Visibility = Visibility.Visible;
                textAddNodes.Visibility = Visibility.Hidden;
            }
            if (pointCount == 4)
            {
                connect.Visibility = Visibility.Visible;
            }
        }

        private void RefreshCanvas(object sender, MouseButtonEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            for (int i = canvas.Children.Count - 1; i >= 0; i--)
            {
                var child = canvas.Children[i];
                if (child is not Line) canvas.Children.RemoveAt(i);
            }

            pointsList.Clear();
            pointsListNew.Clear();
            pointsQueue.Clear();
            pointCount = 0;

            refresh.Visibility = Visibility.Hidden;
            connect.Visibility = Visibility.Hidden;
        }

        private void Connection(List<Point> pointsList)
        {
            Polyline line = new();
            PointCollection collection = new(pointsList);

           // collection.Add(pointsList[0]);  //prida sa prvy body znovu do listu aby sa všetky body spojili

            line.Points = collection;
            line.Stroke = Brushes.Black;
            line.Visibility = Visibility.Visible;
            line.StrokeThickness = 1;

            canvas.Children.Add(line);
        }

        private void ConnectDots(object sender, RoutedEventArgs e)
        {
            if (pointsList.Count == 0) return;

            Connection(pointsList);

            connect.Visibility = Visibility.Hidden;
            textAddNodes.Visibility = Visibility.Visible;
            textAddNodes.Text = "Na canvase môžete presúvať jednotlivé body";

            Debug.WriteLine(cubicsName);

            switch (cubicsName)
            {
                case "ferguson":
                    Ferguson();
                    break;
                case "bezier":
                    Bezier();
                    break;
                case "coons":
                    Coons();
                    break;
                default:
                    break;
            }
            pointsQueue = new(pointsList);
        }

        private void Ferguson()
        {
            
        }

        private void Bezier()
        {
            

            for (int i = 0; i < pointsList.Count; i++)
            {
                if (i < 1) bezierStartPoint.StartPoint = pointsList[i];
                else if (i == 1) bezierSegment.Point1 = pointsList[i];
                else if (i == 2) bezierSegment.Point2 = pointsList[i];
                else if (i == 3) bezierSegment.Point3 = pointsList[i];

            }
            BezierCurve.Visibility = Visibility.Visible;
            Debug.WriteLine(BezierCurve.Visibility);
            Debug.WriteLine($"{bezierSegment.Point1}, {bezierSegment.Point2}, {bezierSegment.Point3}") ;
        }

        //private void DrawBezierPoint(PaintEventArgs e)
        //{
        //    // Create pen.
        //    Pen blackPen = new Pen(Color.Black, 3);

        //    // Create points for curve.
        //    Point start = new Point(100, 100);
        //    Point control1 = new Point(200, 10);
        //    Point control2 = new Point(350, 50);
        //    Point end = new Point(500, 100);

        //    // Draw arc to screen.
        //    e.Graphics.DrawBezier(blackPen, start, control1, control2, end);
        //}

        private void Coons()
        {

        }

    }
}
