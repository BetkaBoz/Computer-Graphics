using ComputerGraphics.Core;
using ComputerGraphics.HelperScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics.MVVM.ViewModel
{
    public class LectureFourViewModel : ObservableObject
    {
        string? _output;

        public string Output {
            get => _output;
            set
            {
                _output = value;
                OnPropertyChanged(nameof(Output));
            }
        }

        public LectureFourViewModel()
        {
            LineRasterization.output = Output;
        }
    }
}
