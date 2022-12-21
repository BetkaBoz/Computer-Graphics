using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ComputerGraphics.HelperScripts
{
    public class Refresh
    {
        public void RefreshCanvas(Canvas canvas)
        {
            for (int i = canvas.Children.Count - 1; i >= 0; i--)
            {
                var child = canvas.Children[i];
                if (child is not Line) canvas.Children.RemoveAt(i);
            }
        }
    }
}
