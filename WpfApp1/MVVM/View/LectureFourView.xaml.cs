﻿using ComputerGraphics.HelperScripts;
using ComputerGraphics.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
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

        TextBlock block = new();

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

            Refresh();

            canvas.Visibility = Visibility.Visible;
            textAddNodes.Visibility = Visibility.Visible;
            drawButton.Visibility = Visibility.Hidden;

            check = true;
            ProgressWatch.IsProgress(check, 5);
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

                foreach (var rec in _rectangles)
                {
                    if (rec.Name == pixelName) rec.Fill = new SolidColorBrush(Colors.DarkGray);
                }
                pointsList.Add(currentPoint);
            }

            if (pointsList.Count() == 2)
            {
                drawButton.Visibility = Visibility.Visible;
                refresh.Visibility = Visibility.Visible;
                textAddNodes.Visibility = Visibility.Hidden;
            }
            else return;
            if (pointsList.Count() > 2)
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

            textAddNodes.Visibility = Visibility.Visible;
            calculationsBlock.Visibility = Visibility.Hidden;
            drawButton.Visibility = Visibility.Hidden;

            DrawPixelsOnCanvas();
        }

        private void RasterizeLine(object sender, RoutedEventArgs e)
        {
            drawButton.Visibility = Visibility.Hidden;
            calculationsBlock.Visibility = Visibility.Visible;

            outputCanvas.Children.Clear();

            switch (algorithmName)
            {
                case "baseline":
                    LineRasterization.BaseLine(pointsList);
                    WriteOutput();
                    break;
                case "dda":
                    LineRasterization.DDALine(pointsList);
                    WriteOutput();
                    break;
                case "bersenham":
                    int pointX = (int)Math.Abs(pointsList[1].X - pointsList[0].X);
                    int pointY = (int)Math.Abs(pointsList[1].Y - pointsList[0].Y);

                    if (pointX > pointY) LineRasterization.BersenhamLine(pointsList, pointX, pointY, 0);
                    else LineRasterization.BersenhamLine(pointsList, pointX, pointY, 1);
                    WriteOutput();
                    break;
                default:
                    break;
            }
        }

        private void WriteOutput()
        {
            block.Text = $"{string.Join("\n", LineRasterization.outputStrings)}";

            block.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            double blockHeight = block.DesiredSize.Height;
            double blockWidth = block.DesiredSize.Width;
            outputCanvas.Height = blockHeight;
            outputCanvas.Width = blockWidth;

            Canvas.SetTop(block, 0);
            Canvas.SetLeft(block, 0);

            outputCanvas.Children.Add(block);

            calculationsBlock.Content = outputCanvas;
        }
    }
}
