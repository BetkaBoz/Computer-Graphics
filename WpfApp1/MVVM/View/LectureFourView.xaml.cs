using ComputerGraphics.HelperScripts;
using ComputerGraphics.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ComputerGraphics.MVVM.View
{
    public partial class LectureFourView : UserControl
    {
        string? algorithmName;
        bool check;
        int pixelXCount, pixelYCount;

        Rectangle rectangle;
        Rect rect;
        Point currentPoint;
        List<Point> pointsList = new();

        public static List<Rectangle> _rectangles = new();
        public static List<Rect> _rects = new();
       
        public LectureFourView()
        {
            InitializeComponent();
        }

        private void ShowCanvas(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            algorithmName = button.Name;

            canvas.Visibility = Visibility.Visible;

            Refresh();

            check = true;
            ProgressWatch.IsProgress(check, 5);
        }

        private void DrawPixelsOnCanvas()
        {
            for(int i = 0; i < 320; i += 10)
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
                string pixelName = mouseWasDownOn.Name;

                foreach(var rec in _rectangles)
                {
                    if (rec.Name == pixelName)rec.Fill = new SolidColorBrush(Colors.DarkGray);
                }
                pointsList.Add(currentPoint);
            }

            if (pointsList.Count() == 2)
            {
                drawButton.Visibility = Visibility.Visible;
                refresh.Visibility = Visibility.Visible;
            }
            else
            {
                drawButton.Visibility = Visibility.Hidden;
                refresh.Visibility = Visibility.Hidden;
            }
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
                case "baseline":
                    LineRasterization.BaseLine(pointsList);
                    break;
                case "dda":
                    LineRasterization.DDALine(pointsList);
                    break;
                case "bersenham":
                    int pointX = (int)Math.Abs(pointsList[1].X - pointsList[0].X);
                    int pointY = (int)Math.Abs(pointsList[1].Y - pointsList[0].Y);

                    if (pointX > pointY) LineRasterization.BersenhamLine(pointsList, pointX, pointY, 0);
                    else LineRasterization.BersenhamLine(pointsList, pointX, pointY, 1);
                    break;
                default:
                    break;
            }
        }
    }
}
