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
    public partial class LectureTwoView : UserControl
    {
        public LectureTwoView()
        {
            InitializeComponent();
        }
        private void RGB_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GetRGBColour();
        }

        private void GetRGBColour()
        {
            byte rr = (byte)redSlider.Value;
            byte gg = (byte)greenSlider.Value;
            byte bb = (byte)blueSlider.Value;
            Color colorRgb = Color.FromRgb(rr, gg, bb);
            SolidColorBrush colorBrush = new SolidColorBrush(colorRgb);
            rgbRect.Fill = colorBrush;
        }

        private void CMY_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GetCMYColour();
        }

        private void GetCMYColour()
        {
            float c = (float)cyanSlider.Value;
            float m = (float)yellowSlider.Value;
            float y = (float)magentaSlider.Value;

            byte cc = (byte)(255 - c);
            byte mm = (byte)(255 - m);
            byte yy = (byte)(255 - y);

            Color colorCym = Color.FromRgb(cc, yy, mm);
            SolidColorBrush colorBrush = new SolidColorBrush(colorCym);
            cmyRect.Fill = colorBrush;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetRGBColour();
            GetCMYColour();
        }
    }
}
