using ComputerGraphics.HelperScripts;
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
    /// <summary>
    /// Interaction logic for LectureSevenView.xaml
    /// </summary>
    public partial class LectureSevenView : UserControl
    {
        string? algorithmName;
        int x, y;

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
            if (algorithmName.Equals("floodFill") || algorithmName.Equals("seedFill")) FillRecurzivePixels();
            else if (algorithmName.Equals("seedLineFill")) FillNonRecurzivePixels();
            else if (algorithmName.Equals("scanner") || algorithmName.Equals("cohren")) ShowScanner();
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

                    rectangle.Name = $"pixel{x}{y}";

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
                y++;
            }
        }
        private void FillPixel(object sender, MouseButtonEventArgs e)
        {
            var mouseWasDownOn = e.Source as FrameworkElement;
            string pixelName = mouseWasDownOn.Name;
            Debug.WriteLine(pixelName);
        }

        private void FillRecurzivePixels()
        {
            // start filling from pixel16010
            foreach (var pixel in _rectangles)
            {
                
                if (pixel.Name.Equals("pixel554") || pixel.Name.Equals("pixel725") || pixel.Name.Equals("pixel896") || pixel.Name.Equals("pixel1067") || pixel.Name.Equals("pixel1238") || pixel.Name.Equals("pixel1409") || pixel.Name.Equals("pixel15710") || pixel.Name.Equals("pixel17411")
                    || pixel.Name.Equals("pixel19112") || pixel.Name.Equals("pixel20813") || pixel.Name.Equals("pixel22514") || pixel.Name.Equals("pixel22614") || pixel.Name.Equals("pixel22714") || pixel.Name.Equals("pixel22814") || pixel.Name.Equals("pixel22914") || pixel.Name.Equals("pixel23014")
                    || pixel.Name.Equals("pixel23114") || pixel.Name.Equals("pixel23214") || pixel.Name.Equals("pixel23314") || pixel.Name.Equals("pixel23414") || pixel.Name.Equals("pixel20112") || pixel.Name.Equals("pixel18411") || pixel.Name.Equals("pixel18411") || pixel.Name.Equals("pixel20112")
                    || pixel.Name.Equals("pixel16710") || pixel.Name.Equals("pixel1509") || pixel.Name.Equals("pixel20813") || pixel.Name.Equals("pixel21813") || pixel.Name.Equals("pixel574") || pixel.Name.Equals("pixel23514") || pixel.Name.Equals("pixel16710")
                    || pixel.Name.Equals("pixel564") || pixel.Name.Equals("pixel584") || pixel.Name.Equals("pixel755") || pixel.Name.Equals("pixel926") || pixel.Name.Equals("pixel936") || pixel.Name.Equals("pixel946") || pixel.Name.Equals("pixel956")
                    || pixel.Name.Equals("pixel1127") || pixel.Name.Equals("pixel1298") || pixel.Name.Equals("pixel1469") || pixel.Name.Equals("pixel1479") || pixel.Name.Equals("pixel1489") || pixel.Name.Equals("pixel1499") || pixel.Name.Equals("pixel1509") )
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
                if (pixel.Name.Equals("pixel373") || pixel.Name.Equals("pixel544") || pixel.Name.Equals("pixel715") || pixel.Name.Equals("pixel886") || pixel.Name.Equals("pixel1057") || pixel.Name.Equals("pixel1057") || pixel.Name.Equals("pixel1228") || pixel.Name.Equals("pixel1399")
                    || pixel.Name.Equals("pixel15610") || pixel.Name.Equals("pixel17311") || pixel.Name.Equals("pixel19012") || pixel.Name.Equals("pixel20713") || pixel.Name.Equals("pixel22414") || pixel.Name.Equals("pixel24115") || pixel.Name.Equals("pixel383") || pixel.Name.Equals("pixel393")
                    || pixel.Name.Equals("pixel403") || pixel.Name.Equals("pixel574") || pixel.Name.Equals("pixel745") || pixel.Name.Equals("pixel916") || pixel.Name.Equals("pixel926") || pixel.Name.Equals("pixel1097") || pixel.Name.Equals("pixel1107") || pixel.Name.Equals("pixel1117")
                    || pixel.Name.Equals("pixel1127") || pixel.Name.Equals("pixel956") || pixel.Name.Equals("pixel966") || pixel.Name.Equals("pixel795") || pixel.Name.Equals("pixel624") || pixel.Name.Equals("pixel453") || pixel.Name.Equals("pixel463") || pixel.Name.Equals("pixel473")
                    || pixel.Name.Equals("pixel483") || pixel.Name.Equals("pixel493") || pixel.Name.Equals("pixel664") || pixel.Name.Equals("pixel835") || pixel.Name.Equals("pixel1006") || pixel.Name.Equals("pixel1177") || pixel.Name.Equals("pixel1348") || pixel.Name.Equals("pixel1519")
                    || pixel.Name.Equals("pixel16810") || pixel.Name.Equals("pixel18511") || pixel.Name.Equals("pixel20212") || pixel.Name.Equals("pixel20112") || pixel.Name.Equals("pixel20012") || pixel.Name.Equals("pixel21713") || pixel.Name.Equals("pixel23414") || pixel.Name.Equals("pixel24415")
                    || pixel.Name.Equals("pixel25115") || pixel.Name.Equals("pixel25015") || pixel.Name.Equals("pixel24915") || pixel.Name.Equals("pixel24815") || pixel.Name.Equals("pixel24715") || pixel.Name.Equals("pixel24615") || pixel.Name.Equals("pixel24515") || pixel.Name.Equals("pixel24315") || pixel.Name.Equals("pixel24215") )
                {
                    pixel.Fill = new SolidColorBrush(Colors.DarkGray);
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
            switch (algorithmName)
            {
                case "floodFill":
                    break;
                case "seedFill":
                    break;
                case "seedLineFill":
                    break;
                default:
                    break;
            }
        }
    }
}
