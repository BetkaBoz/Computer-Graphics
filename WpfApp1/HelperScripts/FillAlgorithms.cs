using ComputerGraphics.MVVM.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Application;
using Color = System.Windows.Media.Color;
using Point = System.Windows.Point;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace ComputerGraphics.HelperScripts
{
    public static class FillAlgorithms
    {
        static SolidColorBrush borderColor = new(Colors.LightGray);
        static SolidColorBrush targetColor = new(Colors.White);
        static TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        static CancellationTokenSource tokenSource = new();
        static CancellationToken token = tokenSource.Token;

        public static void FloodFill(List<Rectangle> rectangles, int x, int y, SolidColorBrush replacementColor, SolidColorBrush targetColor)
        {
            Task task = Task.Factory.StartNew(async () =>
            {
                await Task.Delay(500);
                Rectangle rect = rectangles.FirstOrDefault(r => Grid.GetColumn(r) == x && Grid.GetRow(r) == y);

                SolidColorBrush rectColor = (SolidColorBrush)rect.Fill;

                if (rect == null || rectColor.Color == replacementColor.Color) return;

                if (rectColor.Color == targetColor.Color)
                {
                    rect.Fill = replacementColor;

                    Application.Current.Dispatcher.Invoke(() => { }, DispatcherPriority.Background);

                    // recursively call FloodFill on the neighboring rectangles
                    FloodFill(rectangles, x - 1, y, replacementColor, targetColor);
                    FloodFill(rectangles, x, y + 1, replacementColor, targetColor);
                    FloodFill(rectangles, x + 1, y, replacementColor, targetColor);
                    FloodFill(rectangles, x, y - 1, replacementColor, targetColor);
                }
            }, CancellationToken.None, TaskCreationOptions.None, uiScheduler);
        }

        public static void SeedFill(List<Rectangle> rectangles, Rectangle rect, SolidColorBrush replacementColor, SolidColorBrush targetColor)
        {
            Task task = Task.Factory.StartNew(async () =>
            {
                await Task.Delay(500);
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

                        if (neighborColor.Color == rectColor.Color) SeedFill(rectangles, neighbor, replacementColor, targetColor);
                    }
                }
            }, CancellationToken.None, TaskCreationOptions.None, uiScheduler);

        }

        public static async void SeedLineFill(List<Rectangle> rectangles, int x, int y, SolidColorBrush replacementColor, SolidColorBrush targetColor)
        {
            Queue<int> yQueue = new();
            yQueue.Enqueue(y);
            while (yQueue.Count > 0)
            {
                y = yQueue.Dequeue();

                Application.Current.Dispatcher.Invoke(() => { }, DispatcherPriority.Background);

                await FillRow(rectangles, x, y, replacementColor, targetColor);

                var color = GetPixelColor(rectangles, x, y + 1);
                if (color != replacementColor.Color && color != borderColor.Color)
                {
                    yQueue.Enqueue(y + 1);
                }
                if (GetPixelColor(rectangles, x, y - 1) != replacementColor.Color && GetPixelColor(rectangles, x, y - 1) != borderColor.Color)
                {
                    yQueue.Enqueue(y - 1);
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
