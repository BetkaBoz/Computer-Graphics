using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ComputerGraphics.HelperScripts
{
    public static class FillAlgorithms
    {
        public static Color targetsColor = Color.FromRgb(255, 255, 255);
        public static Color replaceColor = Color.FromRgb(212, 178, 255);

        public static SolidColorBrush fillColor = new SolidColorBrush(Colors.LightCyan);
        public static SolidColorBrush baseColor = new SolidColorBrush(Colors.White);
        public static SolidColorBrush borderColor = new SolidColorBrush(Colors.DarkGray);
        
        public static void FloodFill(Rectangle startRectangle)
        {
            //Stack<Point> pixels = new Stack<Point>();
            //targetColor = bmp.GetPixel(point.X, point.Y);
            //pixels.Push(point);

            //while (pixels.Count > 0)
            //{
            //    Point a = pixels.Pop();
            //    if (a.X < bmp.Width && a.X > 0 &&
            //            a.Y < bmp.Height && a.Y > 0) //make sure we stay within bounds
            //    {

            //        if (bmp.GetPixel(a.X, a.Y) == targetColor)
            //        {
            //            bmp.SetPixel(a.X, a.Y, replacementColor);
            //            pixels.Push(new Point(a.X - 1, a.Y));
            //            pixels.Push(new Point(a.X + 1, a.Y));
            //            pixels.Push(new Point(a.X, a.Y - 1));
            //            pixels.Push(new Point(a.X, a.Y + 1));
            //        }
            //    }
            //}
            ////pictureBox1.Refresh(); //refresh our main picture box
            //return;
        }

        public static void SeedFill(List<Rectangle> rectangleList, int x, int y, Canvas canvas)
        {
            //if (rectangleList.Count == 0 || x < 0 || y < 0 || x >= rectangleList[0].Width || y >= rectangleList[0].Height)
            //    return;

            if (rectangleList.Count == 0 || x >= rectangleList[0].Width || y >= rectangleList[0].Height) return;

                Rectangle currentRect = rectangleList[y * (int)rectangleList[0].Width + x];

            if (currentRect.Fill == baseColor || currentRect.Fill != fillColor)
            {
                currentRect.Fill = fillColor;

                SeedFill(rectangleList, x - 1, y, canvas);
                SeedFill(rectangleList, x + 1, y, canvas);
                SeedFill(rectangleList, x, y - 1, canvas);
                SeedFill(rectangleList, x, y + 1, canvas);
            }

            else return;

            canvas.UpdateLayout();


            //    Application.Current.Dispatcher.Invoke(() => canvas.UpdateLayout())

            //Stack<int> xStack = new Stack<int>();
            //Stack<int> yStack = new Stack<int>();

            //xStack.Push(x);
            //yStack.Push(y);

            //while (xStack.Count > 0 && yStack.Count > 0)
            //{
            //    int xx = xStack.Pop();
            //    int yy = yStack.Pop();

            //    if (xx < 0 || xx >= 20 || yy < 0 || yy >= 20)
            //        continue;

            //    int index = xx + yy * 20;
            //    for(int i = 0; i < rectangleList.Count; i++)
            //    {
            //        if (rectangleList[i].Fill != fillColor)
            //        {
            //            if(rectangleList[i].Fill != borderColor)
            //            {
            //                rectangleList[i].Fill = fillColor;

            //                xStack.Push(xx + 1);
            //                yStack.Push(yy);

            //                xStack.Push(xx - 1);
            //                yStack.Push(yy);

            //                xStack.Push(xx);
            //                yStack.Push(yy + 1);

            //                xStack.Push(xx);
            //                yStack.Push(yy - 1);
            //            }

            //        }
            //   }
            //}
        }

        public static void SeedLineFill(Rectangle startRectangle)
        {

        }
    }
}
