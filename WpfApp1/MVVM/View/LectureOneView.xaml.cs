using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            raster.MouseMove += Canvas_MouseMove;

            vector.MouseLeftButtonDown += Vector_MouseLeftButtonDown;
            vector.MouseLeftButtonUp += image_MouseLeftButtonUp;
            vector.MouseMove += Vector_MouseMove;
        }

        //private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    TransformGroup transformRasterGroup = (TransformGroup)raster.RenderTransform;
        //    ScaleTransform transformRaster = (ScaleTransform)transformRasterGroup.Children[0];

        //    TransformGroup transformVectorGroup = (TransformGroup)vector.RenderTransform;
        //    ScaleTransform transformVector = (ScaleTransform)transformVectorGroup.Children[0];

        //    double zoom = e.NewValue + 1;

        //    transformRaster.ScaleX = zoom;
        //    transformRaster.ScaleY = zoom;

            

        //    transformVector.ScaleX = zoom;
        //    transformVector.ScaleY = zoom;
        //}

        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Matrix mR = raster.RenderTransform.Value;
            Matrix mV = vector.RenderTransform.Value;
            Point canvasPoint;

            if (sender.Equals(canvasRaster)) canvasPoint = e.MouseDevice.GetPosition(canvasRaster);
            if (sender.Equals(canvasVector)) canvasPoint = e.MouseDevice.GetPosition(canvasVector);

            if (e.Delta > 0)
            {
                mR.ScaleAtPrepend(1.1, 1.1, canvasPoint.X, canvasPoint.Y);
                mV.ScaleAtPrepend(1.1, 1.1, canvasPoint.X, canvasPoint.Y);
            }
            else 
            {
                mR.ScaleAtPrepend(1 / 1.1, 1 / 1.1, canvasPoint.X, canvasPoint.Y);
                mV.ScaleAtPrepend(1 / 1.1, 1 / 1.1, canvasPoint.X, canvasPoint.Y);
            }

            raster.RenderTransform = new MatrixTransform(mR);
            vector.RenderTransform = new MatrixTransform(mV);
        }

        private void Raster_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (raster.IsMouseCaptured) return;

            raster.CaptureMouse();

            startR = e.GetPosition(canvasRaster);
            origin.X = raster.RenderTransform.Value.OffsetX;
            origin.Y = raster.RenderTransform.Value.OffsetY;
        }

        private void Vector_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (vector.IsMouseCaptured) return;

            vector.CaptureMouse();

            startV = e.GetPosition(canvasVector);
            origin.X = vector.RenderTransform.Value.OffsetX;
            origin.Y = vector.RenderTransform.Value.OffsetY;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point canvasPoint = e.MouseDevice.GetPosition(canvasRaster);
            Matrix mR = raster.RenderTransform.Value;
            Matrix mV = vector.RenderTransform.Value;

            if (!raster.IsMouseCaptured && !vector.IsMouseCaptured) return;

            //if (sender.Equals(canvasRaster)) canvasPoint = e.MouseDevice.GetPosition(canvasRaster);
            //if (sender.Equals(canvasVector)) canvasPoint = e.MouseDevice.GetPosition(canvasVector);

            mR.OffsetX = origin.X + (canvasPoint.X - startR.X);
            mR.OffsetY = origin.Y + (canvasPoint.Y - startR.Y);
            raster.RenderTransform = new MatrixTransform(mR);

            mV.OffsetX = origin.X + (canvasPoint.X - startR.X);
            mV.OffsetY = origin.Y + (canvasPoint.Y - startR.Y);
            vector.RenderTransform = new MatrixTransform(mV);
        }

        private void Vector_MouseMove(object sender, MouseEventArgs e)
        {
            Matrix mR = raster.RenderTransform.Value;
            Matrix mV = vector.RenderTransform.Value;

            if (!vector.IsMouseCaptured) return;

            Point canvasPoint = e.MouseDevice.GetPosition(canvasVector);

            mR.OffsetX = origin.X + (canvasPoint.X - startV.X);
            mR.OffsetY = origin.Y + (canvasPoint.Y - startV.Y);
            raster.RenderTransform = new MatrixTransform(mR);

            mV.OffsetX = origin.X + (canvasPoint.X - startV.X);
            mV.OffsetY = origin.Y + (canvasPoint.Y - startV.Y);
            vector.RenderTransform = new MatrixTransform(mV);
        }

        private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            raster.ReleaseMouseCapture();
            vector.ReleaseMouseCapture();
        }
    }
}
