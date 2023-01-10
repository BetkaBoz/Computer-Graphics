//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Shapes;

//namespace ComputerGraphics.HelperScripts
//{
//    public class DragDrop
//    {
//        protected bool isDragging;
//        public Point clickPosition;
//        public TranslateTransform originTT;

//        public void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
//        {
//            var draggableControl = sender as Shape;
//            originTT = draggableControl.RenderTransform as TranslateTransform ?? new TranslateTransform();
//            isDragging = true;
//            clickPosition = e.GetPosition(this);
//            draggableControl.CaptureMouse();
//        }

//        public void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
//        {
//            isDragging = false;
//            var draggable = sender as Shape;
//            draggable.ReleaseMouseCapture();
//        }

//        public void Canvas_MouseMove(object sender, MouseEventArgs e)
//        {
//            var draggableControl = sender as Shape;
//            if (isDragging && draggableControl != null)
//            {
//                Point currentPosition = e.GetPosition(this);
//                var transform = draggableControl.RenderTransform as TranslateTransform ?? new TranslateTransform();
//                transform.X = originTT.X + (currentPosition.X - clickPosition.X);
//                transform.Y = originTT.Y + (currentPosition.Y - clickPosition.Y);
//                draggableControl.RenderTransform = new TranslateTransform(transform.X, transform.Y);
//            }
//        }
//    }
//}
