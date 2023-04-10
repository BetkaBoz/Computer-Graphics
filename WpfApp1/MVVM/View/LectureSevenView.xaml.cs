using ComputerGraphics.HelperScripts;
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
    public partial class LectureSevenView : UserControl
    {
        string? algorithmName;
        bool check;

        List<Point> pointsList = new();
        List<Rectangle> fillRectangle = new();

        public static List<Rectangle> _rectangles = new();
        public static List<Rect> _rects = new();

        public LectureSevenView()
        {
            InitializeComponent();
        }

        private void ShowCanvas(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            algorithmName = button.Name;

            Refresh();

            canvas.Visibility = Visibility.Visible;
            textAddPixel.Visibility = Visibility.Visible;
            fillButton.Visibility = Visibility.Visible;
            refresh.Visibility = Visibility.Visible;
            scannerImg.Visibility = Visibility.Hidden;
            coherentImg1.Visibility = Visibility.Hidden;
            coherentImg2.Visibility = Visibility.Hidden;
            nextImage.Visibility = Visibility.Hidden;

            check = true;
            ProgressWatch.IsProgress(check, 8);
        }

        private void DrawPixelsOnCanvas()
        {
            for (int i = 0; i <= 16; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                ColumnDefinition colDef = new ColumnDefinition();
                grid.RowDefinitions.Add(rowDef);
                grid.ColumnDefinitions.Add(colDef);
            }

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Rectangle rect = new Rectangle();
                    rect.StrokeThickness = 1;
                    rect.Stroke = new SolidColorBrush(Colors.LightGray);
                    rect.Fill = new SolidColorBrush(Colors.White);
                    rect.Width = 20;
                    rect.Height = 20;

                    Grid.SetColumn(rect, i);
                    Grid.SetRow(rect, j);
                    grid.Children.Add(rect);
                    _rectangles.Add(rect);
                }
            }
        }

        private void FillResursivePixels()
        {
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 3 && Grid.GetRow(r) == 3));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 3 && Grid.GetRow(r) == 3));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 3 && Grid.GetRow(r) == 4));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 3 && Grid.GetRow(r) == 5));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 3 && Grid.GetRow(r) == 6));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 3 && Grid.GetRow(r) == 7));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 3 && Grid.GetRow(r) == 8));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 3 && Grid.GetRow(r) == 9));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 3 && Grid.GetRow(r) == 10));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 3 && Grid.GetRow(r) == 11));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 3 && Grid.GetRow(r) == 12));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 4 && Grid.GetRow(r) == 3));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 4 && Grid.GetRow(r) == 12));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 5 && Grid.GetRow(r) == 3));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 5 && Grid.GetRow(r) == 12));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 6 && Grid.GetRow(r) == 3));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 6 && Grid.GetRow(r) == 4));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 6 && Grid.GetRow(r) == 5));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 6 && Grid.GetRow(r) == 6));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 6 && Grid.GetRow(r) == 12));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 7 && Grid.GetRow(r) == 6));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 7 && Grid.GetRow(r) == 12));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 8 && Grid.GetRow(r) == 6));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 8 && Grid.GetRow(r) == 12));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 9 && Grid.GetRow(r) == 6));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 9 && Grid.GetRow(r) == 12));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 10 && Grid.GetRow(r) == 6));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 10 && Grid.GetRow(r) == 7));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 10 && Grid.GetRow(r) == 8));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 10 && Grid.GetRow(r) == 9));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 10 && Grid.GetRow(r) == 12));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 11 && Grid.GetRow(r) == 9));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 11 && Grid.GetRow(r) == 12));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 12 && Grid.GetRow(r) == 9));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 12 && Grid.GetRow(r) == 10));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 12 && Grid.GetRow(r) == 11));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 12 && Grid.GetRow(r) == 12));

            foreach (var r in fillRectangle)
            {
                for (int i = 1; i <= fillRectangle.Count; i++)
                {
                    r.Name = $"rect{i}";
                    r.Fill = new SolidColorBrush(Colors.LightGray);
                }
            }
        }

        private void FillNonRecurzivePixels()
        {
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 2 && Grid.GetRow(r) == 2));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 2 && Grid.GetRow(r) == 3));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 2 && Grid.GetRow(r) == 4));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 2 && Grid.GetRow(r) == 5));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 2 && Grid.GetRow(r) == 6));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 2 && Grid.GetRow(r) == 7));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 2 && Grid.GetRow(r) == 8));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 2 && Grid.GetRow(r) == 9));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 2 && Grid.GetRow(r) == 10));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 2 && Grid.GetRow(r) == 11));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 2 && Grid.GetRow(r) == 12));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 2 && Grid.GetRow(r) == 13));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 3 && Grid.GetRow(r) == 2));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 3 && Grid.GetRow(r) == 13));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 4 && Grid.GetRow(r) == 2));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 4 && Grid.GetRow(r) == 13));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 5 && Grid.GetRow(r) == 2));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 5 && Grid.GetRow(r) == 3));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 5 && Grid.GetRow(r) == 4));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 5 && Grid.GetRow(r) == 5));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 5 && Grid.GetRow(r) == 13));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 6 && Grid.GetRow(r) == 5));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 6 && Grid.GetRow(r) == 6));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 6 && Grid.GetRow(r) == 13));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 7 && Grid.GetRow(r) == 6));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 7 && Grid.GetRow(r) == 13));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 8 && Grid.GetRow(r) == 6));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 8 && Grid.GetRow(r) == 13));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 9 && Grid.GetRow(r) == 5));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 9 && Grid.GetRow(r) == 6));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 9 && Grid.GetRow(r) == 13));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 10 && Grid.GetRow(r) == 2));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 10 && Grid.GetRow(r) == 3));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 10 && Grid.GetRow(r) == 4));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 10 && Grid.GetRow(r) == 5));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 10 && Grid.GetRow(r) == 13));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 11 && Grid.GetRow(r) == 2));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 11 && Grid.GetRow(r) == 11));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 11 && Grid.GetRow(r) == 12));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 11 && Grid.GetRow(r) == 13));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 12 && Grid.GetRow(r) == 2));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 12 && Grid.GetRow(r) == 11));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 13 && Grid.GetRow(r) == 2));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 13 && Grid.GetRow(r) == 3));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 13 && Grid.GetRow(r) == 4));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 13 && Grid.GetRow(r) == 5));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 13 && Grid.GetRow(r) == 6));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 13 && Grid.GetRow(r) == 7));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 13 && Grid.GetRow(r) == 8));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 13 && Grid.GetRow(r) == 9));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 13 && Grid.GetRow(r) == 10));
            fillRectangle.Add(_rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 13 && Grid.GetRow(r) == 11));

            foreach (var r in fillRectangle)
            {
                for (int i = 1; i <= fillRectangle.Count; i++)
                {
                    r.Name = $"rect{i}";
                    r.Fill = new SolidColorBrush(Colors.LightGray);
                }
            }
        }

        private void ShowScanner(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            algorithmName = button.Name;

            Refresh();
            canvas.Visibility = Visibility.Hidden;
            textAddPixel.Visibility = Visibility.Hidden;
            fillButton.Visibility = Visibility.Hidden;
            refresh.Visibility = Visibility.Hidden;

            ShowImages(algorithmName);
        }

        private void ShowImages(string name)
        {
            switch (name)
            {
                case "coherent":
                    coherentImg1.Visibility = Visibility.Visible;
                    coherentImg2.Visibility = Visibility.Hidden;
                    nextImage.Visibility = Visibility.Visible;
                    scannerImg.Visibility = Visibility.Hidden;
                    break;
                case "scanner":
                    scannerImg.Visibility = Visibility.Visible;
                    coherentImg1.Visibility = Visibility.Hidden;
                    coherentImg2.Visibility = Visibility.Hidden;
                    nextImage.Visibility = Visibility.Hidden;
                    break;
            }
        }
        private void NextImage(object sender, MouseButtonEventArgs e)
        {
            if(coherentImg1.Visibility == Visibility.Visible)
            {
                coherentImg1.Visibility = Visibility.Hidden;
                coherentImg2.Visibility = Visibility.Visible;
            }
            else
            {
                coherentImg1.Visibility = Visibility.Visible;
                coherentImg2.Visibility = Visibility.Hidden;
            }
        }

        private void Refresh()
        {
            pointsList.Clear();
            _rectangles.Clear();
            _rects.Clear();
            fillRectangle.Clear();

            refresh.Visibility = Visibility.Hidden;
            showStack.Visibility = Visibility.Hidden;

            DrawPixelsOnCanvas();

            switch(algorithmName)
            {
                case "floodFill":
                    FillResursivePixels();
                    FillAlgorithms.FloodArea(_rectangles, 6, 10, new SolidColorBrush(Colors.LightGray), new SolidColorBrush(Colors.White));
                    break;
                case "seedFill":
                    FillResursivePixels();
                    break;
                case "seedLineFill":
                    FillNonRecurzivePixels();
                    break;
                case "scanner":
                    ShowImages(algorithmName);
                    break;
                case "coherent":
                    ShowImages(algorithmName);
                    break;
            }
        }

        private void RefreshCanvas(object sender, MouseButtonEventArgs e)
        {
            Refresh();
        }

        private void ScannerCalculation(object sender, RoutedEventArgs e)
        {
            textAddPixel.Visibility = Visibility.Hidden;
            fillButton.Visibility = Visibility.Hidden;

            Rectangle rect = _rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 6 && Grid.GetRow(r) == 10);
            switch (algorithmName)
            {
                case "floodFill":
                    showStack.Visibility = Visibility.Visible;
                    FillAlgorithms.FloodFill(_rectangles, 6, 10, new SolidColorBrush(Colors.LightSkyBlue), new SolidColorBrush(Colors.LightGray));
                    break;
                case "seedFill":
                    FillAlgorithms.SeedFill(_rectangles, rect, new SolidColorBrush(Colors.LightSkyBlue), new SolidColorBrush(Colors.White)); 
                    break;
                case "seedLineFill":
                    FillAlgorithms.SeedLineFill(_rectangles, 3, 10, new SolidColorBrush(Colors.LightSkyBlue), new SolidColorBrush(Colors.White), canvasQueue);
                    break;
                default:
                    break;
            }
        }
    }
}
