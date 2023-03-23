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
using Rectangle = System.Windows.Shapes.Rectangle;

namespace ComputerGraphics.HelperScripts
{
    public static class FillAlgorithms
    {
        static SolidColorBrush borderColor = new SolidColorBrush(Colors.DarkGray); 
        static TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

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
                    //if (rectColor.Color != borderColor.Color) FloodFill(rectangles, x, y - 1, replacementColor, targetColor);
                    //else if (rectColor.Color != borderColor.Color) FloodFill(rectangles, x + 1, y, replacementColor, targetColor);
                    //else if (rectColor.Color != borderColor.Color) FloodFill(rectangles, x, y + 1, replacementColor, targetColor);
                    //else if (rectColor.Color != borderColor.Color) FloodFill(rectangles, x - 1, y, replacementColor, targetColor);

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

        public static void SeedLineFill(Rectangle startRectangle)
        {

        }
    }
}
