using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ComputerGraphics.Core
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        //protected void OnPropertyChanged([CallerMemberName] string name = null)
        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
