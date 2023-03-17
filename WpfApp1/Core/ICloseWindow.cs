using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics.Core
{
    public interface ICloseWindow
    {
        Action Close { get; set; }
    }
}
