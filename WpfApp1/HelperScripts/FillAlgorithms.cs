using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Packaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;
using Color = System.Windows.Media.Color;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace ComputerGraphics.HelperScripts
{
    public static class FillAlgorithms
    {
        static SolidColorBrush borderColor = new(Colors.LightGray);
        static SolidColorBrush backgroundColor = new(Colors.White);
        static List<string> stringsUp = new List<string>();
        static List<string> stringsDown = new List<string>();

        public static void FloodArea(List<Rectangle> rectangles, int x, int y, SolidColorBrush replacementColor, SolidColorBrush targetColor)
        {
            Rectangle? rect = rectangles.FirstOrDefault(r => Grid.GetColumn(r) == x && Grid.GetRow(r) == y);

            SolidColorBrush? rectColor = (SolidColorBrush)rect.Fill;

            if (rect == null || rectColor.Color == replacementColor.Color) return;

            if (rectColor.Color == targetColor.Color)
            {
                rect.Fill = replacementColor;

                // recursively call FloodFill on the neighboring rectangles
                FloodArea(rectangles, x - 1, y, replacementColor, targetColor);
                FloodArea(rectangles, x, y + 1, replacementColor, targetColor);
                FloodArea(rectangles, x + 1, y, replacementColor, targetColor);
                FloodArea(rectangles, x, y - 1, replacementColor, targetColor);
            }
        }

        public static async Task FloodFill(List<Rectangle> rectangles, int x, int y, SolidColorBrush replacementColor, SolidColorBrush targetColor)
        {
            await Task.Delay(100);
                Rectangle? rect = rectangles.FirstOrDefault(r => Grid.GetColumn(r) == x && Grid.GetRow(r) == y);

                SolidColorBrush? rectColor = (SolidColorBrush)rect.Fill;

                if (rect == null || rectColor.Color == replacementColor.Color) return;

                if (rectColor.Color == targetColor.Color)
                {
                    rect.Fill = replacementColor;

                    Application.Current.Dispatcher.Invoke(() => { }, DispatcherPriority.Background);

                    // recursively call FloodFill on the neighboring rectangles
                    await FloodFill(rectangles, x - 1, y, replacementColor, targetColor);
                    await FloodFill(rectangles, x, y + 1, replacementColor, targetColor);
                    await FloodFill(rectangles, x + 1, y, replacementColor, targetColor);
                    await FloodFill(rectangles, x, y - 1, replacementColor, targetColor);
                }
        }

        public static async Task SeedFill(List<Rectangle> rectangles, Rectangle rect, SolidColorBrush replacementColor, SolidColorBrush targetColor)
        {
            await Task.Delay(100);
                SolidColorBrush rectColor = (SolidColorBrush)rect.Fill;

                if (rect == null || rectColor.Color == replacementColor.Color || rectColor.Color == borderColor.Color) return;
                if (rectColor.Color == targetColor.Color)
                {
                    rect.Fill = replacementColor;

                    // get the neighboring cells of starting rectangle
                    List<Rectangle> neighbors = rectangles.FindAll(r =>
                        (Grid.GetColumn(r) == Grid.GetColumn(rect) && Grid.GetRow(r) == Grid.GetRow(rect) - 1) ||
                        (Grid.GetColumn(r) == Grid.GetColumn(rect) && Grid.GetRow(r) == Grid.GetRow(rect) + 1) ||
                        (Grid.GetColumn(r) == Grid.GetColumn(rect) - 1 && Grid.GetRow(r) == Grid.GetRow(rect)) ||
                        (Grid.GetColumn(r) == Grid.GetColumn(rect) + 1 && Grid.GetRow(r) == Grid.GetRow(rect)));

                    // call seed fill algorithm recursively on the neighboring cells with the same color
                    foreach (Rectangle neighbor in neighbors)
                    {
                        SolidColorBrush neighborColor = (SolidColorBrush)neighbor.Fill;

                        if (neighborColor.Color == rectColor.Color) await SeedFill(rectangles, neighbor, replacementColor, targetColor);
                    }
                }
        }

        public static async void SeedLineFill(List<Rectangle> rectangles, int x, int y, SolidColorBrush replacementColor, SolidColorBrush targetColor, Canvas canvas)
        {
            int previousY = y-1;
            Queue<int> yQueue = new();
            Queue<int> yUpperQueue = new();
            yQueue.Enqueue(y);
            HashSet<int> visited = new HashSet<int>();
            Rectangle rectangle = new();

            while (yQueue.Count > 0)
            {
                var currentY = yQueue.Dequeue();
                stringsDown.Remove($"{currentY}");

                // if current row is upper, save it to the queue and continue
                if (currentY < previousY)
                {
                    yUpperQueue.Enqueue(currentY);
                    continue;
                }

                Application.Current.Dispatcher.Invoke(() => { }, DispatcherPriority.Background);

                await FillRow(rectangles, x, currentY, replacementColor, targetColor);

                rectangle = rectangles.FirstOrDefault(r => Grid.GetColumn(r) == x && Grid.GetRow(r) == y);

                var colorUp = GetPixelColor(rectangles, x, currentY - 1);
                var colorDown = GetPixelColor(rectangles, x, currentY + 1);

                if (!visited.Contains(currentY))
                {
                    visited.Add(currentY);
                    // check upper row
                    if (colorUp != replacementColor.Color && colorUp != borderColor.Color) yUpperQueue.Enqueue(currentY - 1);

                    // check lower row
                    if (colorDown != replacementColor.Color && colorDown != borderColor.Color) yQueue.Enqueue(currentY + 1);

                    // add items from Queues to lists
                    foreach (var item in yQueue)
                    {
                        stringsDown.Add(item.ToString());
                    }
                    foreach (var item in yUpperQueue)
                    {
                        if(!stringsUp.Contains(item.ToString())) stringsUp.Add(item.ToString());
                    }
                    // and draw them on canvas
                    await RowNumberStack(canvas, stringsUp, stringsDown);
                }
                previousY = currentY;

                // fill upper rows
                if(yQueue.Count <= 0 && yUpperQueue.Count > 0)
                {
                    while(yUpperQueue.Count > 0)
                    {
                            var newCurrentY = yUpperQueue.Dequeue();
                            stringsUp.Remove($"{newCurrentY}");

                            Application.Current.Dispatcher.Invoke(() => { }, DispatcherPriority.Background);

                            await FillRow(rectangles, x, newCurrentY, replacementColor, targetColor);

                            var colorUpp = GetPixelColor(rectangles, x, newCurrentY - 1);
                            var colorDownn = GetPixelColor(rectangles, x, currentY + 1);

                            if (colorUpp != replacementColor.Color && colorUpp != borderColor.Color) yUpperQueue.Enqueue(newCurrentY - 1);
                            if (colorDownn != replacementColor.Color && colorDownn != borderColor.Color) yUpperQueue.Enqueue(newCurrentY + 1);

                        foreach (var item in yUpperQueue)
                        {
                            stringsUp.Add(item.ToString());
                        }
                        await RowNumberStack(canvas, stringsUp, null);
                    }
                }
            }
            yQueue.Clear();
            yUpperQueue.Clear();
        }

        private static async Task RowNumberStack( Canvas mainCanvas, List<string> stringsListUp, List<string>? stringsListDown)
        {
            Canvas canvas = new();
            List<string> strings = new List<string>();

            if (stringsListUp.Count == 0) return;

            Application.Current.Dispatcher.Invoke(() => { }, DispatcherPriority.Background);

            // add textblock1
            TextBlock text = new();
            text.FontSize = 14;
            text.Text = $"{string.Join("  |  ", stringsListUp)} | ";
            Canvas.SetLeft(text, 10);
            Canvas.SetTop(text, 5);
             
            // add textblock2
            TextBlock text2 = new();
            text2.FontSize = 14;

            if (stringsListDown != null) text2.Text = $"{string.Join("  |  ", stringsListDown)} | ";

            Canvas.SetLeft(text2, 25);
            Canvas.SetTop(text2, 5);

            //set canvas
            mainCanvas.Background = backgroundColor;
            mainCanvas.Children.Clear();
            mainCanvas.Children.Add(text);
            mainCanvas.Children.Add(text2);
        }

        private static Color GetPixelColor(List<Rectangle> rectangles, int x, int y)
        {
            Rectangle rect = rectangles.FirstOrDefault(r => Grid.GetColumn(r) == x && Grid.GetRow(r) == y);

            SolidColorBrush rectColor = (SolidColorBrush)rect.Fill;

            return rectColor.Color;
        }

        private static async Task FillRow(List<Rectangle> rectangles, int x, int y, SolidColorBrush replacementColor, SolidColorBrush targetColor)
        {
            await Task.Delay(50);

            Rectangle rect = rectangles.FirstOrDefault(r => Grid.GetColumn(r) == x && Grid.GetRow(r) == y);
            SolidColorBrush rectColor = (SolidColorBrush)rect.Fill;

            if (rect == null || rectColor.Color == replacementColor.Color) return;

            if (rectColor.Color == targetColor.Color)
            {
                rect.Fill = replacementColor;

                Application.Current.Dispatcher.Invoke(() => { }, DispatcherPriority.Background);
                
                // fill row recursively
                await FillRow(rectangles, x + 1, y, replacementColor, targetColor);
                await FillRow(rectangles, 11 - 1, y, replacementColor, targetColor);
                await FillRow(rectangles, 12 - 1, y, replacementColor, targetColor);
            }
        }
    }
}
