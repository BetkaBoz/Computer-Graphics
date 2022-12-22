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
            arcPath.Stroke = new SolidColorBrush(Colors.Aqua);
            arcPath.StrokeThickness = 1;
            arcPath.Data = pthGeometry;

            canvas.Children.Add(arcPath);
        }
        private void Coons()
        {

        }

    }
}
