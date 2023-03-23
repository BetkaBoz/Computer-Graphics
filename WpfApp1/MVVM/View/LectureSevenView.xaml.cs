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
        int x, y;
        bool check;

        Rectangle rectangle;
        Rect rect;
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
            textAddPixel.Visibility = Visibility.Hidden;
            fillButton.Visibility = Visibility.Visible;
            refresh.Visibility = Visibility.Visible;

            // draw pixel shape on canvas
            //switch(algorithmName)
            //{
            //    case "floodFill":
            //        FillResursivePixels();
            //        break;
            //    case "seedFill":
            //        FillResursivePixels();
            //        break;
            //    case "seedLineFill":
            //        FillNonRecurzivePixels();
            //        break;
            //    case "scanner":
            //        ShowScanner();
            //        break;
            //    case "cohren":
            //        ShowScanner();
            //        break;
            //}

            

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
            // start filling from pixel16010
            foreach (var pixel in _rectangles)
            {
                if (pixel.Name.Equals("pixel33") || pixel.Name.Equals("pixel43") || pixel.Name.Equals("pixel53") || pixel.Name.Equals("pixel63") || pixel.Name.Equals("pixel73") || pixel.Name.Equals("pixel83") || pixel.Name.Equals("pixel93") || pixel.Name.Equals("pixel103") || pixel.Name.Equals("pixel1314")
                    || pixel.Name.Equals("pixel113") || pixel.Name.Equals("pixel123") || pixel.Name.Equals("pixel133") || pixel.Name.Equals("pixel143") || pixel.Name.Equals("pixel153") || pixel.Name.Equals("pixel154") || pixel.Name.Equals("pixel155") || pixel.Name.Equals("pixel156")
                    || pixel.Name.Equals("pixel157") || pixel.Name.Equals("pixel157") || pixel.Name.Equals("pixel158") || pixel.Name.Equals("pixel159") || pixel.Name.Equals("pixel1510") || pixel.Name.Equals("pixel1511") || pixel.Name.Equals("pixel1512") || pixel.Name.Equals("pixel1513")
                    || pixel.Name.Equals("pixel1413") || pixel.Name.Equals("pixel1313") || pixel.Name.Equals("pixel1315") || pixel.Name.Equals("pixel1215") || pixel.Name.Equals("pixel1115") || pixel.Name.Equals("pixel1015") || pixel.Name.Equals("pixel915") || pixel.Name.Equals("pixel815")
                    || pixel.Name.Equals("pixel715") || pixel.Name.Equals("pixel615") || pixel.Name.Equals("pixel515") || pixel.Name.Equals("pixel415") || pixel.Name.Equals("pixel315") || pixel.Name.Equals("pixel314") || pixel.Name.Equals("pixel313") || pixel.Name.Equals("pixel312")
                    || pixel.Name.Equals("pixel412") || pixel.Name.Equals("pixel512") || pixel.Name.Equals("pixel612") || pixel.Name.Equals("pixel611") || pixel.Name.Equals("pixel711") || pixel.Name.Equals("pixel710") || pixel.Name.Equals("pixel79") || pixel.Name.Equals("pixel78")
                    || pixel.Name.Equals("pixel68") || pixel.Name.Equals("pixel67") || pixel.Name.Equals("pixel57") || pixel.Name.Equals("pixel47") || pixel.Name.Equals("pixel37") || pixel.Name.Equals("pixel36") || pixel.Name.Equals("pixel35") || pixel.Name.Equals("pixel34") || pixel.Name.Equals("pixel1313"))
                {
                    pixel.Fill = new SolidColorBrush(Colors.DarkGray);
                }

                else if (pixel.Name.Equals("pixel107"))
                {
                    pixel.Fill = new SolidColorBrush(Colors.BlueViolet);
                }
            }
        }

        private void ShowScanner()
        {

        }

        private void Refresh()
        {
            pointsList.Clear();
            _rectangles.Clear();
            _rects.Clear();
            fillRectangle.Clear();

            refresh.Visibility = Visibility.Hidden;

            DrawPixelsOnCanvas();

            if (algorithmName == "floodFill" || algorithmName == "seedFill") FillResursivePixels();
            else if (algorithmName == "seedLineFill") FillNonRecurzivePixels();
            else if (algorithmName == "scanner" || algorithmName == "cohren") ShowScanner();
        }

        private void RefreshCanvas(object sender, MouseButtonEventArgs e)
        {
            Refresh();
        }

        private void ScannerCalculation(object sender, RoutedEventArgs e)
        {
            switch (algorithmName)
            {
                case "floodFill":
                    FillAlgorithms.FloodFill(_rectangles, 6, 10, new SolidColorBrush(Colors.LightSkyBlue), new SolidColorBrush(Colors.White));
                    break;
                case "seedFill":
                    Rectangle rect = _rectangles.FirstOrDefault(r => Grid.GetColumn(r) == 6 && Grid.GetRow(r) == 10);
                    FillAlgorithms.SeedFill(_rectangles, rect, new SolidColorBrush(Colors.LightSkyBlue), new SolidColorBrush(Colors.White)); 
                    break;
                case "seedLineFill":
                    //FillAlgorithms.SeedLineFill();
                    break;
                default:
                    break;
            }
        }
    }
}
