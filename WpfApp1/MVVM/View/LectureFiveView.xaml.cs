using ComputerGraphics.HelperScripts;
using ComputerGraphics.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ComputerGraphics.MVVM.View
{
    public partial class LectureFiveView : UserControl
    {
        string? algorithmName;
        bool check;
        int pixelXCount, pixelYCount;

        Rectangle rectangle;
        Rect rect;
        Point currentPoint;
        List<Point> pointsList = new();

        TextBlock block = new();

        public static List<Rectangle> _rectangles = new();
        public static List<Rect> _rects = new();

        public LectureFiveView()
        {
            InitializeComponent();
        }

        private void ShowCanvas(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            algorithmName = button.Name;

            Refresh();

            canvas.Visibility = Visibility.Visible;

            check = true;
            ProgressWatch.IsProgress(check, 6);
        }

        private void DrawPixelsOnCanvas()
        {
            for (int i = 0; i < 320; i += 10)
            {
                for (int j = 0; j < 320; j += 10)
                {
                    //create Rectangle
                    rectangle = new();
                    rectangle.StrokeThickness = 1;
                    rectangle.Stroke = new SolidColorBrush(Colors.LightGray);
                    rectangle.Fill = new SolidColorBrush(Colors.White);
                    rectangle.Width = 10;
                    rectangle.Height = 10;

                    rectangle.Name = $"pixel{pixelYCount}{pixelXCount}";
                    pixelXCount++;

                    _rectangles.Add(rectangle);

                    //create Rect
                    rect = new();
                    rect.Width = 10;
                    rect.Height = 10;
                    rect.Location = new Point(j, i);

                    _rects.Add(rect);

                    //draw Rectangles on canvas
                    Canvas.SetTop(rectangle, i);
                    Canvas.SetLeft(rectangle, j);
                    canvas.Children.Add(rectangle);
                }
                pixelYCount++;
            }
        }

        private void FillPixel(object sender, MouseButtonEventArgs e)
        {
            currentPoint = new Point();
            if (e.ButtonState == MouseButtonState.Pressed) currentPoint = e.GetPosition(canvas);

            var mouseWasDownOn = e.Source as FrameworkElement;

            if (mouseWasDownOn != null && pointsList.Count() < 2)
            {
                if (pointsList.Count() < 1)
                {
                    string pixelName = mouseWasDownOn.Name;

                    foreach (var rec in _rectangles)
                    {
                        if (rec.Name == pixelName) rec.Fill = new SolidColorBrush(Colors.DarkGray);
                    }
                }
                pointsList.Add(currentPoint);
            }

            if (pointsList.Count() == 1)
            {
                textAddNodes.Visibility = Visibility.Hidden;
                stackPanel.Visibility = Visibility.Visible;
                refresh.Visibility = Visibility.Visible;
                drawButton.Visibility = Visibility.Visible;
            }
            else return;
            if (pointsList.Count() > 1) stackPanel.Visibility = Visibility.Hidden;
        }

        private void RefreshCanvas(object sender, MouseButtonEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            pixelXCount = 0;
            pixelYCount = 0;

            pointsList.Clear();
            _rectangles.Clear();
            _rects.Clear();
            CircleRasterization.pointsList.Clear();

            textAddNodes.Visibility = Visibility.Visible;
            refresh.Visibility = Visibility.Hidden;
            stackPanel.Visibility = Visibility.Hidden;
            calculationsBlock.Visibility = Visibility.Hidden;

            DrawPixelsOnCanvas();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9(.+)]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void RasterizeCircle(object sender, RoutedEventArgs e)
        {
            drawButton.Visibility = Visibility.Hidden;
            calculationsBlock.Visibility = Visibility.Visible;

            outputCanvas.Children.Clear();

            int _radius;
            if (radius.Text != null) _radius = int.Parse(radius.Text);
            else return;

            _radius *= 10; 

            switch (algorithmName)
            {
                case "kartezian":
                    CircleRasterization.KartezianCoordinates(currentPoint, canvas, _radius);
                    WriteOutput();
                    break;
                case "polar":
                    CircleRasterization.PolarCoordinates(currentPoint, canvas, _radius);
                    WriteOutput();
                    break;
                case "bersenham":
                    CircleRasterization.BersenhamCircle(currentPoint, canvas, _radius);
                    WriteOutput();
                    break;
                default:
                    break;
            }
        }

        private void WriteOutput()
        {
            block.Text = $"{string.Join("\n", CircleRasterization.outputStrings)}";
            block.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            double blockHeight = block.DesiredSize.Height;
            double blockWidth = block.DesiredSize.Width;
            outputCanvas.Height = blockHeight;
            outputCanvas.Width = blockWidth;

            outputCanvas.Children.Add(block);

            calculationsBlock.Content = outputCanvas;
        }
    }
}
