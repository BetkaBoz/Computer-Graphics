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
        int xx, yy;
        bool check;

        Rectangle rectangle;
        Rect rect;
        List<Point> pointsList = new();

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
            switch(algorithmName)
            {
                case "floodFill":
                    FillFlooDFillPixels();
                    break;
                case "seedFill":
                    FillSeedFillPixels();
                    break;
                case "seedLineFill":
                    FillNonRecurzivePixels();
                    break;
                case "scanner":
                    ShowScanner();
                    break;
                case "cohren":
                    ShowScanner();
                    break;
            }

            check = true;
            ProgressWatch.IsProgress(check, 8);
        }

        private void DrawPixelsOnCanvas()
        {
            x = 1;
            y = 1;

            for (int i = 0; i <= 320; i += 20)
            {
                for (int j = 0; j <= 320; j += 20)
                {
                    //create Rectangle
                    rectangle = new();
                    rectangle.StrokeThickness = 1;
                    rectangle.Stroke = new SolidColorBrush(Colors.LightGray);
                    rectangle.Fill = new SolidColorBrush(Colors.White);
                    rectangle.Width = 20;
                    rectangle.Height = 20;

                    if (y == 1 && x == 14) rectangle.Name = $"p{y}{x}";
                    else if (y == 1 && x == 13) rectangle.Name = $"p{y}{x}";
                    else rectangle.Name = $"pixel{y}{x}";

                    _rectangles.Add(rectangle);

                    //create Rect
                    rect = new();
                    rect.Width = 20;
                    rect.Height = 20;
                    rect.Location = new Point(j, i);

                    _rects.Add(rect);

                    //draw Rectangles on canvas
                    Canvas.SetTop(rectangle, i);
                    Canvas.SetLeft(rectangle, j);
                    canvas.Children.Add(rectangle);

                    x++;
                }
                x = 1;
                y++;
            }
        }

        private void FillPixel(object sender, MouseButtonEventArgs e)
        {
            var mouseWasDownOn = e.Source as FrameworkElement;
            string pixelName = mouseWasDownOn.Name;
            Debug.WriteLine($"{pixelName} and rect {rect.Location}");
        }

        private void FillFlooDFillPixels()
        {
            // start filling from pixel16010
            foreach (var pixel in _rectangles)
            {

                if (pixel.Name.Equals("pixel44") || pixel.Name.Equals("pixel54") || pixel.Name.Equals("pixel64") || pixel.Name.Equals("pixel74") || pixel.Name.Equals("pixel84") || pixel.Name.Equals("pixel94") || pixel.Name.Equals("pixel104") || pixel.Name.Equals("pixel46")
                    || pixel.Name.Equals("pixel124") || pixel.Name.Equals("pixel134") || pixel.Name.Equals("pixel144") || pixel.Name.Equals("pixel145") || pixel.Name.Equals("pixel146") || pixel.Name.Equals("pixel147") || pixel.Name.Equals("pixel148") || pixel.Name.Equals("pixel149")
                    || pixel.Name.Equals("pixel1410") || pixel.Name.Equals("pixel1411") || pixel.Name.Equals("pixel1412") || pixel.Name.Equals("pixel1413") || pixel.Name.Equals("pixel1414") || pixel.Name.Equals("pixel1314") || pixel.Name.Equals("pixel1214") || pixel.Name.Equals("pixel1114")
                    || pixel.Name.Equals("pixel1113") || pixel.Name.Equals("pixel1112") || pixel.Name.Equals("pixel1111") || pixel.Name.Equals("pixel1011") || pixel.Name.Equals("pixel911") || pixel.Name.Equals("pixel811") || pixel.Name.Equals("pixel810") || pixel.Name.Equals("pixel57")
                    || pixel.Name.Equals("pixel810") || pixel.Name.Equals("pixel89") || pixel.Name.Equals("pixel88") || pixel.Name.Equals("pixel87") || pixel.Name.Equals("pixel77") || pixel.Name.Equals("pixel67") || pixel.Name.Equals("pixel47") || pixel.Name.Equals("pixel45") || pixel.Name.Equals("pixel114") )
                {
                    pixel.Fill = new SolidColorBrush(Colors.DarkGray);
                }
            }
        }

        private void FillSeedFillPixels()
        {
            // start filling from pixel16010
            foreach (var pixel in _rectangles)
            {

                if (pixel.Name.Equals("pixel44") || pixel.Name.Equals("pixel54") || pixel.Name.Equals("pixel64") || pixel.Name.Equals("pixel74") || pixel.Name.Equals("pixel84") || pixel.Name.Equals("pixel94") || pixel.Name.Equals("pixel104") || pixel.Name.Equals("pixel46")
                    || pixel.Name.Equals("pixel124") || pixel.Name.Equals("pixel134") || pixel.Name.Equals("pixel144") || pixel.Name.Equals("pixel145") || pixel.Name.Equals("pixel146") || pixel.Name.Equals("pixel147") || pixel.Name.Equals("pixel148") || pixel.Name.Equals("pixel149")
                    || pixel.Name.Equals("pixel1410") || pixel.Name.Equals("pixel1411") || pixel.Name.Equals("pixel1412") || pixel.Name.Equals("pixel1413") || pixel.Name.Equals("pixel1414") || pixel.Name.Equals("pixel1314") || pixel.Name.Equals("pixel1214") || pixel.Name.Equals("pixel1114")
                    || pixel.Name.Equals("pixel1113") || pixel.Name.Equals("pixel1112") || pixel.Name.Equals("pixel1111") || pixel.Name.Equals("pixel1011") || pixel.Name.Equals("pixel911") || pixel.Name.Equals("pixel811") || pixel.Name.Equals("pixel810") || pixel.Name.Equals("pixel57")
                    || pixel.Name.Equals("pixel810") || pixel.Name.Equals("pixel89") || pixel.Name.Equals("pixel88") || pixel.Name.Equals("pixel87") || pixel.Name.Equals("pixel77") || pixel.Name.Equals("pixel67") || pixel.Name.Equals("pixel47") || pixel.Name.Equals("pixel45") || pixel.Name.Equals("pixel114"))
                {
                    pixel.Fill = new SolidColorBrush(Colors.DarkGray);
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
            //CircleRasterization.pointsList.Clear();

            refresh.Visibility = Visibility.Hidden;

            DrawPixelsOnCanvas();
        }

        private void RefreshCanvas(object sender, MouseButtonEventArgs e)
        {
            Refresh();
        }

        private void ScannerCalculation(object sender, RoutedEventArgs e)
        {
            // set starting pixel from which will algorithms fill
            int index = _rectangles.FindIndex(rect => rect.Name == "pixel117");
            Rect rectStart = _rects[index];

            xx = (int)Math.Floor(rectStart.Location.X / rectStart.Width);
            yy = (int)Math.Floor(rectStart.Location.Y / rectStart.Height);

            switch (algorithmName)
            {
                case "floodFill":
                    //FillAlgorithms.FloodFill();
                    break;
                case "seedFill":
                    FillAlgorithms.SeedFill(_rectangles, xx, yy, canvas); 
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
