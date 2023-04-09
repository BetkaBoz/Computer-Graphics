using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using Application = System.Windows.Application;
using Color = System.Windows.Media.Color;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace ComputerGraphics.HelperScripts
{
    public static class FillAlgorithms
    {
        static SolidColorBrush borderColor = new(Colors.LightGray);
        //static Canvas canvas = new();
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

                    //get the neighboring cells of starting rectangle
                    List<Rectangle> neighbors = rectangles.FindAll(r =>
                        (Grid.GetColumn(r) == Grid.GetColumn(rect) && Grid.GetRow(r) == Grid.GetRow(rect) - 1) ||
                        (Grid.GetColumn(r) == Grid.GetColumn(rect) && Grid.GetRow(r) == Grid.GetRow(rect) + 1) ||
                        (Grid.GetColumn(r) == Grid.GetColumn(rect) - 1 && Grid.GetRow(r) == Grid.GetRow(rect)) ||
                        (Grid.GetColumn(r) == Grid.GetColumn(rect) + 1 && Grid.GetRow(r) == Grid.GetRow(rect)));

                    //call seed fill algorithm recursively on the neighboring cells with the same color
                    foreach (Rectangle neighbor in neighbors)
                    {
                        SolidColorBrush neighborColor = (SolidColorBrush)neighbor.Fill;

                        if (neighborColor.Color == rectColor.Color) await SeedFill(rectangles, neighbor, replacementColor, targetColor);
                    }
                }
        }

        public static async void SeedLineFill(List<Rectangle> rectangles, int x, int y, SolidColorBrush replacementColor, SolidColorBrush targetColor, Canvas canvas, TextBlock textBlock)
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
                await RowNumberStack(canvas, yQueue, textBlock);

                if (currentY < previousY)
                {
                    yUpperQueue.Enqueue(currentY);
                    await RowNumberStack(canvas, yUpperQueue, textBlock);
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
                    //lower row
                    if (colorDown != replacementColor.Color && colorDown != borderColor.Color)
                    {
                        yQueue.Enqueue(currentY + 1);
                        await RowNumberStack(canvas, yQueue, textBlock);
                    }
                    //upper row
                    if (colorUp != replacementColor.Color && colorUp != borderColor.Color)
                    {
                        yUpperQueue.Enqueue(currentY - 1);
                        await RowNumberStack(canvas, yUpperQueue, textBlock);
                    }
                }
                previousY = currentY;

                if(yQueue.Count <= 0 && yUpperQueue.Count > 0)
                {
                    while(yUpperQueue.Count > 0)
                    {
                            var newCurrentY = yUpperQueue.Dequeue();
                            await RowNumberStack(canvas, yUpperQueue, textBlock);
                            Application.Current.Dispatcher.Invoke(() => { }, DispatcherPriority.Background);

                            await FillRow(rectangles, x, newCurrentY, replacementColor, targetColor);

                            var colorUpp = GetPixelColor(rectangles, x, newCurrentY - 1);
                            var colorDownn = GetPixelColor(rectangles, x, currentY + 1);

                            if (colorUpp != replacementColor.Color && colorUpp != borderColor.Color)
                            {
                                yUpperQueue.Enqueue(newCurrentY - 1);
                                await RowNumberStack(canvas, yUpperQueue, textBlock);
                            }
                            if (colorDownn != replacementColor.Color && colorDownn != borderColor.Color)
                            {
                                yUpperQueue.Enqueue(newCurrentY + 1);
                                await RowNumberStack(canvas, yUpperQueue, textBlock);
                            }
                    }
                }
            }
        }

        private static async Task RowNumberStack( Canvas mainCanvas, Queue<int> queueItems, TextBlock text)
        {
            //Canvas canvas = new();
            List<string> strings = new List<string>();

            //canvas.Children.Clear();
            mainCanvas.Children.Clear();

            int i = 0;

            if (queueItems.Count == 0) return;

            Application.Current.Dispatcher.Invoke(() => { }, DispatcherPriority.Background);

            foreach (var item in queueItems)
            {
                //strings.Add(item.ToString());
                //string text = $"{string.Join(" | ", strings)}";
                text.Text = $"{string.Join(" | ", item.ToString())}";

                //canvas.Children.Add(textBlock);
                mainCanvas.Children.Add(text);

                i++;
            }
           // mainCanvas.Children.Add(canvas);
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
                
                await FillRow(rectangles, x + 1, y, replacementColor, targetColor);
                await FillRow(rectangles, 11 - 1, y, replacementColor, targetColor);
                await FillRow(rectangles, 12 - 1, y, replacementColor, targetColor);
            }
        }
    }
}
