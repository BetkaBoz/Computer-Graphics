using System.Collections.Generic;
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

        public static async Task FloodFill(List<Rectangle> rectangles, int x, int y, SolidColorBrush replacementColor, SolidColorBrush targetColor)
        {
            await Task.Delay(100);
                Rectangle rect = rectangles.FirstOrDefault(r => Grid.GetColumn(r) == x && Grid.GetRow(r) == y);

                SolidColorBrush rectColor = (SolidColorBrush)rect.Fill;

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

        public static async void SeedLineFill(List<Rectangle> rectangles, int x, int y, SolidColorBrush replacementColor, SolidColorBrush targetColor)
        {
            int previousY = y-1;
            Queue<int> yQueue = new();
            Queue<int> yUpperQueue = new();
            yQueue.Enqueue(y);
            HashSet<int> visited = new HashSet<int>();

            while (yQueue.Count > 0)
            {
                var currentY = yQueue.Dequeue();

                if (currentY < previousY)
                {
                    yUpperQueue.Enqueue(currentY);
                    continue;
                }

                Application.Current.Dispatcher.Invoke(() => { }, DispatcherPriority.Background);

                await FillRow(rectangles, x, currentY, replacementColor, targetColor);

                var colorUp = GetPixelColor(rectangles, x, currentY - 1);
                var colorDown = GetPixelColor(rectangles, x, currentY + 1);

                if (!visited.Contains(currentY))
                {
                    visited.Add(currentY);
                    //lower row
                    if (colorDown != replacementColor.Color && colorDown != borderColor.Color)
                    {
                        yQueue.Enqueue(currentY + 1);
                    }
                    //upper row
                    if (colorUp != replacementColor.Color && colorUp != borderColor.Color)
                    {
                        yUpperQueue.Enqueue(currentY - 1);
                    }
                }
                previousY = currentY;

                if(yQueue.Count <= 0 && yUpperQueue.Count > 0)
                {
                    while(yUpperQueue.Count > 0)
                        {
                            var newCurrentY = yUpperQueue.Dequeue();
                            Application.Current.Dispatcher.Invoke(() => { }, DispatcherPriority.Background);

                            await FillRow(rectangles, x, newCurrentY, replacementColor, targetColor);

                            var colorUpp = GetPixelColor(rectangles, x, newCurrentY - 1);

                        //upper row
                            if (colorUpp != replacementColor.Color && colorUpp != borderColor.Color)
                            {
                                yUpperQueue.Enqueue(newCurrentY - 1);
                            }
                        }
                }
            }
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
