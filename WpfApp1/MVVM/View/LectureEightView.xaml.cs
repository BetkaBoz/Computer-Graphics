﻿using ComputerGraphics.HelperScripts;
using ComputerGraphics.MVVM.ViewModel;
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
    public partial class LectureEightView : UserControl
    {
        int pointCount = 0;
        bool check;
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

            check = true;
            ProgressWatch.IsProgress(check, 9);
        }
        private (Ellipse? ellipse, TextBlock? text) DrawPoint(Point point)
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

            if (pointCount == 4) return (null, null);

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
            if (pointCount > 3)
            {
                connect.Visibility = Visibility.Visible;
                textAddNodes.Visibility = Visibility.Hidden;
            }
            if (pointCount == 4) connect.Visibility = Visibility.Visible;
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

            line.Points = collection;
            line.Stroke = Brushes.Black;
            line.Visibility = Visibility.Visible;
            line.StrokeThickness = 1;

            canvas.Children.Add(line);
        }

        public void ConnectDots(object sender, RoutedEventArgs e)
        {

            if (pointsList.Count == 0) return;

            Connection(pointsList);

            connect.Visibility = Visibility.Hidden;

            Debug.WriteLine(cubicsName);

            switch (cubicsName)
            {
                case "ferguson":
                    Cubics.Ferguson(canvas, pointsList);
                    break;
                case "bezier":
                    Cubics.Bezier(canvas, pointsList);
                    break;
                case "coons":
                    Cubics.Coons(canvas, pointsList);
                    break;
                default:
                    break;
            }
            pointsQueue = new(pointsList);
        }
    }
}
