using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using static System.Net.Mime.MediaTypeNames;

namespace ComputerGraphics.MVVM.View
{
    public partial class LectureOneView : UserControl
    {
        private Point origin;  // Original Offset of image
        private Point startR;   // Original Position of the mouse
        private Point startV;

        public LectureOneView()
        {
            InitializeComponent();

            canvasRaster.MouseWheel += Canvas_MouseWheel;
            canvasVector.MouseWheel += Canvas_MouseWheel;
            raster.MouseLeftButtonDown += Raster_MouseLeftButtonDown;
            raster.MouseLeftButtonUp += image_MouseLeftButtonUp;
            raster.MouseMove += Raster_MouseMove;

            vector.MouseLeftButtonDown += Vector_MouseLeftButtonDown;
            vector.MouseLeftButtonUp += image_MouseLeftButtonUp;
            vector.MouseMove += Vector_MouseMove;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TransformGroup transformGroup = (TransformGroup)raster.RenderTransform;
            ScaleTransform transform = (ScaleTransform)transformGroup.Children[0];

            TransformGroup transformGroup2 = (TransformGroup)vector.RenderTransform;
            ScaleTransform transform2 = (ScaleTransform)transformGroup2.Children[0];

            double zoom = e.NewValue + 0.5;
            transform.ScaleX = zoom;
            transform.ScaleY = zoom;

            transform2.ScaleX = zoom;
            transform2.ScaleY = zoom;
        }

        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Point pR = e.MouseDevice.GetPosition(raster);
            Point pV = e.MouseDevice.GetPosition(vector);

            Matrix mR = raster.RenderTransform.Value;
            Matrix mV = vector.RenderTransform.Value;

            if (e.Delta > 0)
            {
                mR.ScaleAtPrepend(1.1, 1.1, pR.X, pR.Y);
                mV.ScaleAtPrepend(1.1, 1.1, pV.X, pV.Y);
            }
               
            else
            {
                mR.ScaleAtPrepend(1 / 1.1, 1 / 1.1, pR.X, pR.Y);
                mV.ScaleAtPrepend(1 / 1.1, 1 / 1.1, pV.X, pV.Y);
            }
                
            raster.RenderTransform = new MatrixTransform(mR);
            vector.RenderTransform = new MatrixTransform(mV);
        }


        private void Raster_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (raster.IsMouseCaptured) return;

            raster.CaptureMouse();

            startR = e.GetPosition(border);
            origin.X = raster.RenderTransform.Value.OffsetX;
            origin.Y = raster.RenderTransform.Value.OffsetY;
        }

        private void Vector_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (vector.IsMouseCaptured) return;

            vector.CaptureMouse();

            startV = e.GetPosition(borderVector);
            origin.X = vector.RenderTransform.Value.OffsetX;
            origin.Y = vector.RenderTransform.Value.OffsetY;
        }

        private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            raster.ReleaseMouseCapture();
            vector.ReleaseMouseCapture();
        }

        private void Raster_MouseMove(object sender, MouseEventArgs e)
        {
            if (!raster.IsMouseCaptured) return;

            Point pR = e.MouseDevice.GetPosition(border);

            Matrix mR = raster.RenderTransform.Value;
            mR.OffsetX = origin.X + (pR.X - startR.X);
            mR.OffsetY = origin.Y + (pR.Y - startR.Y);

            raster.RenderTransform = new MatrixTransform(mR);
        }

        private void Vector_MouseMove(object sender, MouseEventArgs e)
        {
            if (!raster.IsMouseCaptured) return;

            Point pV = e.MouseDevice.GetPosition(borderVector);

            Matrix mV = vector.RenderTransform.Value;
            mV.OffsetX = origin.X + (pV.X - startV.X);
            mV.OffsetY = origin.Y + (pV.Y - startV.Y);

            vector.RenderTransform = new MatrixTransform(mV);
        }
    }
}
