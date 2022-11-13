using ComputerGraphics.MVVM.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;

namespace ComputerGraphics.MVVM.View
{
    /// <summary>
    /// Interaction logic for LectureThreeView.xaml
    /// </summary>
    public partial class LectureThreeView : UserControl
    {
        int pointCount = 0;
        int _valueVectorX;
        int _valueVectorY;

        string? transformName;

        Point currentPoint;
        Point lastPoint;
        List<Point> pointsList = new();
        List<Point> pointsListNew = new();
        Queue<Point> pointsQueue;
        

        public LectureThreeView()
        {
            InitializeComponent();
        }

        private void Transform(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            transformName = button.Name;

            canvas.Visibility = Visibility.Visible;

            Refresh();
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

            return(ellipse, text);
        }

        private void AddNode(object sender, MouseButtonEventArgs e)
        {
            currentPoint = new Point();
            if (e.ButtonState == MouseButtonState.Pressed) currentPoint = e.GetPosition(canvas);

            var draw = DrawPoint(currentPoint);

            //draw dot with text
            if (lastPoint != currentPoint && pointCount < 7)
            {
                canvas.Children.Add(draw.ellipse);
                canvas.Children.Add(draw.text);

                pointsList.Add(currentPoint);

                pointCount++;
            }

            if (pointCount == 1) refresh.Visibility = Visibility.Visible;
            if (pointCount > 2) connect.Visibility = Visibility.Visible;
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
            pointCount = 0;

            refresh.Visibility = Visibility.Hidden;
            connect.Visibility = Visibility.Hidden;
            vectors.Visibility = Visibility.Hidden;
        }

        private void Connection(List<Point> pointsList)
        {
            Polyline line = new();
            PointCollection collection = new(pointsList);

            collection.Add(pointsList[0]);  //prida sa prvy body znovu do listu aby sa všetky body spojili

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

            switch (transformName)
            {
                case "move":
                    vectors.Visibility = Visibility.Visible;
                    break;
                case "rotate":
                    Debug.WriteLine("transformuj rotovanim");
                    break;
                case "scale":
                    Debug.WriteLine("transformuj skalovanim");
                    break;
                case "mirror":
                    Debug.WriteLine("transformuj zrkadlenim");
                    break;
                case "scold":
                    Debug.WriteLine("transformuj skosenim");
                    break;
                default:
                    break;
            }

            pointsQueue = new(pointsList);

            //SPOJI VSETKY BODY
            //foreach (Point x in pointsList)
            //{
            //    foreach (Point y in pointsList)
            //    {
            //        Line line = new()
            //        {
            //            X1 = x.X,
            //            Y1 = x.Y,
            //            X2 = y.X,
            //            Y2 = y.Y,
            //            Stroke = Brushes.Black,
            //            Visibility = Visibility.Visible,
            //            StrokeThickness = 1
            //        };
            //        canvas.Children.Add(line);
            //    }
            //}
        }
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //zabezpecenie ze input bude iba numericky, ak sa bude zadavat text alebo iny neplatny input, e.Handled vrati false
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Calculate(object sender, MouseButtonEventArgs e)
        {
            if(pointsQueue.Count == 0) return;

            _valueVectorX = int.Parse(vectorX.Text);
            _valueVectorY = int.Parse(vectorY.Text);

            var point = pointsQueue.Dequeue();

            point.X += _valueVectorX;
            point.Y -= _valueVectorY;

            var draw = DrawPoint(point);

            canvas.Children.Add(draw.ellipse);
            canvas.Children.Add(draw.text);
            pointsListNew.Add(point);

            if (pointsQueue.Count == 0) Connection(pointsListNew);
        }
    }
}
