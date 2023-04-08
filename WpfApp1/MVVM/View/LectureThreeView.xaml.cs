using ComputerGraphics.HelperScripts;
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
    public partial class LectureThreeView : UserControl
    {
        int pointCount = 0;
        int _valueVectorX;
        int _valueVectorY;
        bool check;
        string? transformName;
        string? oldTransformName;
        bool allowAddNodes;

        Point currentPoint;
        Point lastPoint;
        List<Point> pointsList = new();
        List<Point> pointsListNew = new();
        Queue<Point> pointsQueue = new();
        StackPanel panel;

        public LectureThreeView()
        {
            InitializeComponent();
        }

        private void Transform(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            transformName = button.Name;

            Refresh();

            canvas.Visibility = Visibility.Visible;
            textAddNodes.Visibility = Visibility.Visible;

            check = true;
            ProgressWatch.IsProgress(check, 4);
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
            if (allowAddNodes)
            {
                currentPoint = new Point();
                if (e.ButtonState == MouseButtonState.Pressed) currentPoint = e.GetPosition(canvas);

                var draw = DrawPoint(currentPoint);

                // nakleslenie bodu s textom na canvas
                if (lastPoint != currentPoint && pointCount < 7)
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
                else return;
            }
            else return;
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

            textAddNodes.Visibility = Visibility.Hidden;
            refresh.Visibility = Visibility.Hidden;
            connect.Visibility = Visibility.Hidden;

            moveStackPanel.Visibility = Visibility.Hidden;
            rotateStackPanel.Visibility = Visibility.Hidden;
            scaleStackPanel.Visibility = Visibility.Hidden;
            mirrorStackPanel.Visibility = Visibility.Hidden;
            shearStackPanel.Visibility = Visibility.Hidden;

            allowAddNodes = true;
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

            SwitchName(Visibility.Visible);

            pointsQueue = new(pointsList);
            pointCount = 0;

            allowAddNodes = false;
        }

        private void SwitchName(Visibility visibility)
        {
            panel = transformName switch
            {
                "move" => moveStackPanel,
                "rotate" => rotateStackPanel,
                "scale" => scaleStackPanel,
                "mirror" => mirrorStackPanel,
                "scold" => shearStackPanel,
                _ => throw new NotImplementedException(),
            };
            panel.Visibility = visibility;
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // input is only numerical so if there is string or other non allowed input, e.Handler will return false
            Regex regex = new Regex("[^0-9(.+)]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void CalculateStep(object sender, MouseButtonEventArgs e)
        {
            if (pointsQueue.Count == 0) return;

            var point = pointsQueue.Dequeue();

            switch (transformName)
            {
                case "move":
                    _valueVectorX = int.Parse(vectorX.Text);
                    _valueVectorY = int.Parse(vectorY.Text);

                    Transformations.CalculateMove(ref point, _valueVectorX, _valueVectorY);
                    break;
                case "rotate":
                    double rotation = double.Parse(angle.Text);
                    break;
                case "scale":
                    double _valueScale = double.Parse(coeficient.Text);
                    Transformations.CalculateScale(ref point, _valueScale);
                    break;
                case "mirror":
                    int _valueMirror = int.Parse(axis.Text);
                    if (_valueMirror == 0 || _valueMirror == 1)
                    {
                        Transformations.CalculateMirror(ref point, _valueMirror, canvas);
                        textErrorMessage.Visibility = Visibility.Hidden;
                    }
                    else textErrorMessage.Visibility = Visibility.Visible;
                    break;
                case "scold":
                    double _valueSkewX = double.Parse(shearX.Text);
                    double _valueSkewY = double.Parse(shearY.Text);
                    Transformations.CalculateSkew(ref point, _valueSkewX, _valueSkewY);
                    break;
                default:
                    break;
            }

            var draw = DrawPoint(point);

            canvas.Children.Add(draw.ellipse);
            canvas.Children.Add(draw.text);
            pointsListNew.Add(point);

            pointCount++;

            if (pointsQueue.Count == 0) Connection(pointsListNew);
        }

        private void CalculateRotation(object sender, MouseButtonEventArgs e)
        {
            if (pointsQueue.Count == 0) return;

            double _valueRotation = double.Parse(angle.Text);

            var point = pointsQueue.Dequeue();

            double x = point.X;
            double y = point.Y;

            point.X = (x * Math.Cos(_valueRotation)) - (y * Math.Sin(_valueRotation)) + 200;
            point.Y = (x * Math.Sin(_valueRotation)) + (y * Math.Cos(_valueRotation)) - 20;

            var draw = DrawPoint(point);

            canvas.Children.Add(draw.ellipse);
            canvas.Children.Add(draw.text);
            pointsListNew.Add(point);

            if (pointsQueue.Count == 0) Connection(pointsListNew);
        }
    }
}
