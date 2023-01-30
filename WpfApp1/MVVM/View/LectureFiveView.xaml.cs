using ComputerGraphics.HelperScripts;
using System;
using System.Collections.Generic;
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
    public partial class LectureFiveView : UserControl
    {
        string? algorithmName;

        int pixelXCount, pixelYCount;

        Rectangle rectangle;
        Rect rect;
        Point currentPoint;
        List<Point> pointsList = new();

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

            canvas.Visibility = Visibility.Visible;

            Refresh();
        }

        private void DrawPixelsOnCanvas()
        {
            for (int i = 0; i < 320; i += 20)
            {
                for (int j = 0; j < 320; j += 20)
                {
                    //create Rectangle
                    rectangle = new();
                    rectangle.StrokeThickness = 1;
                    rectangle.Stroke = new SolidColorBrush(Colors.LightGray);
                    rectangle.Fill = new SolidColorBrush(Colors.White);
                    rectangle.Width = 20;
                    rectangle.Height = 20;

                    rectangle.Name = $"pixel{pixelYCount}{pixelXCount}";
                    pixelXCount++;

                    _rectangles.Add(rectangle);

                    //create Rect
                    rect = new();
                    rect.Width = 20;
                    rect.Height = 20;
                    rect.Location = new Point(i, j);

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
                string pixelName = mouseWasDownOn.Name;

                foreach (var rec in _rectangles)
                {
                    if (rec.Name == pixelName) rec.Fill = new SolidColorBrush(Colors.DarkGray);
                }
                pointsList.Add(currentPoint);
            }

            if (pointsList.Count() == 2) drawButton.Visibility = Visibility.Visible;
            else drawButton.Visibility = Visibility.Hidden;
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
            LineRasterization.newPoints.Clear();

            DrawPixelsOnCanvas();
        }

        private void RasterizeLine(object sender, RoutedEventArgs e)
        {
            switch (algorithmName)
            {
                case "kartezian":
                    
                    break;
                case "polar":
                    
                    break;
                case "bersenham":
                    
                    break;
                default:
                    break;
            }
        }
    }
}
