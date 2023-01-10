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
    public partial class LectureFourView : UserControl
    {
        List<Rectangle> _rectangles = new List<Rectangle>();
        Rectangle rect;

        int colored = 0;

        public LectureFourView()
        {
            InitializeComponent();

            DrawPixels();

        }

        private void DrawPixels()
        {
            int pixel = 0;

            for(int i = 0; i < 320; i += 20)
            {
                for (int j = 0; j < 320; j += 20)
                {
                    rect = new Rectangle(); 
                    rect.StrokeThickness = 1;  
                    rect.Stroke = new SolidColorBrush(Colors.Black); 
                    rect.Fill = new SolidColorBrush(Colors.White);
                    rect.Width = 20;
                    rect.Height = 20;

                    rect.Name = $"pixel{pixel}";
                    pixel++;

                    Canvas.SetTop(rect, i);
                    Canvas.SetLeft(rect, j);
                    _rectangles.Add(rect);
                    canvas.Children.Add(rect);
                }
            }
        }

        private void FillPixel(object sender, MouseButtonEventArgs e)
        {
            var mouseWasDownOn = e.Source as FrameworkElement;

            if (mouseWasDownOn != null && colored < 2)
            {
                string pixelName = mouseWasDownOn.Name;

                Debug.WriteLine(pixelName);

                foreach(var rec in _rectangles)
                {
                    if (rec.Name == pixelName)
                    {
                        rec.Fill = new SolidColorBrush(Colors.Blue);

                        colored++;
                    }
                }
            }
            else return;
        }


        private void RasterizeLine(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
