using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Drawing;
using Point = System.Windows.Point;
using Color = System.Drawing.Color;

namespace ComputerGraphics.HelperScripts
{
    public static class FillAlgorithms
    {

        public static void FloodFill(Image bmp, Point point, Color targetColor, Color replacementColor)
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
    }
}
